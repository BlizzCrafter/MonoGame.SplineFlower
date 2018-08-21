using System;
using System.Windows.Forms;

namespace MonoGame.SplineFlower.Samples
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
            comboBoxEvents.SelectedIndex = 0;
            comboBoxSelectedTrigger.SelectedIndex = 0;
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
            splineControl.MySplineMarker.SetPosition(GetSplinePosition());
        }
        private float GetSplinePosition()
        {
            return (float)trackBarMarker.Value / Setup.SplineMarkerResolution;
        }

        private void buttonAddEvent_Click(object sender, EventArgs e)
        {
            Guid triggerID = splineControl.MySplineWalker.AddTrigger(
                comboBoxEvents.SelectedItem.ToString(), 
                GetSplinePosition(), 
                (int)numericUpDownTriggerRange.Value);

            comboBoxSelectedTrigger.Items.Add(GetSelectedTriggerString(comboBoxEvents.SelectedItem.ToString(), triggerID.ToString()));
        }
        private string GetSelectedTriggerString(string itemName, string itemID)
        {
            return itemName + "_" + itemID;
        }

        private void comboBoxSelectedTrigger_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (splineControl != null && splineControl.MySplineMarker != null)
            {
                if (comboBoxSelectedTrigger.SelectedItem.ToString() != "Marker")
                {
                    splineControl.MySplineMarker.MarkerSelected = false;

                    string[] splitted = comboBoxSelectedTrigger.SelectedItem.ToString().Split('_');
                    splineControl.MySplineMarker.SelectedTrigger = splitted[1];
                    UpdateTriggerInterface(splineControl.MySplineWalker.GetTrigger(splitted[1]));
                }
                else splineControl.MySplineMarker.MarkerSelected = true;

                splineControl.MySplineMarker.SetPosition(GetSplinePosition());
            }
        }
        private void UpdateTriggerInterface(Trigger trigger)
        {
            trackBarMarker.Value = (int)(trigger.Progress * Setup.SplineMarkerResolution);
            numericUpDownTriggerRange.Value = (int)(trigger.TriggerDistance * Setup.SplineMarkerResolution);
        }

        private void numericUpDownTriggerRange_ValueChanged(object sender, EventArgs e)
        {
            if (splineControl != null && splineControl.MySplineMarker != null)
            {
                if (!splineControl.MySplineMarker.MarkerSelected)
                {
                    Trigger trigger = splineControl.MySplineMarker.GetTrigger();
                    trigger.TriggerDistance = (int)numericUpDownTriggerRange.Value;
                }
            }
        }

        private void trackBarMarker_MouseDown(object sender, MouseEventArgs e)
        {
            if (splineControl != null &&
                splineControl.MySplineMarker != null &&
                splineControl.MySplineMarker.Initialized)
            {
                if (!splineControl.MySplineMarker.MarkerSelected) splineControl.MySplineWalker.Stop = true;
            }
        }

        private void trackBarMarker_MouseUp(object sender, MouseEventArgs e)
        {
            if (splineControl != null &&
                splineControl.MySplineMarker != null &&
                splineControl.MySplineMarker.Initialized)
            {
                if (!splineControl.MySplineMarker.MarkerSelected)
                {
                    splineControl.ReorderTriggerList();
                    splineControl.MySplineWalker.Stop = false;
                }
            }
        }

        private void splineControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (splineControl != null && splineControl.SelectedTrigger != null)
            {
                if (splineControl.MySplineMarker != null && splineControl.MySplineMarker.Initialized)
                {
                    splineControl.MySplineMarker.SelectedTrigger = splineControl.SelectedTrigger.ID.ToString();
                    comboBoxSelectedTrigger.SelectedItem = GetSelectedTriggerString(
                        splineControl.SelectedTrigger.Name,
                        splineControl.SelectedTrigger.ID.ToString());
                }

                UpdateTriggerInterface(splineControl.SelectedTrigger);
                splineControl.SelectedTrigger = null;
            }
        }
    }
}
