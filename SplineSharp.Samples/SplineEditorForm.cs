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

        private void toolStripButtonAddPoint_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void buttonAddCurve_Click(object sender, EventArgs e)
        {
            splineEditorBezierSpline.MySpline.AddCurveLeft();
        }

        private void buttonAddCurveRight_Click(object sender, EventArgs e)
        {
            splineEditorBezierSpline.MySpline.AddCurveRight();
        }

        private void buttonLoop_Click(object sender, EventArgs e)
        {
            splineEditorBezierSpline.MySpline.Loop = true;
            buttonLoop.Enabled = false;
        }

        private void buttonResetSplineWalker_Click(object sender, EventArgs e)
        {
            splineEditorBezierSpline.MySplineWalker.Reset();
        }

        private void comboBoxWalkerMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (splineEditorBezierSpline.MySplineWalker != null && splineEditorBezierSpline.MySplineWalker.Initialized)
            {
                if (comboBoxWalkerMode.SelectedIndex == 0) splineEditorBezierSpline.MySplineWalker.Mode = SplineWalker.SplineWalkerMode.Once;
                else if (comboBoxWalkerMode.SelectedIndex == 1) splineEditorBezierSpline.MySplineWalker.Mode = SplineWalker.SplineWalkerMode.Loop;
                else if (comboBoxWalkerMode.SelectedIndex == 2) splineEditorBezierSpline.MySplineWalker.Mode = SplineWalker.SplineWalkerMode.PingPong;
            }
        }
    }
}
