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

        BezierSpline MyBezierSpline;
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

            MyBezierSpline = Content.Load<BezierSpline>(@"SplineTrack");

            MySplineWalker = new Car();
            MySplineWalker.CreateSplineWalker(MyBezierSpline, SplineWalker.SplineWalkerMode.Loop, 7);
            MySplineWalker.LoadContent(Content, Content.Load<SpriteFont>(@"GameFont"));

            // Uncomment the following line to directly set the position of the BezierSpline (Bezier Center).
            //MyBezierSpline.Position(new Vector2(200, 150));

            // Uncomment the following line to translate all control points of the BezierSpline from where the BezierSpline spawned.
            //MyBezierSpline.Translate(new Vector2(200, 150));
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            MySplineWalker.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            MyBezierSpline.DrawSpline(spriteBatch);
            MySplineWalker.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
