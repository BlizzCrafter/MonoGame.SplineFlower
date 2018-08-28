![Banner](Logos/Logo_Banner_800.png)

# Welcome to MonoGame.SplineFlower!
[![Twitter Follow](https://img.shields.io/twitter/follow/sqrMin1.svg?style=flat-square&label=Follow&logo=twitter)](https://twitter.com/sqrMin1)

Create wonderful smooth **BézierSplines** with **TriggerEvents** for your **MonoGame** project.

### Building

* The **MonoGame.SplineFlower** project is compatible with the **MonoGame.Framework 3.6** and above.

# How-To
### Setup

The **Visual Studio 2015** solution contains the following projects:
- **MonoGame.SplineFlower** (the portable class library)
- **MonoGame.SplineFlower.Content** (spline data and setup class)
- **MonoGame.SplineFlower.Content.Pipeline** (creates .xnb files out of .json BézierSpline data)
- **MonoGame.SplineFlower.Samples** (showing features of the library)
- **MonoGame.SplineFlower.Editor** (create, import and export BézierSplines)
- **MonoGame.SplineFlower.GameTest** (DesktopGL project which loads a BézierSpline with the ContentManager)

1. In your own MonoGame project you need to reference **MonoGame.SplineFlower** if you want to use the library capabilities
2. If you want to load BézierSplines with the **ContentManager**, you also need to reference **MonoGame.SplineFlower.Content.Pipeline**
> Note: You don't need this reference if you want to load BézierSpline data with **Json.Net**
3. When you want to draw the BézierSpline - inclusive trigger events - you need to reference **MonoGame.SplineFlower.Content** to have access
to the **static class Setup**, because you need to call **Setup.Initialize(graphics.GraphicsDevice);** for this purpose
> Note: You don't need this reference if you don't want to draw your BézierSplines. **You don't need to draw BézierSpline at all.**
This is just a **Debug** feature to make your life as a game developer easier ;)

### Capabilities

So what can this library actually do for you?

Despite drawing simple lines, it can also generate:

#### Quadratic BézierCurves
![BezierCurve_Quadratic](doc/BezierCurve_Quadratic.png)

#### Cubic BézierCurves
![BezierCurve_Cubic](doc/BezierCurve_Cubic.png)

#### Complex BézierSplines
![BezierSpline](doc/BezierSpline.png)

Creating BézierSplines is very easy with the **MonoGame.SplineFlower.Editor** project: