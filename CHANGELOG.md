# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

# Unreleased [12/12/2018]
## Additions
- Level 10 and 11.
- Completion time text and end of game.
- Game saves fastest completion time.
    - This resets if you are not on the version you saved it on. This should not happen, but just incase it does, we have this.
- Bouncy blue material in level 11.

## Known Bugs
- Resetting a level, almost as soon as the level starts, the player will not spawn.

# 0.4.0 [12/09/2018]
## Additions
- Sound when grabbing key.
- Jump sound for moveable cubes.
- Player emits a trail when moving.
- Portals emits particles.
- Player emits particles on death.
- Version label at top of menu.

## Changes
- Key hitbox changed, so no more weird looking key grab.
- Shifted Level 9 to the left.

## Fixes
- Fixed not counting deaths correctly.

## Known Bugs
- Resetting a level, almost as soon as the level starts, the player will not spawn.

# 0.3.0 [12/07/2018]
## Additions
- Keys and Locked Portals which require keys to open.
- Movable cubes.
- Force reset. Press left and right at same time.
- Ending screen, displaying death count.
- My own spash screen.

## Known Bugs
- Resetting a level, almost as soon as the level starts, the player will not spawn.
- Does not count deaths correctly.

# 0.2.0 [12/03/2018]
## Additions
- A menu finally.
- Sounds to the player and enemies.
- Added a spash image to the game launcher.

## Changes
- Slightly moved Player collision box.

## Fixes
- Fixed fullscreen not working.

# 0.1.0 [11/28/2018]
## Additions
- First release.
    - Player
    - Enemies
        - Spikes
        - Lasers
    - Jump Block
