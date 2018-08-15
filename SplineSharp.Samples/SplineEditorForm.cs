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

        private void toolStripButtonAddPoint_CheckedChanged(object sender, EventArgs e)
        {
            splineEditorLine.AddPointsMode = toolStripButtonAddPoint.Checked;
            splineEditorCurve.AddPointsMode = toolStripButtonAddPoint.Checked;
            splineEditorCurveCubic.AddPointsMode = toolStripButtonAddPoint.Checked;
            splineEditorBezierSpline.AddPointsMode = toolStripButtonAddPoint.Checked;
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
        }

        private void buttonResetSplineWalker_Click(object sender, EventArgs e)
        {
            splineEditorBezierSpline.MySplineWalker.Reset();
        }
    }
}
