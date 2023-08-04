# Rushing B

Endless Scroller built with Unity (2D). A student races across FEUP's B Hall trying to get to class on time. On their way, they will face many different kinds of enemies and power-ups which will aid them in their journey.

The game was published and can be played in [itch.io](https://miguelams.itch.io/rushing-b)!

## Overview

Player has a basic weapon and a jetpack.

### Collectibles

| Type      | Description                                                                         |
| :-------- | :---------------------------------------------------------------------------------- |
| Coins     | Increases final score and can be used as currency for in game actions (eg powerups) |
| Notebooks | Special collectible with greater impact on final score                              |

### Powerups

| Type   | Functionality                            | Activation               | Duration   |
| :----- | :--------------------------------------- | :----------------------- | :--------- |
| Mask   | Protects player against one hit          | Collectible              | 1 hit      |
| Coffee | Temporary shooting improvement (3 shots) | Collectible or 100 coins | 10 seconds |
| Door   | Skips a certain distance (e.g. 1000m)    | Collectible              | N/A        |

## Obstacles

| Type       | Behaviour                                                                   |
| :--------- | :-------------------------------------------------------------------------- |
| Trashcans  | Locks onto the player and horizontally sweeps the screen from right to left |
| Lightbulbs | Appear from either the top or bottom of the screen with varying length      |

## NPCs

| Type          | Behaviour                                                                                  | Traits |
| :------------ | :----------------------------------------------------------------------------------------- | :----- |
| FEUP Teachers | Mini boss fight that spawns ocasionally, with a health bar that stays until it is defeated | Weapon |

## Score

Calculated based on the distance covered, coins and notebooks collected until the player is hit and isn't protected.

## Instructions

Press the `up arrow` key to fly, the `space` key to shoot and `ESC` to pause the game. When in a boss fight, you can press `c` to activate a powerup. Collect as many coins and notebooks as possible!
