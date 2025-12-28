# Memory Card Game (Unity)

A small Unity memory card game I created to showcase code structure
and architectural decisions.

## Gameplay
- Classic memory card matching mechanics
- Multiple grid sizes (difficulty selection)
- Combo-based scoring
- Option to continue a previous game session

## Architecture

### Event-driven design
Core systems communicate through C# events:
- Card interaction
- Card comparison
- Scoring
- Sound effects

This keeps systems loosely coupled and easy to extend.

### Game data separation
Runtime state and configuration data are separated:
- **CardDeckConfig** is immutable configuration (card faces, visuals)
- **GameSession** is mutable runtime state (score, matched cards, progress)

I implemented GameSession as a ScriptableObject to persist data
between scenes and allow continuing a game.

### Responsibility Separation
- `Card` - local card behavior
- `CardSpawner` - card creation
- `CardComparator` - matching logic
- `ScoreController` - scoring and combo system
- `SoundSystem` - audio feedback

## Tech Stack
- Unity
- C#
- DOTween
- TextMeshPro

## Design Goals
- Keep the project small and focused
- Avoid unnecessary abstractions
- Demonstrate architectural thinking without overengineering
- Prefer clarity over complexity

## Possible Extensions
- Additional game modes
- Different scoring strategies
- Alternative card decks
- Save system abstraction

---

This project is intentionally compact and designed to showcase
code structure and decision-making rather than production scale.
