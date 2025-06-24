using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.SplineFlower.Rendering;
using MonoGame.SplineFlower.Spline;

namespace MonoGame.SplineFlower.Samples.Controls
{
    public class PolygonSplineControl : TransformControl
    {
        protected override void Initialize()
        {
            Setup.Initialize(Editor.GraphicsDevice);
        }

        public override void InitializeSplineControlSample()
        {
            Setup.ShowCurves = false;
            Setup.ShowDirectionVectors = false;
            Setup.ShowLines = false;
            Setup.ShowPoints = false;
            UseWorldUnits = true;

            //Uncomment to show the wireframe of the generated polygon stripe.
            //Functions.RasterizerState.FillMode = FillMode.WireFrame;

            MySpline = Editor.Content.Load<SplineBase>("RaceTrack");
            MySpline.PolygonStripeTexture = Editor.Content.Load<Texture2D>("roadTexture");
            MySpline.Loop = true;

            CenterSpline();

            SetMultiSampleCount(8);

            Editor.FPSCounter.SetDisplayStyle = Forms.NET.Components.FPSCounter.DisplayStyle.TopLeft;
            Editor.FPSCounter.ShowCursorPosition = false;
            Editor.FPSCounter.ShowFPS = false;

            OnMouseWheelUpwards += PolygonSplineControl_OnMouseWheelUpwards;
            OnMouseWheelDownwards += PolygonSplineControl_OnMouseWheelDownwards;
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Editor.Camera.GetTransform();
            Functions.UpdateProjectionViewMatrix(Editor.Camera.Position, Editor.Camera.GetZoom());

            MySpline.CreatePolygonStripe();
        }

        protected override void Draw()
        {
            if (Editor != null)
            {
                Editor.BeginAntialising();

                if (MySpline != null) MySpline.DrawPolygonStripe();

                Editor.spriteBatch.Begin(effect: Functions.GetBasicEffect);

                if (MySpline != null) MySpline.Draw(Editor.spriteBatch);                    

                Editor.spriteBatch.End();

                Editor.EndAntialising();
            }
        }
        
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Right)
            {
                if (MySpline.SelectTransform(new Vector2(e.X, e.Y)) != null && !MySpline.SelectedTransform.IsCenter)
                {
                    SplineBase.ControlPointMode nextMode = MySpline.GetControlPointMode(MySpline.SelectedTransform.Index).Next();
                    MySpline.SetControlPointMode(MySpline.SelectedTransform.Index, nextMode);
                }
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (MySpline.SelectedTransform != null) MySpline.EnforceMode(MySpline.SelectedTransform.Index);
        }
        private void PolygonSplineControl_OnMouseWheelUpwards(MouseEventArgs e)
        {
            if (IsMouseInsideControlArea(
                0,
                0,
                Editor.GraphicsDevice.Viewport.Width,
                Editor.GraphicsDevice.Viewport.Height))
            {
                var zoomFactor = (float)Math.Pow(Math.E, 0.05f * 1);
                Editor.Camera.Zoom(Math.Min(Math.Max(zoomFactor * Editor.Camera.GetZoom(), 0.02f), 2f));
            }
        }
        private void PolygonSplineControl_OnMouseWheelDownwards(MouseEventArgs e)
        {
            if (IsMouseInsideControlArea(
                0,
                0,
                Editor.GraphicsDevice.Viewport.Width,
                Editor.GraphicsDevice.Viewport.Height))
            {
                var zoomFactor = (float)Math.Pow(Math.E, 0.05f * -1);
                Editor.Camera.Zoom(Math.Min(Math.Max(zoomFactor * Editor.Camera.GetZoom(), 0.02f), 2f));
            }
        }
    }
}
