using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.SplineFlower.Spline;
using MonoGame.SplineFlower.Spline.Types;
using MonoGame.SplineFlower.Utils;
using MonoGame.SplineFlower.Content;
using System;
using System.Windows.Forms;

namespace MonoGame.SplineFlower.Samples.Controls
{
    public class PolygonSplineControl : TransformControl
    {
        public CatMulRomSpline MySpline;

        protected override void Initialize()
        {
            base.Initialize();

            Setup.Initialize(Editor.graphics);
            Setup.ShowCurves = false;
            UseWorldUnits = true;

            MySpline = new CatMulRomSpline();
            MySpline.PolygonStripeTexture = Editor.Content.Load<Texture2D>("roadTexture");
            MySpline.Loop = true;            
            GetSpline = MySpline;

            CenterSpline();            

            SetMultiSampleCount(8);

            Editor.SetDisplayStyle = Forms.Services.GFXService.DisplayStyle.TopRight;
            Editor.ShowCursorPosition = false;
            Editor.ShowFPS = false;

            OnMouseWheelUpwards += PolygonSplineControl_OnMouseWheelUpwards;
            OnMouseWheelDownwards += PolygonSplineControl_OnMouseWheelDownwards;
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Editor.Cam.GetTransformation(GraphicsDevice);
            Functions.UpdateProjectionViewMatrix(Editor.Cam.AbsolutPosition, Editor.Cam.Zoom);

            MySpline.CreatePolygonStripe();
        }

        protected override void Draw()
        {
            base.Draw();

            if (Editor != null)
            {
                Editor.BeginAntialising();

                if (MySpline != null) MySpline.DrawPolygonStripe();

                Editor.spriteBatch.Begin(effect: Functions.GetBasicEffect);

                if (MySpline != null) MySpline.DrawSpline(Editor.spriteBatch);

                Editor.spriteBatch.End();

                Editor.EndAntialising();
                Editor.DrawDisplay();
            }
        }
        
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Right)
            {
                if (GetSpline.SelectTransform(new Vector2(e.X, e.Y)) != null && !GetSpline.SelectedTransform.IsCenter)
                {
                    SplineBase.ControlPointMode nextMode = MySpline.GetControlPointMode(GetSpline.SelectedTransform.Index).Next();
                    MySpline.SetControlPointMode(GetSpline.SelectedTransform.Index, nextMode);
                }
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (GetSpline.SelectedTransform != null) MySpline.EnforceMode(GetSpline.SelectedTransform.Index);
        }
        private void PolygonSplineControl_OnMouseWheelUpwards(MouseEventArgs e)
        {
            if (IsMouseInsideControlArea(
                0,
                0,
                Editor.graphics.Viewport.Width,
                Editor.graphics.Viewport.Height))
            {
                var zoomFactor = (float)Math.Pow(Math.E, 0.05f * 1);
                Editor.Cam.Zoom = Math.Min(Math.Max(zoomFactor * Editor.Cam.Zoom, 0.02f), 2f);
            }
        }
        private void PolygonSplineControl_OnMouseWheelDownwards(MouseEventArgs e)
        {
            if (IsMouseInsideControlArea(
                0,
                0,
                Editor.graphics.Viewport.Width,
                Editor.graphics.Viewport.Height))
            {
                var zoomFactor = (float)Math.Pow(Math.E, 0.05f * -1);
                Editor.Cam.Zoom = Math.Min(Math.Max(zoomFactor * Editor.Cam.Zoom, 0.02f), 2f);
            }
        }
    }
}
