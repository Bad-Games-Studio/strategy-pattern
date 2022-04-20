# Strategy Design Pattern in Unity

This repository shows how one can use `Strategy Pattern` (from the book by GoF) in Unity.

## Description

Side note: the example is really simple and stupid, and serves as just a demo.

Here, Strategy Pattern is used to dynamically change how the cube moves. There are 3 possible modes:
  - Manual - controlled by player.
  - Random - it chooses where to move randomly.
  - DVD screensaver (poor copy, but still funny).

![strategy-pattern-demo-screenshot-dont-read-file-name-pls](https://user-images.githubusercontent.com/49134679/159999067-bb83a043-0a2e-42a0-870e-12c85b22a605.png)

## Controls

- Arrows to move (when in `Manual` mode).
- `Space` to cycle between manual, random velocity, and DVD screensaver modes.
