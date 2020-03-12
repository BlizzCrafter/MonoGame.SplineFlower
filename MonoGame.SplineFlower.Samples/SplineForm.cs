using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace MonoGame.SplineFlower.Samples
{
    public partial class SplineForm : Form
    {
        private void toolStripDropDownButtonTwitter_Click(object sender, EventArgs e)
        {
            Process.Start("https://twitter.com/SandboxBlizz");
        }

        private void toolStripDropDownButtonGitHub_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/sqrMin1/MonoGame.SplineFlower");
        }

        public SplineForm()
        {
            InitializeComponent();
        }

        private void SplineEditorForm_Load(object sender, EventArgs e)
        {
            comboBoxWalkerMode.SelectedIndex = 0;
            comboBoxCenterTransformMode.SelectedIndex = 3;
            comboBoxCenterTransformMode_2.SelectedIndex = 3;
        }

        private void buttonAddCurve_Click(object sender, EventArgs e)
        {
            if (splineControl != null && splineControl.MySpline != null) splineControl.MySpline.AddCurveLeft();
        }

        private void buttonAddCurveRight_Click(object sender, EventArgs e)
        {
            if (splineControl != null && splineControl.MySpline != null) splineControl.MySpline.AddCurveRight();
        }

        private void buttonLoop_Click(object sender, EventArgs e)
        {
            if (splineControl != null && splineControl.MySpline != null)
            {
                splineControl.MySpline.Loop = true;
                buttonLoop.Enabled = false;
            }
        }

        private void buttonResetSplineWalker_Click(object sender, EventArgs e)
        {
            if (splineControl != null &&
                splineControl.MySplineWalker != null &&
                splineControl.MySplineWalker.Initialized)
            {
                splineControl.MySplineWalker.Reset();
            }
        }

        private void comboBoxWalkerMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (splineControl != null &&
                splineControl.MySplineWalker != null &&
                splineControl.MySplineWalker.Initialized)
            {
                splineControl.MySplineWalker.WalkerMode = (SplineWalker.SplineWalkerMode)comboBoxWalkerMode.SelectedIndex;
            }
        }

        private void comboBoxCenterTransformMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (splineControl != null &&
                splineControl.MySplineWalker != null &&
                splineControl.MySplineWalker.Initialized)
            {
                splineControl.SetCenterTransformMode = (Controls.TransformControl.CenterTransformMode)comboBoxCenterTransformMode.SelectedIndex;
            }
        }

        private void comboBoxCenterTransformMode_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (catMulRomSpline != null &&
                catMulRomSpline.MySplineWalker != null &&
                catMulRomSpline.MySplineWalker.Initialized)
            {
                catMulRomSpline.SetCenterTransformMode = (Controls.TransformControl.CenterTransformMode)comboBoxCenterTransformMode_2.SelectedIndex;
            }
        }

        private void buttonLoopFindTest_Click(object sender, EventArgs e)
        {
            if (findNearestPointControl1 != null && findNearestPointControl1.MySpline != null)
            {
                findNearestPointControl1.MySpline.Loop = true;
                buttonLoopFindTest.Enabled = false;
            }
        }

        private void buttonCatMulRomFindTest_Click(object sender, EventArgs e)
        {
            if (findNearestPointControl1 != null && findNearestPointControl1.MySpline != null)
            {
                findNearestPointControl1.MySpline.CatMulRom = true;
                buttonCatMulRomFindTest.Enabled = false;
            }
        }

        private void numericUpDownAccuracy_ValueChanged(object sender, EventArgs e)
        {
            if (findNearestPointControl1 != null && findNearestPointControl1.MySpline != null)
            {
                findNearestPointControl1.NearestPointAccuracy = (float)numericUpDownAccuracy.Value;
            }
        }

        private void SplineEditorForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized) UpdateControls();
        }
        private void UpdateControls()
        {
            if (catMulRomSpline != null)
            {
                catMulRomSpline.SplineControl_RecalculateBezierCenter();
                catMulRomSpline.MoveSplineToScreenCenter();
            }

            if (splineControl != null)
            {
                splineControl.SplineControl_RecalculateBezierCenter();
                splineControl.MoveSplineToScreenCenter();
            }
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
