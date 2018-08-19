namespace SplineSharp.Samples
{
    partial class SplineEditorForm
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
            this.tabControlEditorTabs = new System.Windows.Forms.TabControl();
            this.tabPageSimpleLine = new System.Windows.Forms.TabPage();
            this.tabPageQuadraticBezier = new System.Windows.Forms.TabPage();
            this.tabPageCubicBezier = new System.Windows.Forms.TabPage();
            this.tabPageBezierSpline = new System.Windows.Forms.TabPage();
            this.numericUpDownTriggerRange = new System.Windows.Forms.NumericUpDown();
            this.comboBoxSelectedTrigger = new System.Windows.Forms.ComboBox();
            this.comboBoxEvents = new System.Windows.Forms.ComboBox();
            this.buttonAddEvent = new System.Windows.Forms.Button();
            this.trackBarMarker = new System.Windows.Forms.TrackBar();
            this.comboBoxWalkerMode = new System.Windows.Forms.ComboBox();
            this.buttonResetSplineWalker = new System.Windows.Forms.Button();
            this.buttonLoop = new System.Windows.Forms.Button();
            this.buttonAddCurveRight = new System.Windows.Forms.Button();
            this.buttonAddCurveLeft = new System.Windows.Forms.Button();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemDiagnostics = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCenterPoints = new System.Windows.Forms.ToolStripMenuItem();
            this.lineControl = new SplineSharp.Samples.Controls.LineControl();
            this.curveControlQuadratic = new SplineSharp.Samples.Controls.CurveControl();
            this.curveControlCubic = new SplineSharp.Samples.Controls.CurveControl();
            this.splineControl = new SplineSharp.Samples.Controls.SplineControl();
            this.tabControlEditorTabs.SuspendLayout();
            this.tabPageSimpleLine.SuspendLayout();
            this.tabPageQuadraticBezier.SuspendLayout();
            this.tabPageCubicBezier.SuspendLayout();
            this.tabPageBezierSpline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTriggerRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMarker)).BeginInit();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlEditorTabs
            // 
            this.tabControlEditorTabs.Controls.Add(this.tabPageSimpleLine);
            this.tabControlEditorTabs.Controls.Add(this.tabPageQuadraticBezier);
            this.tabControlEditorTabs.Controls.Add(this.tabPageCubicBezier);
            this.tabControlEditorTabs.Controls.Add(this.tabPageBezierSpline);
            this.tabControlEditorTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlEditorTabs.Location = new System.Drawing.Point(0, 28);
            this.tabControlEditorTabs.Name = "tabControlEditorTabs";
            this.tabControlEditorTabs.SelectedIndex = 0;
            this.tabControlEditorTabs.Size = new System.Drawing.Size(782, 725);
            this.tabControlEditorTabs.TabIndex = 2;
            // 
            // tabPageSimpleLine
            // 
            this.tabPageSimpleLine.Controls.Add(this.lineControl);
            this.tabPageSimpleLine.Location = new System.Drawing.Point(4, 25);
            this.tabPageSimpleLine.Name = "tabPageSimpleLine";
            this.tabPageSimpleLine.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSimpleLine.Size = new System.Drawing.Size(774, 696);
            this.tabPageSimpleLine.TabIndex = 0;
            this.tabPageSimpleLine.Text = "Simple Line";
            this.tabPageSimpleLine.UseVisualStyleBackColor = true;
            // 
            // tabPageQuadraticBezier
            // 
            this.tabPageQuadraticBezier.Controls.Add(this.curveControlQuadratic);
            this.tabPageQuadraticBezier.Location = new System.Drawing.Point(4, 25);
            this.tabPageQuadraticBezier.Name = "tabPageQuadraticBezier";
            this.tabPageQuadraticBezier.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageQuadraticBezier.Size = new System.Drawing.Size(774, 696);
            this.tabPageQuadraticBezier.TabIndex = 1;
            this.tabPageQuadraticBezier.Text = "Quadratic Beziér Curve";
            this.tabPageQuadraticBezier.UseVisualStyleBackColor = true;
            // 
            // tabPageCubicBezier
            // 
            this.tabPageCubicBezier.Controls.Add(this.curveControlCubic);
            this.tabPageCubicBezier.Location = new System.Drawing.Point(4, 25);
            this.tabPageCubicBezier.Name = "tabPageCubicBezier";
            this.tabPageCubicBezier.Size = new System.Drawing.Size(774, 696);
            this.tabPageCubicBezier.TabIndex = 2;
            this.tabPageCubicBezier.Text = "Cubic Beziér Curve";
            this.tabPageCubicBezier.UseVisualStyleBackColor = true;
            // 
            // tabPageBezierSpline
            // 
            this.tabPageBezierSpline.Controls.Add(this.numericUpDownTriggerRange);
            this.tabPageBezierSpline.Controls.Add(this.comboBoxSelectedTrigger);
            this.tabPageBezierSpline.Controls.Add(this.comboBoxEvents);
            this.tabPageBezierSpline.Controls.Add(this.buttonAddEvent);
            this.tabPageBezierSpline.Controls.Add(this.trackBarMarker);
            this.tabPageBezierSpline.Controls.Add(this.comboBoxWalkerMode);
            this.tabPageBezierSpline.Controls.Add(this.buttonResetSplineWalker);
            this.tabPageBezierSpline.Controls.Add(this.buttonLoop);
            this.tabPageBezierSpline.Controls.Add(this.buttonAddCurveRight);
            this.tabPageBezierSpline.Controls.Add(this.buttonAddCurveLeft);
            this.tabPageBezierSpline.Controls.Add(this.splineControl);
            this.tabPageBezierSpline.Location = new System.Drawing.Point(4, 25);
            this.tabPageBezierSpline.Name = "tabPageBezierSpline";
            this.tabPageBezierSpline.Size = new System.Drawing.Size(774, 696);
            this.tabPageBezierSpline.TabIndex = 3;
            this.tabPageBezierSpline.Text = "Beziér Spline";
            this.tabPageBezierSpline.UseVisualStyleBackColor = true;
            // 
            // numericUpDownTriggerRange
            // 
            this.numericUpDownTriggerRange.Location = new System.Drawing.Point(523, 609);
            this.numericUpDownTriggerRange.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownTriggerRange.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownTriggerRange.Name = "numericUpDownTriggerRange";
            this.numericUpDownTriggerRange.Size = new System.Drawing.Size(62, 22);
            this.numericUpDownTriggerRange.TabIndex = 11;
            this.numericUpDownTriggerRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownTriggerRange.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownTriggerRange.ValueChanged += new System.EventHandler(this.numericUpDownTriggerRange_ValueChanged);
            // 
            // comboBoxSelectedTrigger
            // 
            this.comboBoxSelectedTrigger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectedTrigger.DropDownWidth = 400;
            this.comboBoxSelectedTrigger.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSelectedTrigger.FormattingEnabled = true;
            this.comboBoxSelectedTrigger.Items.AddRange(new object[] {
            "Marker"});
            this.comboBoxSelectedTrigger.Location = new System.Drawing.Point(8, 3);
            this.comboBoxSelectedTrigger.MaxDropDownItems = 3;
            this.comboBoxSelectedTrigger.Name = "comboBoxSelectedTrigger";
            this.comboBoxSelectedTrigger.Size = new System.Drawing.Size(107, 26);
            this.comboBoxSelectedTrigger.TabIndex = 10;
            this.comboBoxSelectedTrigger.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectedTrigger_SelectedIndexChanged);
            // 
            // comboBoxEvents
            // 
            this.comboBoxEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxEvents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEvents.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxEvents.FormattingEnabled = true;
            this.comboBoxEvents.Items.AddRange(new object[] {
            "Horn",
            "Brakes",
            "Counter"});
            this.comboBoxEvents.Location = new System.Drawing.Point(282, 605);
            this.comboBoxEvents.MaxDropDownItems = 3;
            this.comboBoxEvents.Name = "comboBoxEvents";
            this.comboBoxEvents.Size = new System.Drawing.Size(107, 26);
            this.comboBoxEvents.TabIndex = 9;
            // 
            // buttonAddEvent
            // 
            this.buttonAddEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddEvent.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddEvent.Location = new System.Drawing.Point(168, 594);
            this.buttonAddEvent.Name = "buttonAddEvent";
            this.buttonAddEvent.Size = new System.Drawing.Size(108, 37);
            this.buttonAddEvent.TabIndex = 8;
            this.buttonAddEvent.Text = "Add Event";
            this.buttonAddEvent.UseVisualStyleBackColor = true;
            this.buttonAddEvent.Click += new System.EventHandler(this.buttonAddEvent_Click);
            // 
            // trackBarMarker
            // 
            this.trackBarMarker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarMarker.LargeChange = 10;
            this.trackBarMarker.Location = new System.Drawing.Point(168, 637);
            this.trackBarMarker.Maximum = 1000;
            this.trackBarMarker.Name = "trackBarMarker";
            this.trackBarMarker.Size = new System.Drawing.Size(417, 56);
            this.trackBarMarker.TabIndex = 7;
            this.trackBarMarker.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarMarker.Scroll += new System.EventHandler(this.trackBarMarker_Scroll);
            this.trackBarMarker.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarMarker_MouseDown);
            this.trackBarMarker.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarMarker_MouseUp);
            // 
            // comboBoxWalkerMode
            // 
            this.comboBoxWalkerMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxWalkerMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWalkerMode.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxWalkerMode.FormattingEnabled = true;
            this.comboBoxWalkerMode.Items.AddRange(new object[] {
            "Once",
            "Loop",
            "PingPong"});
            this.comboBoxWalkerMode.Location = new System.Drawing.Point(591, 624);
            this.comboBoxWalkerMode.MaxDropDownItems = 3;
            this.comboBoxWalkerMode.Name = "comboBoxWalkerMode";
            this.comboBoxWalkerMode.Size = new System.Drawing.Size(107, 26);
            this.comboBoxWalkerMode.TabIndex = 5;
            this.comboBoxWalkerMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxWalkerMode_SelectedIndexChanged);
            // 
            // buttonResetSplineWalker
            // 
            this.buttonResetSplineWalker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonResetSplineWalker.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResetSplineWalker.Location = new System.Drawing.Point(591, 656);
            this.buttonResetSplineWalker.Name = "buttonResetSplineWalker";
            this.buttonResetSplineWalker.Size = new System.Drawing.Size(180, 37);
            this.buttonResetSplineWalker.TabIndex = 4;
            this.buttonResetSplineWalker.Text = "Reset SplineWalker";
            this.buttonResetSplineWalker.UseVisualStyleBackColor = true;
            this.buttonResetSplineWalker.Click += new System.EventHandler(this.buttonResetSplineWalker_Click);
            // 
            // buttonLoop
            // 
            this.buttonLoop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoop.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoop.Location = new System.Drawing.Point(704, 613);
            this.buttonLoop.Name = "buttonLoop";
            this.buttonLoop.Size = new System.Drawing.Size(67, 37);
            this.buttonLoop.TabIndex = 3;
            this.buttonLoop.Text = "Loop";
            this.buttonLoop.UseVisualStyleBackColor = true;
            this.buttonLoop.Click += new System.EventHandler(this.buttonLoop_Click);
            // 
            // buttonAddCurveRight
            // 
            this.buttonAddCurveRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddCurveRight.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddCurveRight.Location = new System.Drawing.Point(3, 656);
            this.buttonAddCurveRight.Name = "buttonAddCurveRight";
            this.buttonAddCurveRight.Size = new System.Drawing.Size(159, 37);
            this.buttonAddCurveRight.TabIndex = 2;
            this.buttonAddCurveRight.Text = "Add Curve Right";
            this.buttonAddCurveRight.UseVisualStyleBackColor = true;
            this.buttonAddCurveRight.Click += new System.EventHandler(this.buttonAddCurveRight_Click);
            // 
            // buttonAddCurveLeft
            // 
            this.buttonAddCurveLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddCurveLeft.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddCurveLeft.Location = new System.Drawing.Point(3, 613);
            this.buttonAddCurveLeft.Name = "buttonAddCurveLeft";
            this.buttonAddCurveLeft.Size = new System.Drawing.Size(159, 37);
            this.buttonAddCurveLeft.TabIndex = 1;
            this.buttonAddCurveLeft.Text = "Add Curve Left";
            this.buttonAddCurveLeft.UseVisualStyleBackColor = true;
            this.buttonAddCurveLeft.Click += new System.EventHandler(this.buttonAddCurve_Click);
            // 
            // menuStripMain
            // 
            this.menuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemDiagnostics});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(782, 28);
            this.menuStripMain.TabIndex = 3;
            this.menuStripMain.Text = "Mein Menu";
            // 
            // toolStripMenuItemDiagnostics
            // 
            this.toolStripMenuItemDiagnostics.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCenterPoints});
            this.toolStripMenuItemDiagnostics.Name = "toolStripMenuItemDiagnostics";
            this.toolStripMenuItemDiagnostics.Size = new System.Drawing.Size(98, 24);
            this.toolStripMenuItemDiagnostics.Text = "Diagnostics";
            // 
            // toolStripMenuItemCenterPoints
            // 
            this.toolStripMenuItemCenterPoints.Name = "toolStripMenuItemCenterPoints";
            this.toolStripMenuItemCenterPoints.Size = new System.Drawing.Size(172, 26);
            this.toolStripMenuItemCenterPoints.Text = "Center Spline";
            this.toolStripMenuItemCenterPoints.Click += new System.EventHandler(this.toolStripMenuItemCenterPoints_Click);
            // 
            // lineControl
            // 
            this.lineControl.BackColor = System.Drawing.Color.Lavender;
            this.lineControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lineControl.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineControl.ForeColor = System.Drawing.Color.CadetBlue;
            this.lineControl.GetAllPoints = null;
            this.lineControl.Location = new System.Drawing.Point(3, 3);
            this.lineControl.MyLine = null;
            this.lineControl.Name = "lineControl";
            this.lineControl.Size = new System.Drawing.Size(768, 690);
            this.lineControl.TabIndex = 0;
            this.lineControl.Text = "Simple Line Sample";
            this.lineControl.TryGetTransformFromPosition = null;
            // 
            // curveControlQuadratic
            // 
            this.curveControlQuadratic.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.curveControlQuadratic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.curveControlQuadratic.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.curveControlQuadratic.GetAllPoints = null;
            this.curveControlQuadratic.Location = new System.Drawing.Point(3, 3);
            this.curveControlQuadratic.Name = "curveControlQuadratic";
            this.curveControlQuadratic.Size = new System.Drawing.Size(768, 690);
            this.curveControlQuadratic.TabIndex = 0;
            this.curveControlQuadratic.Text = "Quadratic Beziér Sample";
            this.curveControlQuadratic.TryGetTransformFromPosition = null;
            // 
            // curveControlCubic
            // 
            this.curveControlCubic.BackColor = System.Drawing.Color.MediumAquamarine;
            this.curveControlCubic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.curveControlCubic.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.curveControlCubic.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.curveControlCubic.GetAllPoints = null;
            this.curveControlCubic.GetBezierType = SplineSharp.Samples.Controls.CurveControl.BezierType.Cubic;
            this.curveControlCubic.Location = new System.Drawing.Point(0, 0);
            this.curveControlCubic.Name = "curveControlCubic";
            this.curveControlCubic.Size = new System.Drawing.Size(774, 696);
            this.curveControlCubic.TabIndex = 0;
            this.curveControlCubic.Text = "Cubic Beziér Sample";
            this.curveControlCubic.TryGetTransformFromPosition = null;
            // 
            // splineControl
            // 
            this.splineControl.BackColor = System.Drawing.Color.GreenYellow;
            this.splineControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splineControl.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splineControl.ForeColor = System.Drawing.Color.DarkOrange;
            this.splineControl.GetAllPoints = null;
            this.splineControl.Location = new System.Drawing.Point(0, 0);
            this.splineControl.Name = "splineControl";
            this.splineControl.Size = new System.Drawing.Size(774, 696);
            this.splineControl.TabIndex = 6;
            this.splineControl.Text = "Beziér Spline Sample";
            this.splineControl.TryGetTransformFromPosition = null;
            // 
            // SplineEditorForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(782, 753);
            this.Controls.Add(this.tabControlEditorTabs);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "SplineEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spline Editor";
            this.Load += new System.EventHandler(this.SplineEditorForm_Load);
            this.ResizeEnd += new System.EventHandler(this.SplineEditorForm_ResizeEnd);
            this.Resize += new System.EventHandler(this.SplineEditorForm_Resize);
            this.tabControlEditorTabs.ResumeLayout(false);
            this.tabPageSimpleLine.ResumeLayout(false);
            this.tabPageQuadraticBezier.ResumeLayout(false);
            this.tabPageCubicBezier.ResumeLayout(false);
            this.tabPageBezierSpline.ResumeLayout(false);
            this.tabPageBezierSpline.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTriggerRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMarker)).EndInit();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControlEditorTabs;
        private System.Windows.Forms.TabPage tabPageSimpleLine;
        private System.Windows.Forms.TabPage tabPageQuadraticBezier;
        private System.Windows.Forms.TabPage tabPageCubicBezier;
        private System.Windows.Forms.TabPage tabPageBezierSpline;
        private System.Windows.Forms.Button buttonAddCurveLeft;
        private System.Windows.Forms.Button buttonAddCurveRight;
        private System.Windows.Forms.Button buttonLoop;
        private System.Windows.Forms.Button buttonResetSplineWalker;
        private System.Windows.Forms.ComboBox comboBoxWalkerMode;
        private Controls.LineControl lineControl;
        private Controls.CurveControl curveControlQuadratic;
        private Controls.CurveControl curveControlCubic;
        private Controls.SplineControl splineControl;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDiagnostics;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCenterPoints;
        private System.Windows.Forms.TrackBar trackBarMarker;
        private System.Windows.Forms.Button buttonAddEvent;
        private System.Windows.Forms.ComboBox comboBoxEvents;
        private System.Windows.Forms.ComboBox comboBoxSelectedTrigger;
        private System.Windows.Forms.NumericUpDown numericUpDownTriggerRange;
    }
}

