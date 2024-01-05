# BEngine
### BEngine is an open-source modular game engine built on top of the monogame framework

**CURRENTLY VERY EARLY IN DEVELOPMENT**

BEngine was created for me as an alternative to Unity. It is meant to give developers a high level of control over their games and the engine used to make them. The main package ([BCORE](https://github.com/Bish0pdev/BCore)) contains the Entity Component System (ECS) that the rest of the engine relies on. The system works very similar to engines like Unity or Unreal in the fact that.

Every **Entity** contains a list of components. Components can be any class inherited from the **Component** parent class. The Components included in Bcore are the *SpriteRenderer* and the *TextRenderer*.

Each **Entity** also contains values for things like position, rotation, and scale. These are included in the base class.

The **Camera** is also included in BCore, which renders entities relative to their position.

Every module will be fully docstringed, and the code will be kept as simple and readable as possible to allow you to change the engine as you see fit.

**MODULES INCLUDED**
- [BCORE](https://github.com/Bish0pdev/BCore) - BCore contains the base ECS classes for objects in BEngine, and utilities to allow other modules to function properly
- BPhysics (Planned)
