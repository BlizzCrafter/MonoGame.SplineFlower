namespace MonoGame.SplineFlower.Editor
{
    partial class FormEditor
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.trackBarMarker = new System.Windows.Forms.TrackBar();
            this.toolStripToolBar = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBoxWalkerMode = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBoxSelectedTrigger = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripComboBoxEvents = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripNumericUpDownTriggerRange = new MonoGame.SplineFlower.Editor.Controls.ToolStrip.ToolStripNumericUpDown();
            this.splineControl = new MonoGame.SplineFlower.Samples.Controls.SplineControl();
            this.menuStripMainMenu = new System.Windows.Forms.MenuStrip();
            this.toolStripButtonAddCurveLeft = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAddCurveRight = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTrackLoop = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonResetSplineWalker = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAddEvent = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabelSelected = new System.Windows.Forms.ToolStripLabel();
            this.toolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDiagnostics = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCenterSpline = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemDrawSpline = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemDrawBaseLine = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDrawCurves = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDrawDirections = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDrawTrigger = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemDrawMarker = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDrawSplineWalker = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDrawCar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExportJson = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemImportJson = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMarker)).BeginInit();
            this.toolStripToolBar.SuspendLayout();
            this.menuStripMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackBarMarker
            // 
            this.trackBarMarker.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.trackBarMarker.LargeChange = 10;
            this.trackBarMarker.Location = new System.Drawing.Point(0, 497);
            this.trackBarMarker.Maximum = 1000;
            this.trackBarMarker.Name = "trackBarMarker";
            this.trackBarMarker.Size = new System.Drawing.Size(782, 56);
            this.trackBarMarker.TabIndex = 12;
            this.trackBarMarker.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarMarker.Scroll += new System.EventHandler(this.trackBarMarker_Scroll);
            this.trackBarMarker.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarMarker_MouseDown);
            this.trackBarMarker.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarMarker_MouseUp);
            // 
            // toolStripToolBar
            // 
            this.toolStripToolBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddCurveLeft,
            this.toolStripButtonAddCurveRight,
            this.toolStripButtonTrackLoop,
            this.toolStripSeparator1,
            this.toolStripButtonResetSplineWalker,
            this.toolStripComboBoxWalkerMode,
            this.toolStripSeparator2,
            this.toolStripComboBoxSelectedTrigger,
            this.toolStripButtonAddEvent,
            this.toolStripComboBoxEvents,
            this.toolStripNumericUpDownTriggerRange,
            this.toolStripLabelSelected});
            this.toolStripToolBar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStripToolBar.Location = new System.Drawing.Point(0, 28);
            this.toolStripToolBar.Name = "toolStripToolBar";
            this.toolStripToolBar.Size = new System.Drawing.Size(782, 28);
            this.toolStripToolBar.Stretch = true;
            this.toolStripToolBar.TabIndex = 21;
            this.toolStripToolBar.Text = "Tool Bar";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripComboBoxWalkerMode
            // 
            this.toolStripComboBoxWalkerMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxWalkerMode.Items.AddRange(new object[] {
            "Once",
            "Loop",
            "PingPong"});
            this.toolStripComboBoxWalkerMode.MaxDropDownItems = 3;
            this.toolStripComboBoxWalkerMode.Name = "toolStripComboBoxWalkerMode";
            this.toolStripComboBoxWalkerMode.Size = new System.Drawing.Size(121, 28);
            this.toolStripComboBoxWalkerMode.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxWalkerMode_SelectedIndexChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripComboBoxSelectedTrigger
            // 
            this.toolStripComboBoxSelectedTrigger.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripComboBoxSelectedTrigger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxSelectedTrigger.DropDownWidth = 400;
            this.toolStripComboBoxSelectedTrigger.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripComboBoxSelectedTrigger.Items.AddRange(new object[] {
            "Marker"});
            this.toolStripComboBoxSelectedTrigger.MaxDropDownItems = 3;
            this.toolStripComboBoxSelectedTrigger.Name = "toolStripComboBoxSelectedTrigger";
            this.toolStripComboBoxSelectedTrigger.Size = new System.Drawing.Size(200, 28);
            this.toolStripComboBoxSelectedTrigger.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxSelectedTrigger_SelectedIndexChanged);
            // 
            // toolStripComboBoxEvents
            // 
            this.toolStripComboBoxEvents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxEvents.Items.AddRange(new object[] {
            "Horn",
            "Brakes",
            "Counter"});
            this.toolStripComboBoxEvents.MaxDropDownItems = 3;
            this.toolStripComboBoxEvents.Name = "toolStripComboBoxEvents";
            this.toolStripComboBoxEvents.Size = new System.Drawing.Size(121, 28);
            // 
            // toolStripNumericUpDownTriggerRange
            // 
            this.toolStripNumericUpDownTriggerRange.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripNumericUpDownTriggerRange.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.toolStripNumericUpDownTriggerRange.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.toolStripNumericUpDownTriggerRange.Name = "toolStripNumericUpDownTriggerRange";
            this.toolStripNumericUpDownTriggerRange.Size = new System.Drawing.Size(52, 25);
            this.toolStripNumericUpDownTriggerRange.Text = "3";
            this.toolStripNumericUpDownTriggerRange.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.toolStripNumericUpDownTriggerRange.ValueChanged += new System.EventHandler(this.toolStripNumericUpDownTriggerRange_ValueChanged);
            // 
            // splineControl
            // 
            this.splineControl.BackColor = System.Drawing.Color.Yellow;
            this.splineControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splineControl.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splineControl.GetAllPoints = null;
            this.splineControl.Location = new System.Drawing.Point(0, 56);
            this.splineControl.Name = "splineControl";
            this.splineControl.SelectedTrigger = null;
            this.splineControl.Size = new System.Drawing.Size(782, 441);
            this.splineControl.TabIndex = 0;
            this.splineControl.Text = "Bézier Spline Editor";
            this.splineControl.TryGetTransformFromPosition = null;
            this.splineControl.TryGetTriggerFromPosition = null;
            this.splineControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.splineControl_MouseUp);
            // 
            // menuStripMainMenu
            // 
            this.menuStripMainMenu.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStripMainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFile,
            this.toolStripMenuItemDiagnostics});
            this.menuStripMainMenu.Location = new System.Drawing.Point(0, 0);
            this.menuStripMainMenu.Name = "menuStripMainMenu";
            this.menuStripMainMenu.Size = new System.Drawing.Size(782, 28);
            this.menuStripMainMenu.TabIndex = 22;
            this.menuStripMainMenu.Text = "Main Menu";
            // 
            // toolStripButtonAddCurveLeft
            // 
            this.toolStripButtonAddCurveLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddCurveLeft.Image = global::MonoGame.SplineFlower.Editor.Properties.Resources._011;
            this.toolStripButtonAddCurveLeft.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonAddCurveLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddCurveLeft.Name = "toolStripButtonAddCurveLeft";
            this.toolStripButtonAddCurveLeft.Size = new System.Drawing.Size(23, 25);
            this.toolStripButtonAddCurveLeft.Text = "Add Curve Left";
            this.toolStripButtonAddCurveLeft.Click += new System.EventHandler(this.toolStripButtonAddCurveLeft_Click);
            // 
            // toolStripButtonAddCurveRight
            // 
            this.toolStripButtonAddCurveRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddCurveRight.Image = global::MonoGame.SplineFlower.Editor.Properties.Resources._013;
            this.toolStripButtonAddCurveRight.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonAddCurveRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddCurveRight.Name = "toolStripButtonAddCurveRight";
            this.toolStripButtonAddCurveRight.Size = new System.Drawing.Size(23, 25);
            this.toolStripButtonAddCurveRight.Text = "Add Curve Right";
            this.toolStripButtonAddCurveRight.Click += new System.EventHandler(this.toolStripButtonAddCurveRight_Click);
            // 
            // toolStripButtonTrackLoop
            // 
            this.toolStripButtonTrackLoop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonTrackLoop.Image = global::MonoGame.SplineFlower.Editor.Properties.Resources._051;
            this.toolStripButtonTrackLoop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonTrackLoop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTrackLoop.Name = "toolStripButtonTrackLoop";
            this.toolStripButtonTrackLoop.Size = new System.Drawing.Size(23, 25);
            this.toolStripButtonTrackLoop.Text = "Track Loop";
            this.toolStripButtonTrackLoop.Click += new System.EventHandler(this.toolStripButtonTrackLoop_Click);
            // 
            // toolStripButtonResetSplineWalker
            // 
            this.toolStripButtonResetSplineWalker.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonResetSplineWalker.Image = global::MonoGame.SplineFlower.Editor.Properties.Resources._029;
            this.toolStripButtonResetSplineWalker.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonResetSplineWalker.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonResetSplineWalker.Name = "toolStripButtonResetSplineWalker";
            this.toolStripButtonResetSplineWalker.Size = new System.Drawing.Size(23, 25);
            this.toolStripButtonResetSplineWalker.Text = "Reset Spline Walker";
            this.toolStripButtonResetSplineWalker.Click += new System.EventHandler(this.toolStripButtonResetSplineWalker_Click);
            // 
            // toolStripButtonAddEvent
            // 
            this.toolStripButtonAddEvent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddEvent.Image = global::MonoGame.SplineFlower.Editor.Properties.Resources._067;
            this.toolStripButtonAddEvent.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonAddEvent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddEvent.Name = "toolStripButtonAddEvent";
            this.toolStripButtonAddEvent.Size = new System.Drawing.Size(23, 25);
            this.toolStripButtonAddEvent.Text = "Add Event";
            this.toolStripButtonAddEvent.Click += new System.EventHandler(this.toolStripButtonAddEvent_Click);
            // 
            // toolStripLabelSelected
            // 
            this.toolStripLabelSelected.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabelSelected.Image = global::MonoGame.SplineFlower.Editor.Properties.Resources._070;
            this.toolStripLabelSelected.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripLabelSelected.Name = "toolStripLabelSelected";
            this.toolStripLabelSelected.Size = new System.Drawing.Size(16, 25);
            // 
            // toolStripMenuItemFile
            // 
            this.toolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemImportJson,
            this.toolStripMenuItemExportJson});
            this.toolStripMenuItemFile.Image = global::MonoGame.SplineFlower.Editor.Properties.Resources._088;
            this.toolStripMenuItemFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItemFile.Name = "toolStripMenuItemFile";
            this.toolStripMenuItemFile.Size = new System.Drawing.Size(68, 24);
            this.toolStripMenuItemFile.Text = "File";
            // 
            // toolStripMenuItemDiagnostics
            // 
            this.toolStripMenuItemDiagnostics.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCenterSpline,
            this.toolStripSeparator3,
            this.toolStripMenuItemDrawSpline,
            this.toolStripSeparator4,
            this.toolStripMenuItemDrawBaseLine,
            this.toolStripMenuItemDrawCurves,
            this.toolStripMenuItemDrawDirections,
            this.toolStripMenuItemDrawTrigger,
            this.toolStripSeparator5,
            this.toolStripMenuItemDrawMarker,
            this.toolStripMenuItemDrawSplineWalker,
            this.toolStripMenuItemDrawCar});
            this.toolStripMenuItemDiagnostics.Image = global::MonoGame.SplineFlower.Editor.Properties.Resources._026;
            this.toolStripMenuItemDiagnostics.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItemDiagnostics.Name = "toolStripMenuItemDiagnostics";
            this.toolStripMenuItemDiagnostics.Size = new System.Drawing.Size(124, 24);
            this.toolStripMenuItemDiagnostics.Text = "Diagnostics";
            // 
            // toolStripMenuItemCenterSpline
            // 
            this.toolStripMenuItemCenterSpline.Name = "toolStripMenuItemCenterSpline";
            this.toolStripMenuItemCenterSpline.Size = new System.Drawing.Size(226, 26);
            this.toolStripMenuItemCenterSpline.Text = "Center Spline";
            this.toolStripMenuItemCenterSpline.Click += new System.EventHandler(this.toolStripMenuItemCenterSpline_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(223, 6);
            // 
            // toolStripMenuItemDrawSpline
            // 
            this.toolStripMenuItemDrawSpline.Checked = true;
            this.toolStripMenuItemDrawSpline.CheckOnClick = true;
            this.toolStripMenuItemDrawSpline.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemDrawSpline.Name = "toolStripMenuItemDrawSpline";
            this.toolStripMenuItemDrawSpline.Size = new System.Drawing.Size(226, 26);
            this.toolStripMenuItemDrawSpline.Text = "Draw Spline";
            this.toolStripMenuItemDrawSpline.CheckedChanged += new System.EventHandler(this.toolStripMenuItemDrawSpline_CheckedChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(223, 6);
            // 
            // toolStripMenuItemDrawBaseLine
            // 
            this.toolStripMenuItemDrawBaseLine.Checked = true;
            this.toolStripMenuItemDrawBaseLine.CheckOnClick = true;
            this.toolStripMenuItemDrawBaseLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemDrawBaseLine.Name = "toolStripMenuItemDrawBaseLine";
            this.toolStripMenuItemDrawBaseLine.Size = new System.Drawing.Size(226, 26);
            this.toolStripMenuItemDrawBaseLine.Text = "Draw Base Line";
            this.toolStripMenuItemDrawBaseLine.CheckedChanged += new System.EventHandler(this.toolStripMenuItemDrawBaseLine_CheckedChanged);
            // 
            // toolStripMenuItemDrawCurves
            // 
            this.toolStripMenuItemDrawCurves.Checked = true;
            this.toolStripMenuItemDrawCurves.CheckOnClick = true;
            this.toolStripMenuItemDrawCurves.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemDrawCurves.Name = "toolStripMenuItemDrawCurves";
            this.toolStripMenuItemDrawCurves.Size = new System.Drawing.Size(226, 26);
            this.toolStripMenuItemDrawCurves.Text = "Draw Curves";
            this.toolStripMenuItemDrawCurves.CheckedChanged += new System.EventHandler(this.toolStripMenuItemDrawCurves_CheckedChanged);
            // 
            // toolStripMenuItemDrawDirections
            // 
            this.toolStripMenuItemDrawDirections.Checked = true;
            this.toolStripMenuItemDrawDirections.CheckOnClick = true;
            this.toolStripMenuItemDrawDirections.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemDrawDirections.Name = "toolStripMenuItemDrawDirections";
            this.toolStripMenuItemDrawDirections.Size = new System.Drawing.Size(226, 26);
            this.toolStripMenuItemDrawDirections.Text = "Draw Directions";
            this.toolStripMenuItemDrawDirections.CheckedChanged += new System.EventHandler(this.toolStripMenuItemDrawDirections_CheckedChanged);
            // 
            // toolStripMenuItemDrawTrigger
            // 
            this.toolStripMenuItemDrawTrigger.Checked = true;
            this.toolStripMenuItemDrawTrigger.CheckOnClick = true;
            this.toolStripMenuItemDrawTrigger.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemDrawTrigger.Name = "toolStripMenuItemDrawTrigger";
            this.toolStripMenuItemDrawTrigger.Size = new System.Drawing.Size(226, 26);
            this.toolStripMenuItemDrawTrigger.Text = "Draw Trigger";
            this.toolStripMenuItemDrawTrigger.CheckedChanged += new System.EventHandler(this.toolStripMenuItemDrawTrigger_CheckedChanged);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(223, 6);
            // 
            // toolStripMenuItemDrawMarker
            // 
            this.toolStripMenuItemDrawMarker.Checked = true;
            this.toolStripMenuItemDrawMarker.CheckOnClick = true;
            this.toolStripMenuItemDrawMarker.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemDrawMarker.Name = "toolStripMenuItemDrawMarker";
            this.toolStripMenuItemDrawMarker.Size = new System.Drawing.Size(226, 26);
            this.toolStripMenuItemDrawMarker.Text = "Draw Spline Marker";
            this.toolStripMenuItemDrawMarker.Click += new System.EventHandler(this.toolStripMenuItemDrawMarker_Click);
            // 
            // toolStripMenuItemDrawSplineWalker
            // 
            this.toolStripMenuItemDrawSplineWalker.Checked = true;
            this.toolStripMenuItemDrawSplineWalker.CheckOnClick = true;
            this.toolStripMenuItemDrawSplineWalker.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemDrawSplineWalker.Name = "toolStripMenuItemDrawSplineWalker";
            this.toolStripMenuItemDrawSplineWalker.Size = new System.Drawing.Size(226, 26);
            this.toolStripMenuItemDrawSplineWalker.Text = "Draw Spline Walker";
            this.toolStripMenuItemDrawSplineWalker.CheckedChanged += new System.EventHandler(this.toolStripMenuItemDrawSplineWalker_CheckedChanged);
            // 
            // toolStripMenuItemDrawCar
            // 
            this.toolStripMenuItemDrawCar.Checked = true;
            this.toolStripMenuItemDrawCar.CheckOnClick = true;
            this.toolStripMenuItemDrawCar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemDrawCar.Name = "toolStripMenuItemDrawCar";
            this.toolStripMenuItemDrawCar.Size = new System.Drawing.Size(226, 26);
            this.toolStripMenuItemDrawCar.Text = "Draw Car";
            this.toolStripMenuItemDrawCar.CheckedChanged += new System.EventHandler(this.toolStripMenuItemDrawCar_CheckedChanged);
            // 
            // toolStripMenuItemExportJson
            // 
            this.toolStripMenuItemExportJson.Name = "toolStripMenuItemExportJson";
            this.toolStripMenuItemExportJson.Size = new System.Drawing.Size(181, 26);
            this.toolStripMenuItemExportJson.Text = "Export JSON";
            this.toolStripMenuItemExportJson.Click += new System.EventHandler(this.toolStripMenuItemExportJson_Click);
            // 
            // toolStripMenuItemImportJson
            // 
            this.toolStripMenuItemImportJson.Name = "toolStripMenuItemImportJson";
            this.toolStripMenuItemImportJson.Size = new System.Drawing.Size(181, 26);
            this.toolStripMenuItemImportJson.Text = "Import JSON";
            this.toolStripMenuItemImportJson.Click += new System.EventHandler(this.toolStripMenuItemImportJson_Click);
            // 
            // FormEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.splineControl);
            this.Controls.Add(this.trackBarMarker);
            this.Controls.Add(this.toolStripToolBar);
            this.Controls.Add(this.menuStripMainMenu);
            this.MainMenuStrip = this.menuStripMainMenu;
            this.Name = "FormEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MonoGame.SplineFlower.Editor";
            this.Load += new System.EventHandler(this.FormEditor_Load);
            this.ResizeEnd += new System.EventHandler(this.FormEditor_ResizeEnd);
            this.Resize += new System.EventHandler(this.FormEditor_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMarker)).EndInit();
            this.toolStripToolBar.ResumeLayout(false);
            this.toolStripToolBar.PerformLayout();
            this.menuStripMainMenu.ResumeLayout(false);
            this.menuStripMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Samples.Controls.SplineControl splineControl;
        private System.Windows.Forms.TrackBar trackBarMarker;
        private System.Windows.Forms.ToolStrip toolStripToolBar;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddCurveLeft;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddCurveRight;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonResetSplineWalker;
        private System.Windows.Forms.ToolStripButton toolStripButtonTrackLoop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxWalkerMode;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxSelectedTrigger;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddEvent;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxEvents;
        private Controls.ToolStrip.ToolStripNumericUpDown toolStripNumericUpDownTriggerRange;
        private System.Windows.Forms.MenuStrip menuStripMainMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDiagnostics;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCenterSpline;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDrawBaseLine;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDrawCurves;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDrawDirections;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDrawSpline;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDrawTrigger;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDrawSplineWalker;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDrawMarker;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDrawCar;
        private System.Windows.Forms.ToolStripLabel toolStripLabelSelected;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExportJson;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemImportJson;
    }
}

