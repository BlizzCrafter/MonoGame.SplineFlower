using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace MonoGame.SplineFlower.Samples
{
    public partial class SplineForm : Form
    {
        private void toolStripDropDownButtonTwitter_Click(object sender, EventArgs e)
        {
            Process.Start("https://twitter.com/sqrMin1");
        }

        private void toolStripDropDownButtonGitHub_Click(object sender, EventArgs e)
        {

        }

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
                splineControl.MySplineWalker.WalkerMode = (SplineWalker.SplineWalkerMode)comboBoxWalkerMode.SelectedIndex;
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

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please edit the Initialization method of the AdvancedControls.cs file to experience all the new ipnut features!\n\nKeyboard Forward: W, D, Up, Right\nKeyboard Backward: S, A, Down, Left\n\nGamePad Forward: DPadUp, DPadRight, RightTrigger, LeftThumbstickUp LeftThumbstickRight\nGamePad Backward: DPadDown, DPadLeft, LeftTrigger, LeftThumbstickDown, LeftThumbstickLeft\n\nTop down vehicle © Copyright by irmirx @ opengameart.org CC-BY 3.0", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
