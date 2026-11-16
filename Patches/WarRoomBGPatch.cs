extern alias GSD2;

using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace PKCore.Patches
{
    /// <summary>
    /// Hooks GSD2's Tc_main (Apple's War Room / Team Formation menu) to replace OldSrcMap.eventBG's
    /// sprite with hp_classicmap_02 once Tc_main.Load() finishes, leaving Connell's hsound untouched.
    /// </summary>
    [HarmonyPatch]
    public static class WarRoomBGPatch
    {
        private static ManualLogSource Logger => Plugin.Log;

        private const string NEW_BG_TEXTURE = "hp_classicmap_02";
        private static Sprite cachedBGSprite;

        [HarmonyPatch(typeof(GSD2::Tc_main._Load_d__19), nameof(GSD2::Tc_main._Load_d__19.MoveNext))]
        [HarmonyPostfix]
        public static void Postfix_LoadMoveNext(GSD2::Tc_main._Load_d__19 __instance, bool __result)
        {
            if (__result) return;
            if (__instance?.__4__this == null || !__instance.__4__this.isLoaded) return;

            SpriteRenderer sr = GSD2::OldSrcMap.eventBG;
            if (sr == null)
            {
                if (Plugin.Config.DetailedLogs.Value)
                    Logger.LogWarning("[WarRoomBGPatch] Tc_main.Load finished but OldSrcMap.eventBG is null.");
                return;
            }

            EnsureCachedSprite(sr.sprite);
            if (cachedBGSprite != null && sr.sprite != cachedBGSprite)
            {
                sr.sprite = cachedBGSprite;
                if (Plugin.Config.DetailedLogs.Value)
                    Logger.LogInfo($"[WarRoomBGPatch] Replaced OldSrcMap.eventBG sprite with {NEW_BG_TEXTURE}");
            }
        }

        private static void EnsureCachedSprite(Sprite templateSprite)
        {
            if (cachedBGSprite != null) return;

            cachedBGSprite = CustomTexturePatch.LoadCustomSprite(NEW_BG_TEXTURE, templateSprite);

            if (cachedBGSprite == null)
            {
                Texture2D tex = CustomTexturePatch.LoadCustomTexture(NEW_BG_TEXTURE);
                if (tex != null)
                {
                    cachedBGSprite = Sprite.Create(
                        tex,
                        new Rect(0, 0, tex.width, tex.height),
                        new Vector2(0.5f, 0.5f),
                        100f
                    );
                    cachedBGSprite.name = NEW_BG_TEXTURE + "_Custom";
                    Object.DontDestroyOnLoad(cachedBGSprite);
                }
            }
        }
    }
}
