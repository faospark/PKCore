extern alias GSD2;

using System;
using System.Collections.Generic;
using UnityEngine;

namespace PKCore.Patches;

/// <summary>
/// Interactive in-game UI for the restored Suikoden II Hero Bedroom Decoration System.
/// Uses 100% direct Rect GUI elements (no ScrollViews or LayoutGroups) to guarantee
/// full compatibility with stripped Unity/IL2CPP binaries.
/// Includes full Castle Antique Catalog and Party Bag management.
/// </summary>
public static class RoomItemUI
{
    public static bool IsOpen = false;
    public static bool IsLebranteActive = false;
    public static bool IsInHeroBedroom = false;

    private static int _selectedSlot = 0;
    private static int _rightPanelTab = 0; // 0 = Castle Catalog, 1 = Party Bags
    private static int _catalogPage = 0;
    private static int _partyAntiquesPage = 0;
    private static string _statusMessage = "Select a bedroom display surface on the left, then pick any antique on the right to place it!";

    private static Rect _windowRect = new Rect(100, 80, 850, 560);
    private static bool _stylesInitialized = false;
    private static GUIStyle _headerStyle;
    private static GUIStyle _slotHeaderStyle;
    private static GUIStyle _flavorStyle;
    private static GUIStyle _bannerStyle;
    private static GUIStyle _itemLabelStyle;

    private static void InitStyles()
    {
        if (_stylesInitialized) return;

        try
        {
            _headerStyle = new GUIStyle(GUI.skin.label)
            {
                fontSize = 14,
                fontStyle = FontStyle.Bold,
                alignment = TextAnchor.MiddleLeft
            };

            _slotHeaderStyle = new GUIStyle(GUI.skin.label)
            {
                fontSize = 13,
                fontStyle = FontStyle.Bold
            };

            _flavorStyle = new GUIStyle(GUI.skin.label)
            {
                fontSize = 12,
                alignment = TextAnchor.UpperLeft,
                wordWrap = true
            };

            _bannerStyle = new GUIStyle(GUI.skin.button)
            {
                fontSize = 13,
                fontStyle = FontStyle.Bold
            };

            _itemLabelStyle = new GUIStyle(GUI.skin.label)
            {
                fontSize = 12,
                alignment = TextAnchor.MiddleLeft
            };

            _stylesInitialized = true;
        }
        catch { }
    }

    /// <summary>
    /// Renders the OnGUI interface. Called from PkCoreMainLoop.OnGUI().
    /// </summary>
    public static void OnGUI()
    {
        if (!Plugin.Config.EnableRoomItemRestoration.Value) return;

        InitStyles();

        // 1. Main Decoration Window (only rendered when explicitly opened via F9)
        if (IsOpen)
        {
            string title = IsInHeroBedroom
                ? "🏰 Riou's Bedroom Decorator — Dunan Castle (vk16)"
                : (IsLebranteActive
                    ? "🏺 Lebrante's Castle Antique Appraisal & Curation"
                    : "🏛️ Hero's Bedroom Antique Decorator (room_item)");

            _windowRect = GUI.Window(93421, _windowRect, (GUI.WindowFunction)DrawWindowContents, title);
        }
    }

