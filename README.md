![Banner](Logos/Logo_Banner_800.png)

# Welcome to MonoGame.SplineFlower!
[![Twitter Follow](https://img.shields.io/twitter/follow/blizz_crafter.svg?style=flat-square&label=Follow&logo=twitter)](https://twitter.com/blizz_crafter)
[![License](https://img.shields.io/badge/License-MIT!-blue.svg?style=flat-square&colorA=bc9621&colorB=77c433)](https://github.com/sqrMin1/MonoGame.SplineFlower/blob/master/LICENSE)

[![NuGet](https://img.shields.io/badge/NuGet-MonoGame.SplineFlower-blue.svg?style=flat-square&logo=NuGet&colorA=3260c4&colorB=77c433)](https://www.nuget.org/packages/MonoGame.SplineFlower)
[![NuGet](https://img.shields.io/badge/NuGet-MonoGame.SplineFlower.Content-blue.svg?style=flat-square&logo=NuGet&colorA=3260c4&colorB=77c433)](https://www.nuget.org/packages/MonoGame.SplineFlower.Content)
[![NuGet](https://img.shields.io/badge/NuGet-MonoGame.SplineFlower.Content.Pipeline-blue.svg?style=flat-square&logo=NuGet&colorA=3260c4&colorB=77c433)](https://www.nuget.org/packages/MonoGame.SplineFlower.Content.Pipeline)

Create wonderful smooth **Bézier-, CatMulRom- and Hermite-Splines** with **TriggerEvents** for your **MonoGame** project.

### Building

* The **MonoGame.SplineFlower** project is compatible with the **MonoGame.Framework 3.6** and above.

# How-To
### Setup

The **Visual Studio 2019** solution contains the following projects:
- **MonoGame.SplineFlower** (the portable class library)
- **MonoGame.SplineFlower.Content** (spline data and setup class)
- **MonoGame.SplineFlower.Content.Pipeline** (creates .xnb files out of .json spline data)
- **MonoGame.SplineFlower.Samples** (showing features of the library)
- **MonoGame.SplineFlower.Editor** (create, import and export splines)
- **MonoGame.SplineFlower.GameTest** (DesktopGL project which loads a spline with the ContentManager)

1. In your own MonoGame project you need to reference **MonoGame.SplineFlower** if you want to use the library capabilities
2. If you want to load splines with the **ContentManager**, you also need to reference **MonoGame.SplineFlower.Content.Pipeline**
> Note: You don't need this reference if you want to load spline data with **Json.Net**
3. When you want to draw the spline - inclusive trigger events - you need to reference **MonoGame.SplineFlower.Content** to have access
to the **static class Setup**, because you need to call **Setup.Initialize(graphics.GraphicsDevice);** for this purpose
> Note: You don't need this reference if you don't want to draw your splines. **You don't need to draw splines at all.**
This is just a **Debug** feature to make your life as a game developer easier ;)

For an easy installation you should make use of the nuget package manager:
![Nuget](doc/Nuget.png)

### Capabilities

So what can this library actually do for you? **[[Watch the Video!](https://youtu.be/0Wez5AryxwI)]** (Outdated!)

Despite drawing simple lines, it generates very smooth BézierCurves, BézierSplines, CatMulRomSplines and HermiteSplines pretty fast,
because it uses **polynomial math formulas** behind the scenes.

This makes it possible to generate:

#### Quadratic BézierCurves
![BezierCurve_Quadratic](doc/BezierCurve_Quadratic.png)

#### Cubic BézierCurves
![BezierCurve_Cubic](doc/BezierCurve_Cubic.png)

#### Complex BézierSplines
![BezierSpline](doc/BezierSpline.png)

#### Complex CatMulRomSplines
![CatMulRomSpline](doc/CatMulRom_0.gif)

#### Chain Splines
![ChainSplines](doc/ChainSpline_move.gif)

#### Complex HermiteSplines
![HermiteSplines](doc/HermiteSplines.png)

#### Polygon Stripe Splines
![PolygonStripe](doc/PolygonStripe.png)

Did you notice the different colors of the control points?
You can set them in 3 different modes:

![ControlModes](doc/ControlModes.png)

- **Free** allows you to freely place the control point, but often resulting in sharp corners.
- **Aligned** will enforce such corners and allow you to have connected control points asymmetrical.
- **Mirrored** behave like the aligned one, but allow you to have the connected control points symmetrical.

> Note: A CatmulRomSpline will always have its control points in the **Free** mode!

You can change control modes simply by clicking on them with the **Right Mouse Button** in the:

#### MonoGame.SplineFlower.Editor
![Editor](doc/Editor.png)

It is also possible to create **looped** splines as you can see!
With the **Middle Mouse Button** you can drag the whole spline to keep the overview.

Did you noticed the nice little car on the picture? This is a **[SplineWalker](https://github.com/sqrMin1/MonoGame.SplineFlower/blob/master/MonoGame.SplineFlower/SplineWalker.cs)**.

A SplineWalker can, well... walk on splines :) or drive on it like in the case of a car, hehe.

You have the abillity to create your own SplineWalkers by inheritting from the SplineWalker class mentioned above.

This could look like this:

```c#
public class Car : SplineWalker
{
    public override void CreateSplineWalker(BezierSpline spline, SplineWalkerMode mode, int duration, bool canTriggerEvents = true, bool    autoStart = true)
    {
        base.CreateSplineWalker(spline, mode, duration, canTriggerEvents, autoStart);
    }
    
    protected override void EventTriggered(Trigger obj)
    {
        base.EventTriggered(obj);
    }
    
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }
    
    public override void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
    }
}
```

Click **[here](https://github.com/sqrMin1/MonoGame.SplineFlower/blob/master/MonoGame.SplineFlower.Samples/Car.cs)** to see a full integration example.

A nice thing about a SplineWalker is, that he can trigger custom events on a spline while he walks along the spline.

You can define your own Trigger with the TriggerEditor:

![TriggerEditor](doc/TriggerEditor.png)

It is reachable from the main editor through the **Tools** button.

A SplineWalker also has 3 different built-in movement modes:

- **Once** travels the spline just one time and will stop at the last control point.
- **Looped** travels the spline infinitely (smoothly starts again at the starting point).
- **PingPong** travels the spline forward and then backward when he reaches the last control point / starting point (infinitely).

It's also possible to define different trigger directions:

- **Forward** triggers only in the forward direction.
- **Backward** triggers only in the backward direction.
- **ForwardAndBackward** triggers in both directions.

> Note: It's also possible to control a SplineWalker with your Keyboard or GamePad if you wish so!

---

You can do pretty much anything with splines. The limit is really just your imagination.
*Play around with the samples and learn from it.*

![CatMulRomSpline](doc/CatMulRom_1.gif)

### Now Have Fun with MonoGame.SplineFlower!
[![Twitter Follow](https://img.shields.io/twitter/follow/blizz_crafter.svg?style=flat-square&label=Follow&logo=twitter)](https://twitter.com/blizz_crafter)

![Logo](Logos/Logo_Shadow_256.png)
