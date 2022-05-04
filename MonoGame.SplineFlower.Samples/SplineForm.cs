using MonoGame.SplineFlower.Content;
using MonoGame.SplineFlower.Samples.Controls;
using MonoGame.SplineFlower.Spline.Types;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonoGame.SplineFlower.Samples
{
    public partial class SplineForm : Form
    {
        private TransformControl CurrentTransformControl
        {
            get
            {
                foreach (Control control in tabControlEditorTabs.SelectedTab.Controls)
                {
                    if (control is TransformControl)
                    {
                        return control as TransformControl;
                    }
                }
                return null;
            }
        }

        private void toolStripDropDownButtonTwitter_Click(object sender, EventArgs e)
        {
            Process.Start("https://twitter.com/blizz_crafter");
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

            CurrentTransformControl.InitializeSplineControlSample();
        }

        private void tabControlEditorTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentTransformControl?.InitializeSplineControlSample();
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
                if (!buttonLoopFindTest.Enabled && findNearestPointControl1.MySpline.Loop)
                {
                    CreateFindNearestPointSplines();
                    buttonLoopFindTest.Enabled = true;
                }
                else CreateFindNearestPointSplines();
            }
        }
        private void CreateFindNearestPointSplines()
        {
            if (findNearestPointControl1.MySpline is BezierSpline)
            {
                findNearestPointControl1.CreateCatMulRomSpline();
                buttonCatMulRomFindTest.Text = "Bezier";
            }
            else
            {
                findNearestPointControl1.CreateBezierSpline();
                buttonCatMulRomFindTest.Text = "CatMulRom";
            }
        }

        private void numericUpDownAccuracy_ValueChanged(object sender, EventArgs e)
        {
            if (findNearestPointControl1 != null && findNearestPointControl1.MySpline != null)
            {
                Setup.SetSplineMarkerResolution((float)numericUpDownAccuracy.Value);
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
                catMulRomSpline.SplineControl_RecalculateSplineCenter();
                catMulRomSpline.CenterSpline();
            }

            if (splineControl != null)
            {
                splineControl.SplineControl_RecalculateSplineCenter();
                splineControl.CenterSpline();
            }
        }

        private void SplineEditorForm_ResizeEnd(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please edit the Initialization method of the AdvancedControls.cs file to experience all the new ipnut features!\n\nKeyboard Forward: W, D, Up, Right\nKeyboard Backward: S, A, Down, Left\n\nGamePad Forward: DPadUp, DPadRight, RightTrigger, LeftThumbstickUp LeftThumbstickRight\nGamePad Backward: DPadDown, DPadLeft, LeftTrigger, LeftThumbstickDown, LeftThumbstickLeft", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonPolygonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("'Track Tiles' © Copyright by TRBRY @ opengameart.org CC - BY 3.0\n\nhttps://opengameart.org/content/track-tiles", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonAddTension_Click(object sender, EventArgs e)
        {
            ((HermiteSpline)hermiteSplineControl.MySpline).AddTension();
        }

        private void buttonSubstractTension_Click(object sender, EventArgs e)
        {
            ((HermiteSpline)hermiteSplineControl.MySpline).SubstractTension();
        }

        private void buttonAddBias_Click(object sender, EventArgs e)
        {
            ((HermiteSpline)hermiteSplineControl.MySpline).AddBias();
        }

        private void buttonSubstractBias_Click(object sender, EventArgs e)
        {
            ((HermiteSpline)hermiteSplineControl.MySpline).SubstractBias();
        }

        private void checkBoxShowCurves_CheckedChanged(object sender, EventArgs e)
        {
            Setup.ShowCurves = checkBoxShowCurves.Checked;
        }

        private void checkBoxDirectionVectors_CheckedChanged(object sender, EventArgs e)
        {
            Setup.ShowDirectionVectors = checkBoxDirectionVectors.Checked;
        }

        private void checkBoxShowLines_CheckedChanged(object sender, EventArgs e)
        {
            Setup.ShowLines = checkBoxShowLines.Checked;
        }

        private void checkBoxShowPoints_CheckedChanged(object sender, EventArgs e)
        {
            Setup.ShowPoints = checkBoxShowPoints.Checked;
        }

        private void buttonRotatePlus_Click(object sender, EventArgs e)
        {
            chainSplineControl.RotatePlus();
        }

        private void buttonRotateMinus_Click(object sender, EventArgs e)
        {
            chainSplineControl.RotateMinus();
        }

        private void buttonRotateStop_Click(object sender, EventArgs e)
        {
            chainSplineControl.RotateStop();
        }

        private void numericUpDownResolution_ValueChanged(object sender, EventArgs e)
        {
            Setup.SetSplineMarkerResolution((float)((NumericUpDown)sender).Value);
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            chainSplineControl.CreateSpline((int)numericUpDownCurveCount.Value);
        }
    }
}
