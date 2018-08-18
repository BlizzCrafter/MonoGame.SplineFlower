using System;
using System.Windows.Forms;

namespace SplineSharp.Samples
{
    public partial class SplineEditorForm : Form
    {
        public SplineEditorForm()
        {
            InitializeComponent();
        }

        private void SplineEditorForm_Load(object sender, EventArgs e)
        {
            comboBoxWalkerMode.SelectedIndex = 0;            
        }

        private void buttonAddCurve_Click(object sender, EventArgs e)
        {
            splineControl.MySpline.AddCurveLeft();
        }

        private void buttonAddCurveRight_Click(object sender, EventArgs e)
        {
            splineControl.MySpline.AddCurveRight();
        }

        private void buttonLoop_Click(object sender, EventArgs e)
        {
            splineControl.MySpline.Loop = true;
            buttonLoop.Enabled = false;
        }

        private void buttonResetSplineWalker_Click(object sender, EventArgs e)
        {
            splineControl.MySplineWalker.Reset();
        }

        private void comboBoxWalkerMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (splineControl.MySplineWalker != null && 
                splineControl.MySplineWalker.Initialized)
            {
                splineControl.MySplineWalker.Mode = (SplineWalker.SplineWalkerMode)comboBoxWalkerMode.SelectedIndex;
            }
        }

        private void toolStripMenuItemCenterPoints_Click(object sender, EventArgs e)
        {
            if (lineControl.Visible) lineControl.MoveSplineToScreenCenter();
            else if (curveControlQuadratic.Visible) curveControlQuadratic.MoveSplineToScreenCenter();
            else if (curveControlCubic.Visible) curveControlCubic.MoveSplineToScreenCenter();
            else if (splineControl.Visible) splineControl.MoveSplineToScreenCenter();
        }

        private void SplineEditorForm_ResizeEnd(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void SplineEditorForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized) UpdateControls();
        }
        private void UpdateControls()
        {
            lineControl.LineControl_RecalculateBezierCenter();
            lineControl.MoveSplineToScreenCenter();

            curveControlQuadratic.CurveControl_RecalculateBezierCenter();
            curveControlQuadratic.MoveSplineToScreenCenter();

            curveControlCubic.CurveControl_RecalculateBezierCenter();
            curveControlCubic.MoveSplineToScreenCenter();

            splineControl.SplineControl_RecalculateBezierCenter();
            splineControl.MoveSplineToScreenCenter();
        }

        private void trackBarMarker_Scroll(object sender, EventArgs e)
        {
            float splineValue = (float)trackBarMarker.Value / 1000f;
            splineControl.MySplineMarker.SetPosition(splineValue);
        }
    }
}
