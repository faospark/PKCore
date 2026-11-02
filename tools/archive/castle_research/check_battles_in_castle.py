import json

with open(r'd:\Appz\PKCore\tools\castle_all_anomalies.json', 'r') as f:
    data = json.load(f)

for k, v in data.items():
    print(f"Key: {k:35s} -> Count: {len(v)}")
    if k in ["boss_battles_in_castle", "tactical_war_battles_in_castle", "out_of_bounds_flags", "jump_out_of_bounds", "item_anomalies"] and len(v) > 0:
        print(f"  {v[:5]}")
