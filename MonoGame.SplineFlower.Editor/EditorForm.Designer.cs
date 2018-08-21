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
            this.comboBoxSelectedTrigger = new System.Windows.Forms.ComboBox();
            this.numericUpDownTriggerRange = new System.Windows.Forms.NumericUpDown();
            this.trackBarMarker = new System.Windows.Forms.TrackBar();
            this.splineControl = new MonoGame.SplineFlower.Samples.Controls.SplineControl();
            this.comboBoxEvents = new System.Windows.Forms.ComboBox();
            this.buttonAddEvent = new System.Windows.Forms.Button();
            this.comboBoxWalkerMode = new System.Windows.Forms.ComboBox();
            this.buttonResetSplineWalker = new System.Windows.Forms.Button();
            this.buttonLoop = new System.Windows.Forms.Button();
            this.buttonAddCurveRight = new System.Windows.Forms.Button();
            this.buttonAddCurveLeft = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTriggerRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMarker)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxSelectedTrigger
            // 
            this.comboBoxSelectedTrigger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectedTrigger.DropDownWidth = 400;
            this.comboBoxSelectedTrigger.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSelectedTrigger.FormattingEnabled = true;
            this.comboBoxSelectedTrigger.Items.AddRange(new object[] {
            "Marker"});
            this.comboBoxSelectedTrigger.Location = new System.Drawing.Point(12, 12);
            this.comboBoxSelectedTrigger.MaxDropDownItems = 3;
            this.comboBoxSelectedTrigger.Name = "comboBoxSelectedTrigger";
            this.comboBoxSelectedTrigger.Size = new System.Drawing.Size(107, 26);
            this.comboBoxSelectedTrigger.TabIndex = 11;
            this.comboBoxSelectedTrigger.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectedTrigger_SelectedIndexChanged);
            // 
            // numericUpDownTriggerRange
            // 
            this.numericUpDownTriggerRange.Location = new System.Drawing.Point(522, 457);
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
            this.numericUpDownTriggerRange.TabIndex = 13;
            this.numericUpDownTriggerRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownTriggerRange.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownTriggerRange.ValueChanged += new System.EventHandler(this.numericUpDownTriggerRange_ValueChanged);
            // 
            // trackBarMarker
            // 
            this.trackBarMarker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarMarker.LargeChange = 10;
            this.trackBarMarker.Location = new System.Drawing.Point(167, 485);
            this.trackBarMarker.Maximum = 1000;
            this.trackBarMarker.Name = "trackBarMarker";
            this.trackBarMarker.Size = new System.Drawing.Size(417, 56);
            this.trackBarMarker.TabIndex = 12;
            this.trackBarMarker.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarMarker.Scroll += new System.EventHandler(this.trackBarMarker_Scroll);
            this.trackBarMarker.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarMarker_MouseDown);
            this.trackBarMarker.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarMarker_MouseUp);
            // 
            // splineControl
            // 
            this.splineControl.BackColor = System.Drawing.Color.Yellow;
            this.splineControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splineControl.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splineControl.GetAllPoints = null;
            this.splineControl.Location = new System.Drawing.Point(0, 0);
            this.splineControl.Name = "splineControl";
            this.splineControl.SelectedTrigger = null;
            this.splineControl.Size = new System.Drawing.Size(782, 553);
            this.splineControl.TabIndex = 0;
            this.splineControl.Text = "Bézier Spline Editor";
            this.splineControl.TryGetTransformFromPosition = null;
            this.splineControl.TryGetTriggerFromPosition = null;
            this.splineControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.splineControl_MouseUp);
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
            this.comboBoxEvents.Location = new System.Drawing.Point(281, 453);
            this.comboBoxEvents.MaxDropDownItems = 3;
            this.comboBoxEvents.Name = "comboBoxEvents";
            this.comboBoxEvents.Size = new System.Drawing.Size(107, 26);
            this.comboBoxEvents.TabIndex = 15;
            // 
            // buttonAddEvent
            // 
            this.buttonAddEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddEvent.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddEvent.Location = new System.Drawing.Point(167, 442);
            this.buttonAddEvent.Name = "buttonAddEvent";
            this.buttonAddEvent.Size = new System.Drawing.Size(108, 37);
            this.buttonAddEvent.TabIndex = 14;
            this.buttonAddEvent.Text = "Add Event";
            this.buttonAddEvent.UseVisualStyleBackColor = true;
            this.buttonAddEvent.Click += new System.EventHandler(this.buttonAddEvent_Click);
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
            this.comboBoxWalkerMode.Location = new System.Drawing.Point(590, 472);
            this.comboBoxWalkerMode.MaxDropDownItems = 3;
            this.comboBoxWalkerMode.Name = "comboBoxWalkerMode";
            this.comboBoxWalkerMode.Size = new System.Drawing.Size(107, 26);
            this.comboBoxWalkerMode.TabIndex = 18;
            this.comboBoxWalkerMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxWalkerMode_SelectedIndexChanged);
            // 
            // buttonResetSplineWalker
            // 
            this.buttonResetSplineWalker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonResetSplineWalker.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResetSplineWalker.Location = new System.Drawing.Point(590, 504);
            this.buttonResetSplineWalker.Name = "buttonResetSplineWalker";
            this.buttonResetSplineWalker.Size = new System.Drawing.Size(180, 37);
            this.buttonResetSplineWalker.TabIndex = 17;
            this.buttonResetSplineWalker.Text = "Reset SplineWalker";
            this.buttonResetSplineWalker.UseVisualStyleBackColor = true;
            this.buttonResetSplineWalker.Click += new System.EventHandler(this.buttonResetSplineWalker_Click);
            // 
            // buttonLoop
            // 
            this.buttonLoop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoop.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoop.Location = new System.Drawing.Point(703, 461);
            this.buttonLoop.Name = "buttonLoop";
            this.buttonLoop.Size = new System.Drawing.Size(67, 37);
            this.buttonLoop.TabIndex = 16;
            this.buttonLoop.Text = "Loop";
            this.buttonLoop.UseVisualStyleBackColor = true;
            this.buttonLoop.Click += new System.EventHandler(this.buttonLoop_Click);
            // 
            // buttonAddCurveRight
            // 
            this.buttonAddCurveRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddCurveRight.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddCurveRight.Location = new System.Drawing.Point(2, 504);
            this.buttonAddCurveRight.Name = "buttonAddCurveRight";
            this.buttonAddCurveRight.Size = new System.Drawing.Size(159, 37);
            this.buttonAddCurveRight.TabIndex = 20;
            this.buttonAddCurveRight.Text = "Add Curve Right";
            this.buttonAddCurveRight.UseVisualStyleBackColor = true;
            this.buttonAddCurveRight.Click += new System.EventHandler(this.buttonAddCurveRight_Click);
            // 
            // buttonAddCurveLeft
            // 
            this.buttonAddCurveLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddCurveLeft.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddCurveLeft.Location = new System.Drawing.Point(2, 461);
            this.buttonAddCurveLeft.Name = "buttonAddCurveLeft";
            this.buttonAddCurveLeft.Size = new System.Drawing.Size(159, 37);
            this.buttonAddCurveLeft.TabIndex = 19;
            this.buttonAddCurveLeft.Text = "Add Curve Left";
            this.buttonAddCurveLeft.UseVisualStyleBackColor = true;
            this.buttonAddCurveLeft.Click += new System.EventHandler(this.buttonAddCurveLeft_Click);
            // 
            // FormEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.buttonAddCurveRight);
            this.Controls.Add(this.buttonAddCurveLeft);
            this.Controls.Add(this.comboBoxWalkerMode);
            this.Controls.Add(this.buttonResetSplineWalker);
            this.Controls.Add(this.buttonLoop);
            this.Controls.Add(this.comboBoxEvents);
            this.Controls.Add(this.buttonAddEvent);
            this.Controls.Add(this.numericUpDownTriggerRange);
            this.Controls.Add(this.trackBarMarker);
            this.Controls.Add(this.comboBoxSelectedTrigger);
            this.Controls.Add(this.splineControl);
            this.Name = "FormEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MonoGame.SplineFlower.Editor";
            this.Load += new System.EventHandler(this.FormEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTriggerRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMarker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Samples.Controls.SplineControl splineControl;
        private System.Windows.Forms.ComboBox comboBoxSelectedTrigger;
        private System.Windows.Forms.NumericUpDown numericUpDownTriggerRange;
        private System.Windows.Forms.TrackBar trackBarMarker;
        private System.Windows.Forms.ComboBox comboBoxEvents;
        private System.Windows.Forms.Button buttonAddEvent;
        private System.Windows.Forms.ComboBox comboBoxWalkerMode;
        private System.Windows.Forms.Button buttonResetSplineWalker;
        private System.Windows.Forms.Button buttonLoop;
        private System.Windows.Forms.Button buttonAddCurveRight;
        private System.Windows.Forms.Button buttonAddCurveLeft;
    }
}

