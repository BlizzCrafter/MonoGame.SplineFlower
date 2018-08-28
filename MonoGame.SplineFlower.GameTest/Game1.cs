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

            MyBezierSpline = Content.Load<BezierSpline>(@"SplineFlower");

            MySplineWalker = new Car();
            MySplineWalker.CreateSplineWalker(MyBezierSpline, SplineWalker.SplineWalkerMode.Once, 7);
            MySplineWalker.LoadContent(Content, Content.Load<SpriteFont>(@"GameFont"));

            
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
