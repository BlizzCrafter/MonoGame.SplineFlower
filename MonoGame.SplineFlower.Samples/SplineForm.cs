using System;
using System.Windows.Forms;

namespace MonoGame.SplineFlower.Samples
{
    public partial class SplineForm : Form
    {
        public SplineForm()
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

        private void SplineEditorForm_ResizeEnd(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void splineControl_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}
