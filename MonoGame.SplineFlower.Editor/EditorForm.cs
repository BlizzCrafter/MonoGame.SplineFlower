using MonoGame.SplineFlower.Samples;
using System;
using System.Windows.Forms;

namespace MonoGame.SplineFlower.Editor
{
    public partial class FormEditor : Form
    {
        #region Diagnostics
        
        private void toolStripMenuItemCenterSpline_Click(object sender, EventArgs e)
        {
            splineControl.MoveSplineToScreenCenter();
        }

        private void toolStripMenuItemDrawSpline_CheckedChanged(object sender, EventArgs e)
        {
            Setup.ShowBezierSpline = toolStripMenuItemDrawSpline.Checked;
        }

        private void toolStripMenuItemDrawBaseLine_CheckedChanged(object sender, EventArgs e)
        {
            Setup.ShowBaseLine = toolStripMenuItemDrawBaseLine.Checked;
        }

        private void toolStripMenuItemDrawCurves_CheckedChanged(object sender, EventArgs e)
        {
            Setup.ShowCurves = toolStripMenuItemDrawCurves.Checked;
        }

        private void toolStripMenuItemDrawDirections_CheckedChanged(object sender, EventArgs e)
        {
            Setup.ShowDirectionVectors = toolStripMenuItemDrawDirections.Checked;
        }

        private void toolStripMenuItemDrawTrigger_CheckedChanged(object sender, EventArgs e)
        {
            Setup.ShowTriggers = toolStripMenuItemDrawTrigger.Checked;
        }

        private void toolStripMenuItemDrawSplineWalker_CheckedChanged(object sender, EventArgs e)
        {
            Setup.ShowSplineWalker = toolStripMenuItemDrawSplineWalker.Checked;
        }

        private void toolStripMenuItemDrawMarker_Click(object sender, EventArgs e)
        {
            Marker.ShowSplineMarker = toolStripMenuItemDrawMarker.Checked;
        }

        private void toolStripMenuItemDrawCar_CheckedChanged(object sender, EventArgs e)
        {
            Car.ShowCar = toolStripMenuItemDrawCar.Checked;
        }

        #endregion
        
        #region Spline Actions

        private void toolStripButtonAddCurveLeft_Click(object sender, EventArgs e)
        {
            splineControl.MySpline.AddCurveLeft();
        }

        private void toolStripButtonAddCurveRight_Click(object sender, EventArgs e)
        {
            splineControl.MySpline.AddCurveRight();
        }

        private void toolStripButtonTrackLoop_Click(object sender, EventArgs e)
        {
            splineControl.MySpline.Loop = true;
            toolStripButtonTrackLoop.Enabled = false;
        }

        #endregion

        #region Spline Walker
        

        private void toolStripButtonResetSplineWalker_Click(object sender, EventArgs e)
        {
            splineControl.MySplineWalker.Reset();
        }

        private void toolStripComboBoxWalkerMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            splineControl.MySplineWalker.Mode = (SplineWalker.SplineWalkerMode)toolStripComboBoxWalkerMode.SelectedIndex;
        }

        #endregion

        #region TriggerEvents

        private void toolStripComboBoxSelectedTrigger_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (splineControl != null && splineControl.MySplineMarker != null)
            {
                if (toolStripComboBoxSelectedTrigger.SelectedItem.ToString() != "Marker")
                {
                    splineControl.MySplineMarker.MarkerSelected = false;

                    string[] splitted = toolStripComboBoxSelectedTrigger.SelectedItem.ToString().Split('_');
                    splineControl.MySplineMarker.SelectedTrigger = splitted[1];
                    UpdateTriggerInterface(splineControl.MySplineWalker.GetTrigger(splitted[1]));
                }
                else splineControl.MySplineMarker.MarkerSelected = true;

                splineControl.MySplineMarker.SetPosition(GetSplinePosition());
            }
        }

        private void toolStripButtonAddEvent_Click(object sender, EventArgs e)
        {
            Guid triggerID = splineControl.MySplineWalker.AddTrigger(
                toolStripComboBoxEvents.SelectedItem.ToString(),
                GetSplinePosition(),
                (int)toolStripNumericUpDownTriggerRange.Value);

            toolStripComboBoxSelectedTrigger.Items.Add(GetSelectedTriggerString(toolStripComboBoxEvents.SelectedItem.ToString(), triggerID.ToString()));
        }

        private void toolStripNumericUpDownTriggerRange_ValueChanged(object sender, EventArgs e)
        {
            if (splineControl != null && splineControl.MySplineMarker != null)
            {
                if (!splineControl.MySplineMarker.MarkerSelected)
                {
                    Trigger trigger = splineControl.MySplineMarker.GetTrigger();
                    trigger.TriggerDistance = (int)toolStripNumericUpDownTriggerRange.Value;
                }
            }
        }

        private void UpdateTriggerInterface(Trigger trigger)
        {
            trackBarMarker.Value = (int)(trigger.Progress * Setup.SplineMarkerResolution);
            toolStripNumericUpDownTriggerRange.Value = (int)(trigger.TriggerDistance * Setup.SplineMarkerResolution);
        }

        private string GetSelectedTriggerString(string itemName, string itemID)
        {
            return itemName + "_" + itemID;
        }

        #endregion

        #region TrackBar
        
        private void trackBarMarker_Scroll(object sender, EventArgs e)
        {
            splineControl.MySplineMarker.SetPosition(GetSplinePosition());
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

        private float GetSplinePosition()
        {
            return (float)trackBarMarker.Value / Setup.SplineMarkerResolution;
        }

        #endregion

        public FormEditor()
        {
            InitializeComponent();
        }

        private void FormEditor_Load(object sender, EventArgs e)
        {
            toolStripComboBoxEvents.SelectedIndex = 0;
            toolStripComboBoxSelectedTrigger.SelectedIndex = 0;
            toolStripComboBoxWalkerMode.SelectedIndex = 0;
        }

        private void FormEditor_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized) UpdateControls();
        }

        private void FormEditor_ResizeEnd(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void splineControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (splineControl != null && splineControl.SelectedTrigger != null)
            {
                if (splineControl.MySplineMarker != null && splineControl.MySplineMarker.Initialized)
                {
                    splineControl.MySplineMarker.SelectedTrigger = splineControl.SelectedTrigger.ID.ToString();
                    toolStripComboBoxSelectedTrigger.SelectedItem = GetSelectedTriggerString(
                        splineControl.SelectedTrigger.Name,
                        splineControl.SelectedTrigger.ID.ToString());
                }

                UpdateTriggerInterface(splineControl.SelectedTrigger);
                splineControl.SelectedTrigger = null;
            }
        }        

        private void UpdateControls()
        {
            splineControl.SplineControl_RecalculateBezierCenter();
            splineControl.MoveSplineToScreenCenter();
        }
    }
}
