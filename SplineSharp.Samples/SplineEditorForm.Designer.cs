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
            this.splineEditorLine = new SplineSharp.Samples.SplineEditorLine();
            this.tabPageQuadraticBezier = new System.Windows.Forms.TabPage();
            this.splineEditorCurve = new SplineSharp.Samples.SplineEditorCurve();
            this.tabPageCubicBezier = new System.Windows.Forms.TabPage();
            this.splineEditorCurveCubic = new SplineSharp.Samples.SplineEditorCurve();
            this.tabPageBezierSpline = new System.Windows.Forms.TabPage();
            this.comboBoxWalkerMode = new System.Windows.Forms.ComboBox();
            this.buttonResetSplineWalker = new System.Windows.Forms.Button();
            this.buttonLoop = new System.Windows.Forms.Button();
            this.buttonAddCurveRight = new System.Windows.Forms.Button();
            this.buttonAddCurveLeft = new System.Windows.Forms.Button();
            this.splineEditorBezierSpline = new SplineSharp.Samples.SplineEditorBezierSpline();
            this.tabControlEditorTabs.SuspendLayout();
            this.tabPageSimpleLine.SuspendLayout();
            this.tabPageQuadraticBezier.SuspendLayout();
            this.tabPageCubicBezier.SuspendLayout();
            this.tabPageBezierSpline.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlEditorTabs
            // 
            this.tabControlEditorTabs.Controls.Add(this.tabPageSimpleLine);
            this.tabControlEditorTabs.Controls.Add(this.tabPageQuadraticBezier);
            this.tabControlEditorTabs.Controls.Add(this.tabPageCubicBezier);
            this.tabControlEditorTabs.Controls.Add(this.tabPageBezierSpline);
            this.tabControlEditorTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlEditorTabs.Location = new System.Drawing.Point(0, 0);
            this.tabControlEditorTabs.Name = "tabControlEditorTabs";
            this.tabControlEditorTabs.SelectedIndex = 0;
            this.tabControlEditorTabs.Size = new System.Drawing.Size(782, 753);
            this.tabControlEditorTabs.TabIndex = 2;
            // 
            // tabPageSimpleLine
            // 
            this.tabPageSimpleLine.Controls.Add(this.splineEditorLine);
            this.tabPageSimpleLine.Location = new System.Drawing.Point(4, 25);
            this.tabPageSimpleLine.Name = "tabPageSimpleLine";
            this.tabPageSimpleLine.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSimpleLine.Size = new System.Drawing.Size(774, 724);
            this.tabPageSimpleLine.TabIndex = 0;
            this.tabPageSimpleLine.Text = "Simple Line";
            this.tabPageSimpleLine.UseVisualStyleBackColor = true;
            // 
            // splineEditorLine
            // 
            this.splineEditorLine.BackColor = System.Drawing.Color.Lavender;
            this.splineEditorLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splineEditorLine.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splineEditorLine.ForeColor = System.Drawing.Color.CadetBlue;
            this.splineEditorLine.Location = new System.Drawing.Point(3, 3);
            this.splineEditorLine.MyLine = null;
            this.splineEditorLine.Name = "splineEditorLine";
            this.splineEditorLine.Size = new System.Drawing.Size(768, 718);
            this.splineEditorLine.TabIndex = 0;
            this.splineEditorLine.Text = "Simple Line Sample";
            this.splineEditorLine.TryGetTransformFromPosition = null;
            // 
            // tabPageQuadraticBezier
            // 
            this.tabPageQuadraticBezier.Controls.Add(this.splineEditorCurve);
            this.tabPageQuadraticBezier.Location = new System.Drawing.Point(4, 25);
            this.tabPageQuadraticBezier.Name = "tabPageQuadraticBezier";
            this.tabPageQuadraticBezier.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageQuadraticBezier.Size = new System.Drawing.Size(774, 697);
            this.tabPageQuadraticBezier.TabIndex = 1;
            this.tabPageQuadraticBezier.Text = "Quadratic Beziér Curve";
            this.tabPageQuadraticBezier.UseVisualStyleBackColor = true;
            // 
            // splineEditorCurve
            // 
            this.splineEditorCurve.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.splineEditorCurve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splineEditorCurve.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splineEditorCurve.Location = new System.Drawing.Point(3, 3);
            this.splineEditorCurve.Name = "splineEditorCurve";
            this.splineEditorCurve.Size = new System.Drawing.Size(768, 691);
            this.splineEditorCurve.TabIndex = 0;
            this.splineEditorCurve.Text = "Quadratic Beziér Sample";
            this.splineEditorCurve.TryGetTransformFromPosition = null;
            // 
            // tabPageCubicBezier
            // 
            this.tabPageCubicBezier.Controls.Add(this.splineEditorCurveCubic);
            this.tabPageCubicBezier.Location = new System.Drawing.Point(4, 25);
            this.tabPageCubicBezier.Name = "tabPageCubicBezier";
            this.tabPageCubicBezier.Size = new System.Drawing.Size(774, 697);
            this.tabPageCubicBezier.TabIndex = 2;
            this.tabPageCubicBezier.Text = "Cubic Beziér Curve";
            this.tabPageCubicBezier.UseVisualStyleBackColor = true;
            // 
            // splineEditorCurveCubic
            // 
            this.splineEditorCurveCubic.BackColor = System.Drawing.Color.MediumAquamarine;
            this.splineEditorCurveCubic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splineEditorCurveCubic.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splineEditorCurveCubic.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.splineEditorCurveCubic.GetBezierType = SplineSharp.Samples.EditorBase.CurveEditor.BezierType.Cubic;
            this.splineEditorCurveCubic.Location = new System.Drawing.Point(0, 0);
            this.splineEditorCurveCubic.Name = "splineEditorCurveCubic";
            this.splineEditorCurveCubic.Size = new System.Drawing.Size(774, 697);
            this.splineEditorCurveCubic.TabIndex = 0;
            this.splineEditorCurveCubic.Text = "Cubic Beziér Sample";
            this.splineEditorCurveCubic.TryGetTransformFromPosition = null;
            // 
            // tabPageBezierSpline
            // 
            this.tabPageBezierSpline.Controls.Add(this.comboBoxWalkerMode);
            this.tabPageBezierSpline.Controls.Add(this.buttonResetSplineWalker);
            this.tabPageBezierSpline.Controls.Add(this.buttonLoop);
            this.tabPageBezierSpline.Controls.Add(this.buttonAddCurveRight);
            this.tabPageBezierSpline.Controls.Add(this.buttonAddCurveLeft);
            this.tabPageBezierSpline.Controls.Add(this.splineEditorBezierSpline);
            this.tabPageBezierSpline.Location = new System.Drawing.Point(4, 25);
            this.tabPageBezierSpline.Name = "tabPageBezierSpline";
            this.tabPageBezierSpline.Size = new System.Drawing.Size(774, 697);
            this.tabPageBezierSpline.TabIndex = 3;
            this.tabPageBezierSpline.Text = "Beziér Spline";
            this.tabPageBezierSpline.UseVisualStyleBackColor = true;
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
            this.comboBoxWalkerMode.Location = new System.Drawing.Point(591, 625);
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
            this.buttonResetSplineWalker.Location = new System.Drawing.Point(591, 657);
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
            this.buttonLoop.Location = new System.Drawing.Point(704, 614);
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
            this.buttonAddCurveRight.Location = new System.Drawing.Point(3, 657);
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
            this.buttonAddCurveLeft.Location = new System.Drawing.Point(3, 614);
            this.buttonAddCurveLeft.Name = "buttonAddCurveLeft";
            this.buttonAddCurveLeft.Size = new System.Drawing.Size(159, 37);
            this.buttonAddCurveLeft.TabIndex = 1;
            this.buttonAddCurveLeft.Text = "Add Curve Left";
            this.buttonAddCurveLeft.UseVisualStyleBackColor = true;
            this.buttonAddCurveLeft.Click += new System.EventHandler(this.buttonAddCurve_Click);
            // 
            // splineEditorBezierSpline
            // 
            this.splineEditorBezierSpline.BackColor = System.Drawing.Color.GreenYellow;
            this.splineEditorBezierSpline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splineEditorBezierSpline.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splineEditorBezierSpline.ForeColor = System.Drawing.Color.DarkOrange;
            this.splineEditorBezierSpline.Location = new System.Drawing.Point(0, 0);
            this.splineEditorBezierSpline.Name = "splineEditorBezierSpline";
            this.splineEditorBezierSpline.Size = new System.Drawing.Size(774, 697);
            this.splineEditorBezierSpline.TabIndex = 0;
            this.splineEditorBezierSpline.Text = "Beziér Spline Sample";
            this.splineEditorBezierSpline.TryGetTransformFromPosition = null;
            // 
            // SplineEditorForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(782, 753);
            this.Controls.Add(this.tabControlEditorTabs);
            this.Name = "SplineEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spline Editor";
            this.Load += new System.EventHandler(this.SplineEditorForm_Load);
            this.tabControlEditorTabs.ResumeLayout(false);
            this.tabPageSimpleLine.ResumeLayout(false);
            this.tabPageQuadraticBezier.ResumeLayout(false);
            this.tabPageCubicBezier.ResumeLayout(false);
            this.tabPageBezierSpline.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SplineEditorLine splineEditorLine;
        private System.Windows.Forms.TabControl tabControlEditorTabs;
        private System.Windows.Forms.TabPage tabPageSimpleLine;
        private System.Windows.Forms.TabPage tabPageQuadraticBezier;
        private SplineEditorCurve splineEditorCurve;
        private System.Windows.Forms.TabPage tabPageCubicBezier;
        private System.Windows.Forms.TabPage tabPageBezierSpline;
        private SplineEditorCurve splineEditorCurveCubic;
        private SplineEditorBezierSpline splineEditorBezierSpline;
        private System.Windows.Forms.Button buttonAddCurveLeft;
        private System.Windows.Forms.Button buttonAddCurveRight;
        private System.Windows.Forms.Button buttonLoop;
        private System.Windows.Forms.Button buttonResetSplineWalker;
        private System.Windows.Forms.ComboBox comboBoxWalkerMode;
    }
}

