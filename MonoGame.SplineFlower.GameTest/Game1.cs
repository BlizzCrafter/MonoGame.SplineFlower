using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.SplineFlower.Content;
using MonoGame.SplineFlower.Samples;

namespace MonoGame.SplineFlower.GameTest
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        BezierSpline MySpline;
        Car MySplineWalker;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();

            Setup.Initialize(graphics.GraphicsDevice);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Loading a spline with the MonoGame.SplineFlower.Content.Pipeline
            MySpline = Content.Load<BezierSpline>(@"SplineTrack");

            // Programmatically creating a looped CatMulRomSpline
            // MySpline = new BezierSpline(new Transform[]
            //    {
            //        new Transform(new Vector2(100, 100)),
            //        new Transform(new Vector2(200, 100)),
            //        new Transform(new Vector2(150, 200)),
            //        new Transform(new Vector2(200, 200)),
            //        new Transform(new Vector2(300, 200)),
            //        new Transform(new Vector2(300, 100)),
            //        new Transform(new Vector2(400, 100)),
            //        new Transform(new Vector2(450, 200)),
            //        new Transform(new Vector2(400, 400)),
            //        new Transform(new Vector2(200, 450))
            //    });
            // MySpline.CatMulRom = true;
            // MySpline.Loop = true;

            // Place a SplineWalker on the spline
            MySplineWalker = new Car();
            MySplineWalker.CreateSplineWalker(MySpline, SplineWalker.SplineWalkerMode.Loop, 7);
            MySplineWalker.LoadContent(Content, Content.Load<SpriteFont>(@"GameFont"));

            // Uncomment to directly set the position of the spline (SplineCenter)
            // MySpline.Position(new Vector2(200, 150));

            // Uncomment to translate all control points of the spline from where the it spawned
            // MySpline.Translate(new Vector2(200, 150));

            // Uncomment to rotate the spline
            // MySpline.Rotate(-90f);

            // Uncomment to scale the spline
            // MySpline.Scale(-50f);

            // Uncomment to scale-rotate the spline and scale it again afterwards
            // MySpline.ScaleRotate(-180f);
            // MySpline.Scale(-50f);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (MySplineWalker != null) MySplineWalker.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            if (MySpline != null) MySpline.DrawSpline(spriteBatch);
            if (MySplineWalker != null) MySplineWalker.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
