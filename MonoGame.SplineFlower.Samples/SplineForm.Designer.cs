namespace MonoGame.SplineFlower.Samples
{
    partial class SplineForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplineForm));
            this.tabControlEditorTabs = new System.Windows.Forms.TabControl();
            this.tabPageBezierSpline = new System.Windows.Forms.TabPage();
            this.comboBoxCenterTransformMode = new System.Windows.Forms.ComboBox();
            this.comboBoxWalkerMode = new System.Windows.Forms.ComboBox();
            this.buttonResetSplineWalker = new System.Windows.Forms.Button();
            this.buttonLoop = new System.Windows.Forms.Button();
            this.buttonAddCurveRight = new System.Windows.Forms.Button();
            this.buttonAddCurveLeft = new System.Windows.Forms.Button();
            this.splineControl = new MonoGame.SplineFlower.Samples.Controls.SplineControl();
            this.tabPageCatMulRom = new System.Windows.Forms.TabPage();
            this.comboBoxCenterTransformMode_2 = new System.Windows.Forms.ComboBox();
            this.catMulRomSpline = new MonoGame.SplineFlower.Samples.Controls.CatMulRomSpline();
            this.tabPageAdvancedControls = new System.Windows.Forms.TabPage();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.advancedControls = new MonoGame.SplineFlower.Samples.Controls.AdvancedControls();
            this.tabPageInfo = new System.Windows.Forms.TabPage();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripDropDownButtonGitHub = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripDropDownButtonTwitter = new System.Windows.Forms.ToolStripDropDownButton();
            this.richTextBoxLicense = new System.Windows.Forms.RichTextBox();
            this.tabControlEditorTabs.SuspendLayout();
            this.tabPageBezierSpline.SuspendLayout();
            this.tabPageCatMulRom.SuspendLayout();
            this.tabPageAdvancedControls.SuspendLayout();
            this.tabPageInfo.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlEditorTabs
            // 
            this.tabControlEditorTabs.Controls.Add(this.tabPageBezierSpline);
            this.tabControlEditorTabs.Controls.Add(this.tabPageCatMulRom);
            this.tabControlEditorTabs.Controls.Add(this.tabPageAdvancedControls);
            this.tabControlEditorTabs.Controls.Add(this.tabPageInfo);
            this.tabControlEditorTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlEditorTabs.Location = new System.Drawing.Point(0, 0);
            this.tabControlEditorTabs.Name = "tabControlEditorTabs";
            this.tabControlEditorTabs.SelectedIndex = 0;
            this.tabControlEditorTabs.Size = new System.Drawing.Size(782, 553);
            this.tabControlEditorTabs.TabIndex = 2;
            // 
            // tabPageBezierSpline
            // 
            this.tabPageBezierSpline.Controls.Add(this.comboBoxCenterTransformMode);
            this.tabPageBezierSpline.Controls.Add(this.comboBoxWalkerMode);
            this.tabPageBezierSpline.Controls.Add(this.buttonResetSplineWalker);
            this.tabPageBezierSpline.Controls.Add(this.buttonLoop);
            this.tabPageBezierSpline.Controls.Add(this.buttonAddCurveRight);
            this.tabPageBezierSpline.Controls.Add(this.buttonAddCurveLeft);
            this.tabPageBezierSpline.Controls.Add(this.splineControl);
            this.tabPageBezierSpline.Location = new System.Drawing.Point(4, 25);
            this.tabPageBezierSpline.Name = "tabPageBezierSpline";
            this.tabPageBezierSpline.Size = new System.Drawing.Size(774, 524);
            this.tabPageBezierSpline.TabIndex = 3;
            this.tabPageBezierSpline.Text = "Beziér Spline";
            this.tabPageBezierSpline.UseVisualStyleBackColor = true;
            // 
            // comboBoxCenterTransformMode
            // 
            this.comboBoxCenterTransformMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxCenterTransformMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCenterTransformMode.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCenterTransformMode.FormattingEnabled = true;
            this.comboBoxCenterTransformMode.Items.AddRange(new object[] {
            "None",
            "Rotate",
            "Scale",
            "ScaleRotate"});
            this.comboBoxCenterTransformMode.Location = new System.Drawing.Point(3, 409);
            this.comboBoxCenterTransformMode.MaxDropDownItems = 3;
            this.comboBoxCenterTransformMode.Name = "comboBoxCenterTransformMode";
            this.comboBoxCenterTransformMode.Size = new System.Drawing.Size(159, 26);
            this.comboBoxCenterTransformMode.TabIndex = 13;
            this.comboBoxCenterTransformMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxCenterTransformMode_SelectedIndexChanged);
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
            this.comboBoxWalkerMode.Location = new System.Drawing.Point(591, 452);
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
            this.buttonResetSplineWalker.Location = new System.Drawing.Point(591, 484);
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
            this.buttonLoop.Location = new System.Drawing.Point(704, 441);
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
            this.buttonAddCurveRight.Location = new System.Drawing.Point(3, 484);
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
            this.buttonAddCurveLeft.Location = new System.Drawing.Point(3, 441);
            this.buttonAddCurveLeft.Name = "buttonAddCurveLeft";
            this.buttonAddCurveLeft.Size = new System.Drawing.Size(159, 37);
            this.buttonAddCurveLeft.TabIndex = 1;
            this.buttonAddCurveLeft.Text = "Add Curve Left";
            this.buttonAddCurveLeft.UseVisualStyleBackColor = true;
            this.buttonAddCurveLeft.Click += new System.EventHandler(this.buttonAddCurve_Click);
            // 
            // splineControl
            // 
            this.splineControl.BackColor = System.Drawing.Color.GreenYellow;
            this.splineControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splineControl.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splineControl.ForeColor = System.Drawing.Color.DarkOrange;
            this.splineControl.GetSpline = null;
            this.splineControl.Location = new System.Drawing.Point(0, 0);
            this.splineControl.Name = "splineControl";
            this.splineControl.SelectedTrigger = null;
            this.splineControl.SetCenterTransformMode = MonoGame.SplineFlower.Samples.Controls.TransformControl.CenterTransformMode.ScaleRotate;
            this.splineControl.Size = new System.Drawing.Size(774, 524);
            this.splineControl.TabIndex = 12;
            this.splineControl.Text = "Bézier Spline";
            // 
            // tabPageCatMulRom
            // 
            this.tabPageCatMulRom.Controls.Add(this.comboBoxCenterTransformMode_2);
            this.tabPageCatMulRom.Controls.Add(this.catMulRomSpline);
            this.tabPageCatMulRom.Location = new System.Drawing.Point(4, 25);
            this.tabPageCatMulRom.Name = "tabPageCatMulRom";
            this.tabPageCatMulRom.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCatMulRom.Size = new System.Drawing.Size(774, 524);
            this.tabPageCatMulRom.TabIndex = 0;
            this.tabPageCatMulRom.Text = "CatMulRom Spline";
            this.tabPageCatMulRom.UseVisualStyleBackColor = true;
            // 
            // comboBoxCenterTransformMode_2
            // 
            this.comboBoxCenterTransformMode_2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxCenterTransformMode_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCenterTransformMode_2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCenterTransformMode_2.FormattingEnabled = true;
            this.comboBoxCenterTransformMode_2.Items.AddRange(new object[] {
            "None",
            "Rotate",
            "Scale",
            "ScaleRotate"});
            this.comboBoxCenterTransformMode_2.Location = new System.Drawing.Point(6, 490);
            this.comboBoxCenterTransformMode_2.MaxDropDownItems = 3;
            this.comboBoxCenterTransformMode_2.Name = "comboBoxCenterTransformMode_2";
            this.comboBoxCenterTransformMode_2.Size = new System.Drawing.Size(159, 26);
            this.comboBoxCenterTransformMode_2.TabIndex = 14;
            this.comboBoxCenterTransformMode_2.SelectedIndexChanged += new System.EventHandler(this.comboBoxCenterTransformMode_2_SelectedIndexChanged);
            // 
            // catMulRomSpline
            // 
            this.catMulRomSpline.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.catMulRomSpline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.catMulRomSpline.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.catMulRomSpline.ForeColor = System.Drawing.Color.Orange;
            this.catMulRomSpline.GetSpline = null;
            this.catMulRomSpline.Location = new System.Drawing.Point(3, 3);
            this.catMulRomSpline.Name = "catMulRomSpline";
            this.catMulRomSpline.SelectedTrigger = null;
            this.catMulRomSpline.SetCenterTransformMode = MonoGame.SplineFlower.Samples.Controls.TransformControl.CenterTransformMode.ScaleRotate;
            this.catMulRomSpline.Size = new System.Drawing.Size(768, 518);
            this.catMulRomSpline.TabIndex = 0;
            this.catMulRomSpline.Text = "CatMulRom Spline";
            // 
            // tabPageAdvancedControls
            // 
            this.tabPageAdvancedControls.Controls.Add(this.buttonHelp);
            this.tabPageAdvancedControls.Controls.Add(this.advancedControls);
            this.tabPageAdvancedControls.Location = new System.Drawing.Point(4, 25);
            this.tabPageAdvancedControls.Name = "tabPageAdvancedControls";
            this.tabPageAdvancedControls.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAdvancedControls.Size = new System.Drawing.Size(774, 524);
            this.tabPageAdvancedControls.TabIndex = 5;
            this.tabPageAdvancedControls.Text = "AdvancedControls";
            this.tabPageAdvancedControls.UseVisualStyleBackColor = true;
            // 
            // buttonHelp
            // 
            this.buttonHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHelp.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHelp.Location = new System.Drawing.Point(735, 6);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(31, 32);
            this.buttonHelp.TabIndex = 1;
            this.buttonHelp.Text = "?";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // advancedControls
            // 
            this.advancedControls.BackColor = System.Drawing.Color.Tan;
            this.advancedControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedControls.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.advancedControls.ForeColor = System.Drawing.Color.GhostWhite;
            this.advancedControls.GetSpline = null;
            this.advancedControls.Location = new System.Drawing.Point(3, 3);
            this.advancedControls.Name = "advancedControls";
            this.advancedControls.SelectedTrigger = null;
            this.advancedControls.SetCenterTransformMode = MonoGame.SplineFlower.Samples.Controls.TransformControl.CenterTransformMode.ScaleRotate;
            this.advancedControls.Size = new System.Drawing.Size(768, 518);
            this.advancedControls.TabIndex = 0;
            this.advancedControls.Text = "Advanced Controls";
            // 
            // tabPageInfo
            // 
            this.tabPageInfo.Controls.Add(this.statusStrip);
            this.tabPageInfo.Controls.Add(this.richTextBoxLicense);
            this.tabPageInfo.Location = new System.Drawing.Point(4, 25);
            this.tabPageInfo.Name = "tabPageInfo";
            this.tabPageInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInfo.Size = new System.Drawing.Size(774, 524);
            this.tabPageInfo.TabIndex = 4;
            this.tabPageInfo.Text = "Info";
            this.tabPageInfo.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButtonGitHub,
            this.toolStripDropDownButtonTwitter});
            this.statusStrip.Location = new System.Drawing.Point(3, 483);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(768, 38);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 3;
            // 
            // toolStripDropDownButtonGitHub
            // 
            this.toolStripDropDownButtonGitHub.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripDropDownButtonGitHub.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonGitHub.Image")));
            this.toolStripDropDownButtonGitHub.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonGitHub.Name = "toolStripDropDownButtonGitHub";
            this.toolStripDropDownButtonGitHub.Size = new System.Drawing.Size(335, 36);
            this.toolStripDropDownButtonGitHub.Text = "MonoGame.SplineFlower";
            this.toolStripDropDownButtonGitHub.Click += new System.EventHandler(this.toolStripDropDownButtonGitHub_Click);
            // 
            // toolStripDropDownButtonTwitter
            // 
            this.toolStripDropDownButtonTwitter.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripDropDownButtonTwitter.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonTwitter.Image")));
            this.toolStripDropDownButtonTwitter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonTwitter.Name = "toolStripDropDownButtonTwitter";
            this.toolStripDropDownButtonTwitter.Size = new System.Drawing.Size(224, 36);
            this.toolStripDropDownButtonTwitter.Text = "@SandboxBlizz";
            this.toolStripDropDownButtonTwitter.Click += new System.EventHandler(this.toolStripDropDownButtonTwitter_Click);
            // 
            // richTextBoxLicense
            // 
            this.richTextBoxLicense.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxLicense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxLicense.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxLicense.Name = "richTextBoxLicense";
            this.richTextBoxLicense.Size = new System.Drawing.Size(768, 518);
            this.richTextBoxLicense.TabIndex = 2;
            this.richTextBoxLicense.Text = resources.GetString("richTextBoxLicense.Text");
            this.richTextBoxLicense.ZoomFactor = 1.5F;
            // 
            // SplineForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.tabControlEditorTabs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SplineForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MonoGame.SplineFlower";
            this.Load += new System.EventHandler(this.SplineEditorForm_Load);
            this.ResizeEnd += new System.EventHandler(this.SplineEditorForm_ResizeEnd);
            this.Resize += new System.EventHandler(this.SplineEditorForm_Resize);
            this.tabControlEditorTabs.ResumeLayout(false);
            this.tabPageBezierSpline.ResumeLayout(false);
            this.tabPageCatMulRom.ResumeLayout(false);
            this.tabPageAdvancedControls.ResumeLayout(false);
            this.tabPageInfo.ResumeLayout(false);
            this.tabPageInfo.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControlEditorTabs;
        private System.Windows.Forms.TabPage tabPageCatMulRom;
        private System.Windows.Forms.TabPage tabPageBezierSpline;
        private System.Windows.Forms.Button buttonAddCurveLeft;
        private System.Windows.Forms.Button buttonAddCurveRight;
        private System.Windows.Forms.Button buttonLoop;
        private System.Windows.Forms.Button buttonResetSplineWalker;
        private System.Windows.Forms.ComboBox comboBoxWalkerMode;
        private Controls.SplineControl splineControl;
        private System.Windows.Forms.TabPage tabPageInfo;
        private System.Windows.Forms.RichTextBox richTextBoxLicense;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonGitHub;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonTwitter;
        private System.Windows.Forms.TabPage tabPageAdvancedControls;
        private Controls.AdvancedControls advancedControls;
        private System.Windows.Forms.Button buttonHelp;
        private Controls.CatMulRomSpline catMulRomSpline;
        private System.Windows.Forms.ComboBox comboBoxCenterTransformMode;
        private System.Windows.Forms.ComboBox comboBoxCenterTransformMode_2;
    }
}

