import json

remembrance_flags = [
  9100, # - Godrick
  9108, # - Astel
  9111, # - Fortissax
  9112, # - Mohg
  9118, # - Rennala
  9120, # - Malenia
  9122, # - Rykard
  9130, # - Radahn
  9131, # - Fire Giant
  9133, # - Regal Moose
]

remembrance_flags = [
  10000800, # - Godrick
  12040800, # - Astel
  12030850, # - Fortissax
  12050800, # - Mohg
  14000800, # - Rennala
  15000800, # - Malenia
  16000800, # - Rykard
  1252380800, # - Radahn
  1052520800, # - Fire Giant
  12090800, # - Regal Moose
]

pairs = []

for i, r in enumerate(remembrance_flags):
  for j in range(i+1, len(remembrance_flags)):
    p = [r, remembrance_flags[j]]
    print(p)
    pairs.append(p)

# event_conditions = ''
# wait_statement = 'WaitFor('
# for i, pair in enumerate(pairs):
#   event_conditions += f'\nflag{i} = EventFlag({pair[0]}) && EventFlag({pair[1]});'
#   wait_statement += f'\n|| flag{i}'
# print(event_conditions + wait_statement)


init_events = ''
for p, pair in enumerate(pairs):
  init_events += f'\nInitializeEvent({p}, 11100088, {pair[0]}, {pair[1]});'

print(init_events)
