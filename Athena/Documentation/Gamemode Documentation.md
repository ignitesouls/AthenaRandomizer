# Basic Documentation Guidelines
WIP

## Events
Elden Ring Event Flags are quite unique as not just any number can be safely used and relied upon.

The fourth-from-last digit indicates how the flag behaves:
Last four digits	Behavior
0xxx	Saved flag
1xxx	Invalid! Do not use, except as event id
2xxx	Temporary flag
3xxx	Invalid! Do not use, except as event id
4xxx	Saved flag
5xxx	Temporary flag
6xxx	Invalid! Do not use, except as event id
7xxx	Saved flag
8xxx	Saved flag
9xxx	Saved flag

It is important to list out the base event flag ids that you will be using for maintainability.

We use a base event flag id that is known to be valid so there is no conflicts with the vanilla game. 

This allows us to not worry about setting on other in game events that would be unwanted. 

## 