    private static void DrawWindowContents(int windowId)
    {
        try
        {
            // Subtitle / context description
            string subtitle = IsLebranteActive
                ? "Lebrante: \"Ah, Commander Riou! Looking to place our finest appraised antiques into your room?\""
                : (IsInHeroBedroom
                    ? "Riou & Nanami's Quarters: Select a display surface to place, examine, or swap antiques."
                    : "Suikoden II Restored Bedroom Decoration System (8 Persistence Slots)");

            GUI.Label(new Rect(20, 26, 800, 22), subtitle, _headerStyle ?? GUI.skin.label);

            // --- LEFT COLUMN: 8 BEDROOM DISPLAY SURFACES ---
            GUI.Box(new Rect(20, 52, 440, 335), "");
            GUI.Label(new Rect(30, 58, 420, 22), "Bedroom Furniture & Display Surfaces", _slotHeaderStyle ?? GUI.skin.label);

            var items = RoomItemManager.GetRoomItems();

            for (int i = 0; i < RoomItemManager.ROOM_ITEM_MAX; i++)
            {
                var it = (items != null && i < items.Length) ? items[i] : null;
                bool occupied = it != null && it.item_no != 0;
                string itemName = occupied ? RoomItemManager.GetItemName(it) : "(Empty)";
                bool isSelected = (_selectedSlot == i);
                float y = 84f + (i * 35f);

                string slotLabel = isSelected
                    ? $"> Slot {i + 1}: {RoomItemManager.SlotDescriptions[i]}"
                    : $"Slot {i + 1}: {RoomItemManager.SlotDescriptions[i]}";

                if (GUI.Button(new Rect(28, y, 225, 28), slotLabel))
                {
                    _selectedSlot = i;
                    if (occupied)
                    {
                        _statusMessage = RoomItemManager.GetSlotFlavorText(i, it);
                    }
                    else
                    {
                        _statusMessage = $"{RoomItemManager.SlotDescriptions[i]} is selected. Pick an antique on the right to place it!";
                    }
                }

                GUI.Label(new Rect(258, y + 3, 140, 24), itemName, _itemLabelStyle ?? GUI.skin.label);

                if (occupied)
                {
                    if (GUI.Button(new Rect(404, y + 1, 48, 26), "Take"))
                    {
                        RoomItemManager.RemoveItemToParty(i, out string msg);
                        _statusMessage = msg;
                    }
                }
            }

            // --- RIGHT COLUMN: TABS (CATALOG / PARTY BAGS) ---
            GUI.Box(new Rect(470, 52, 360, 335), "");

            // Tab headers
            if (GUI.Button(new Rect(472, 54, 175, 26), (_rightPanelTab == 0 ? "★ Castle Catalog" : "Castle Catalog")))
            {
                _rightPanelTab = 0;
            }
            if (GUI.Button(new Rect(650, 54, 175, 26), (_rightPanelTab == 1 ? "★ Party Bags" : "Party Bags")))
            {
                _rightPanelTab = 1;
            }

            // TAB 0: CASTLE ANTIQUE CATALOG (Place any antique including Bonsai Tree directly)
            if (_rightPanelTab == 0)
            {
                var catalog = RoomItemManager.AntiqueCatalog;
                int itemsPerPage = 7;
                int totalPages = Math.Max(1, (catalog.Length + itemsPerPage - 1) / itemsPerPage);
                _catalogPage = Mathf.Clamp(_catalogPage, 0, totalPages - 1);

                // Pagination
                if (GUI.Button(new Rect(720, 84, 25, 20), "<"))
                {
                    if (_catalogPage > 0) _catalogPage--;
                }
                GUI.Label(new Rect(750, 84, 45, 20), $"{_catalogPage + 1}/{totalPages}", _itemLabelStyle ?? GUI.skin.label);
                if (GUI.Button(new Rect(800, 84, 25, 20), ">"))
                {
                    if (_catalogPage < totalPages - 1) _catalogPage++;
                }

                GUI.Label(new Rect(480, 84, 230, 20), "Choose Antique to Place:", _slotHeaderStyle ?? GUI.skin.label);

                int startIdx = _catalogPage * itemsPerPage;
                int endIdx = Math.Min(startIdx + itemsPerPage, catalog.Length);

                for (int c = startIdx; c < endIdx; c++)
                {
                    var catItem = catalog[c];
                    float y = 110f + ((c - startIdx) * 37f);

                    GUI.Label(new Rect(480, y + 4, 160, 24), catItem.name, _itemLabelStyle ?? GUI.skin.label);

                    if (GUI.Button(new Rect(645, y + 2, 130, 28), $"Place on Slot {_selectedSlot + 1}"))
                    {
                        RoomItemManager.SetRoomItem(_selectedSlot, catItem.itemNo, catItem.useCnt);
                        _statusMessage = $"Placed {catItem.name} onto {RoomItemManager.SlotDescriptions[_selectedSlot]}!";
                    }

                    if (GUI.Button(new Rect(780, y + 2, 44, 28), "+Bag"))
                    {
                        RoomItemManager.GiveAntiqueToPartyBag(catItem.itemNo, catItem.useCnt, out string bagMsg);
                        _statusMessage = bagMsg;
                    }
                }
            }
            // TAB 1: PARTY BAGS
            else
            {
                var heldAntiques = RoomItemManager.GetPartyDecorItems();
                if (heldAntiques.Count == 0)
                {
                    GUI.Label(
                        new Rect(485, 95, 330, 160),
                        "No evaluated antiques currently in party bags.\n\nTip: Use the 'Castle Catalog' tab to place\nantiques (like Bonsai Tree) directly,\nor click '+ Give Bonsai to Bag' below!",
                        _flavorStyle ?? GUI.skin.label
                    );
                }
                else
                {
                    int itemsPerPage = 7;
                    int totalPages = Math.Max(1, (heldAntiques.Count + itemsPerPage - 1) / itemsPerPage);
                    _partyAntiquesPage = Mathf.Clamp(_partyAntiquesPage, 0, totalPages - 1);

                    // Pagination controls
                    if (totalPages > 1)
                    {
                        if (GUI.Button(new Rect(720, 84, 25, 20), "<"))
                        {
                            if (_partyAntiquesPage > 0) _partyAntiquesPage--;
                        }
                        GUI.Label(new Rect(750, 84, 45, 20), $"{_partyAntiquesPage + 1}/{totalPages}", _itemLabelStyle ?? GUI.skin.label);
                        if (GUI.Button(new Rect(800, 84, 25, 20), ">"))
                        {
                            if (_partyAntiquesPage < totalPages - 1) _partyAntiquesPage++;
                        }
                    }

                    int startIndex = _partyAntiquesPage * itemsPerPage;
                    int endIndex = Math.Min(startIndex + itemsPerPage, heldAntiques.Count);

                    for (int k = startIndex; k < endIndex; k++)
                    {
                        var (cno, bagIndex, antique) = heldAntiques[k];
                        string holder = RoomItemManager.GetCharacterName(cno);
                        string aName = RoomItemManager.GetItemName(antique);
                        float y = 110f + ((k - startIndex) * 37f);

                        GUI.Label(new Rect(480, y + 4, 175, 24), $"{holder}: {aName}", _itemLabelStyle ?? GUI.skin.label);

                        if (GUI.Button(new Rect(665, y + 2, 155, 28), $"Place on Slot {_selectedSlot + 1}"))
                        {
                            RoomItemManager.PlaceItemFromParty(cno, bagIndex, _selectedSlot, out string placeMsg);
                            _statusMessage = placeMsg;
                        }
                    }
                }
            }

            // --- BOTTOM INSPECTION / STATUS BOX ---
            GUI.Box(new Rect(20, 395, 810, 88), "");
            GUI.Label(new Rect(30, 400, 790, 20), "Inspection & Commentary:", _slotHeaderStyle ?? GUI.skin.label);
            GUI.Label(new Rect(30, 422, 790, 56), _statusMessage, _flavorStyle ?? GUI.skin.label);

            // --- FOOTER BUTTONS ---
            if (GUI.Button(new Rect(20, 495, 160, 32), "Examine Slot"))
            {
                var it = RoomItemManager.GetRoomItem(_selectedSlot);
                _statusMessage = RoomItemManager.GetSlotFlavorText(_selectedSlot, it);
            }

            if (GUI.Button(new Rect(190, 495, 180, 32), "+ Give Bonsai to Bag"))
            {
                // Bonsai item_no = 19, use_cnt = 64
                RoomItemManager.GiveAntiqueToPartyBag(19, 64, out string bonsaiMsg);
                _statusMessage = bonsaiMsg;
            }

            if (GUI.Button(new Rect(380, 495, 170, 32), "Seed 4 Starter Antiques"))
            {
                RoomItemManager.SetRoomItem(0, 10, 64); // Celadon Urn
                RoomItemManager.SetRoomItem(1, 18, 64); // Peeing Boy
                RoomItemManager.SetRoomItem(2, 19, 64); // Bonsai Tree
                RoomItemManager.SetRoomItem(3, 20, 64); // Knight Statue
                _statusMessage = "Seeded Celadon Urn, Peeing Boy, Bonsai Tree, and Knight Statue into Slots 1-4!";
            }

            if (GUI.Button(new Rect(710, 495, 120, 32), "Close (Esc / F9)"))
            {
                IsOpen = false;
            }

            GUI.DragWindow(new Rect(0, 0, 10000, 25));
        }
        catch (Exception ex)
        {
            GUI.Label(new Rect(30, 50, 780, 200), $"Rendering Error: {ex.Message}\n{ex.StackTrace}");
        }
    }
}
