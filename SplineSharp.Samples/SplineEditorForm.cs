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
    }
}
