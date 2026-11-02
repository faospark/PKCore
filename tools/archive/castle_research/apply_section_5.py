with open(r'd:\Appz\PKCore\Documentation\dunan_castle_hq_forensic_research.md', 'r', encoding='utf-8') as f:
    original = f.read()

with open(r'd:\Appz\PKCore\tools\section_5_expanded.md', 'r', encoding='utf-8') as f:
    expanded = f.read()

start_marker = "## 5. The 50 Cut \"Castle Level 5\" Scripts (`base_lv >= 4`)"
end_marker = "## 6. Roster Anomalies: The \"Two Millies\" & Bonaparte in the `BEASTS` Array"

idx_start = original.find(start_marker)
idx_end = original.find(end_marker)

print("idx_start:", idx_start, "idx_end:", idx_end)

if idx_start != -1 and idx_end != -1:
    new_doc = original[:idx_start] + expanded.strip() + "\n\n---\n\n" + original[idx_end:]
    with open(r'd:\Appz\PKCore\Documentation\dunan_castle_hq_forensic_research.md', 'w', encoding='utf-8') as f:
        f.write(new_doc)
    print("Successfully replaced Section 5 in dunan_castle_hq_forensic_research.md!")
else:
    print("Markers not found!")

