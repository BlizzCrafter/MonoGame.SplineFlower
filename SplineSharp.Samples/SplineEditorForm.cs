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
    }
}
