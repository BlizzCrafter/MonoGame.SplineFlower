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
            this.tabPageChainSpline = new System.Windows.Forms.TabPage();
            this.chainSplineControl = new MonoGame.SplineFlower.Samples.Controls.ChainSplineControl();
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
            this.catMulRomSpline = new MonoGame.SplineFlower.Samples.Controls.CatMulRomSplineControl();
            this.tabPageHermiteSpline = new System.Windows.Forms.TabPage();
            this.panelAddSubstractTangentValues = new System.Windows.Forms.Panel();
            this.buttonSubstractBias = new System.Windows.Forms.Button();
            this.buttonAddBias = new System.Windows.Forms.Button();
            this.buttonSubstractTension = new System.Windows.Forms.Button();
            this.buttonAddTension = new System.Windows.Forms.Button();
            this.labelAddBias = new System.Windows.Forms.Label();
            this.labelAddTension = new System.Windows.Forms.Label();
            this.hermiteSplineControl = new MonoGame.SplineFlower.Samples.Controls.HermiteSplineControl();
            this.tabPagePolygonSplineControl = new System.Windows.Forms.TabPage();
            this.buttonPolygonHelp = new System.Windows.Forms.Button();
            this.checkBoxShowPoints = new System.Windows.Forms.CheckBox();
            this.checkBoxShowLines = new System.Windows.Forms.CheckBox();
            this.checkBoxDirectionVectors = new System.Windows.Forms.CheckBox();
            this.checkBoxShowCurves = new System.Windows.Forms.CheckBox();
            this.polygonSplineControl1 = new MonoGame.SplineFlower.Samples.Controls.PolygonSplineControl();
            this.tabPageFindNearestPoint = new System.Windows.Forms.TabPage();
            this.labelAccuracy = new System.Windows.Forms.Label();
            this.numericUpDownAccuracy = new System.Windows.Forms.NumericUpDown();
            this.buttonCatMulRomFindTest = new System.Windows.Forms.Button();
            this.buttonLoopFindTest = new System.Windows.Forms.Button();
            this.findNearestPointControl1 = new MonoGame.SplineFlower.Samples.Controls.FindNearestPointControl();
            this.tabPageAdvancedControls = new System.Windows.Forms.TabPage();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.advancedControls = new MonoGame.SplineFlower.Samples.Controls.AdvancedControl();
            this.tabPageInfo = new System.Windows.Forms.TabPage();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripDropDownButtonGitHub = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripDropDownButtonTwitter = new System.Windows.Forms.ToolStripDropDownButton();
            this.richTextBoxLicense = new System.Windows.Forms.RichTextBox();
            this.tabControlEditorTabs.SuspendLayout();
            this.tabPageChainSpline.SuspendLayout();
            this.tabPageBezierSpline.SuspendLayout();
            this.tabPageCatMulRom.SuspendLayout();
            this.tabPageHermiteSpline.SuspendLayout();
            this.panelAddSubstractTangentValues.SuspendLayout();
            this.tabPagePolygonSplineControl.SuspendLayout();
            this.tabPageFindNearestPoint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAccuracy)).BeginInit();
            this.tabPageAdvancedControls.SuspendLayout();
            this.tabPageInfo.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlEditorTabs
            // 
            this.tabControlEditorTabs.Controls.Add(this.tabPageBezierSpline);
            this.tabControlEditorTabs.Controls.Add(this.tabPageCatMulRom);
            this.tabControlEditorTabs.Controls.Add(this.tabPageHermiteSpline);
            this.tabControlEditorTabs.Controls.Add(this.tabPageChainSpline);
            this.tabControlEditorTabs.Controls.Add(this.tabPagePolygonSplineControl);
            this.tabControlEditorTabs.Controls.Add(this.tabPageFindNearestPoint);
            this.tabControlEditorTabs.Controls.Add(this.tabPageAdvancedControls);
            this.tabControlEditorTabs.Controls.Add(this.tabPageInfo);
            this.tabControlEditorTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlEditorTabs.Location = new System.Drawing.Point(0, 0);
            this.tabControlEditorTabs.Name = "tabControlEditorTabs";
            this.tabControlEditorTabs.SelectedIndex = 0;
            this.tabControlEditorTabs.Size = new System.Drawing.Size(782, 553);
            this.tabControlEditorTabs.TabIndex = 2;
            // 
            // tabPageChainSpline
            // 
            this.tabPageChainSpline.Controls.Add(this.chainSplineControl);
            this.tabPageChainSpline.Location = new System.Drawing.Point(4, 25);
            this.tabPageChainSpline.Name = "tabPageChainSpline";
            this.tabPageChainSpline.Size = new System.Drawing.Size(774, 524);
            this.tabPageChainSpline.TabIndex = 9;
            this.tabPageChainSpline.Text = "ChainSpline";
            this.tabPageChainSpline.UseVisualStyleBackColor = true;
            // 
            // chainSplineControl
            // 
            this.chainSplineControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(129)))), ((int)(((byte)(142)))));
            this.chainSplineControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chainSplineControl.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chainSplineControl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(182)))), ((int)(((byte)(105)))));
            this.chainSplineControl.MySpline = null;
            this.chainSplineControl.Location = new System.Drawing.Point(0, 0);
            this.chainSplineControl.MouseHoverUpdatesOnly = false;
            this.chainSplineControl.Name = "chainSplineControl";
            this.chainSplineControl.SetCenterTransformMode = MonoGame.SplineFlower.Samples.Controls.TransformControl.CenterTransformMode.ScaleRotate;
            this.chainSplineControl.Size = new System.Drawing.Size(774, 524);
            this.chainSplineControl.TabIndex = 0;
            this.chainSplineControl.Text = "Chain Spline";
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
            this.splineControl.MySpline = null;
            this.splineControl.Location = new System.Drawing.Point(0, 0);
            this.splineControl.MouseHoverUpdatesOnly = false;
            this.splineControl.Name = "splineControl";
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
            this.catMulRomSpline.MySpline = null;
            this.catMulRomSpline.Location = new System.Drawing.Point(3, 3);
            this.catMulRomSpline.MouseHoverUpdatesOnly = false;
            this.catMulRomSpline.Name = "catMulRomSpline";
            this.catMulRomSpline.SetCenterTransformMode = MonoGame.SplineFlower.Samples.Controls.TransformControl.CenterTransformMode.ScaleRotate;
            this.catMulRomSpline.Size = new System.Drawing.Size(768, 518);
            this.catMulRomSpline.TabIndex = 0;
            this.catMulRomSpline.Text = "CatMulRom Spline";
            // 
            // tabPageHermiteSpline
            // 
            this.tabPageHermiteSpline.Controls.Add(this.panelAddSubstractTangentValues);
            this.tabPageHermiteSpline.Controls.Add(this.hermiteSplineControl);
            this.tabPageHermiteSpline.Location = new System.Drawing.Point(4, 25);
            this.tabPageHermiteSpline.Name = "tabPageHermiteSpline";
            this.tabPageHermiteSpline.Size = new System.Drawing.Size(774, 524);
            this.tabPageHermiteSpline.TabIndex = 8;
            this.tabPageHermiteSpline.Text = "Hermite Spline";
            this.tabPageHermiteSpline.UseVisualStyleBackColor = true;
            // 
            // panelAddSubstractTangentValues
            // 
            this.panelAddSubstractTangentValues.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAddSubstractTangentValues.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panelAddSubstractTangentValues.Controls.Add(this.buttonSubstractBias);
            this.panelAddSubstractTangentValues.Controls.Add(this.buttonAddBias);
            this.panelAddSubstractTangentValues.Controls.Add(this.buttonSubstractTension);
            this.panelAddSubstractTangentValues.Controls.Add(this.buttonAddTension);
            this.panelAddSubstractTangentValues.Controls.Add(this.labelAddBias);
            this.panelAddSubstractTangentValues.Controls.Add(this.labelAddTension);
            this.panelAddSubstractTangentValues.Location = new System.Drawing.Point(621, 457);
            this.panelAddSubstractTangentValues.Name = "panelAddSubstractTangentValues";
            this.panelAddSubstractTangentValues.Size = new System.Drawing.Size(150, 64);
            this.panelAddSubstractTangentValues.TabIndex = 6;
            // 
            // buttonSubstractBias
            // 
            this.buttonSubstractBias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSubstractBias.Location = new System.Drawing.Point(39, 29);
            this.buttonSubstractBias.Name = "buttonSubstractBias";
            this.buttonSubstractBias.Size = new System.Drawing.Size(28, 30);
            this.buttonSubstractBias.TabIndex = 8;
            this.buttonSubstractBias.Text = "-";
            this.buttonSubstractBias.UseVisualStyleBackColor = true;
            this.buttonSubstractBias.Click += new System.EventHandler(this.buttonSubstractBias_Click);
            // 
            // buttonAddBias
            // 
            this.buttonAddBias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddBias.Location = new System.Drawing.Point(6, 29);
            this.buttonAddBias.Name = "buttonAddBias";
            this.buttonAddBias.Size = new System.Drawing.Size(28, 30);
            this.buttonAddBias.TabIndex = 7;
            this.buttonAddBias.Text = "+";
            this.buttonAddBias.UseVisualStyleBackColor = true;
            this.buttonAddBias.Click += new System.EventHandler(this.buttonAddBias_Click);
            // 
            // buttonSubstractTension
            // 
            this.buttonSubstractTension.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSubstractTension.Location = new System.Drawing.Point(117, 29);
            this.buttonSubstractTension.Name = "buttonSubstractTension";
            this.buttonSubstractTension.Size = new System.Drawing.Size(28, 30);
            this.buttonSubstractTension.TabIndex = 6;
            this.buttonSubstractTension.Text = "-";
            this.buttonSubstractTension.UseVisualStyleBackColor = true;
            this.buttonSubstractTension.Click += new System.EventHandler(this.buttonSubstractTension_Click);
            // 
            // buttonAddTension
            // 
            this.buttonAddTension.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddTension.Location = new System.Drawing.Point(84, 29);
            this.buttonAddTension.Name = "buttonAddTension";
            this.buttonAddTension.Size = new System.Drawing.Size(28, 30);
            this.buttonAddTension.TabIndex = 5;
            this.buttonAddTension.Text = "+";
            this.buttonAddTension.UseVisualStyleBackColor = true;
            this.buttonAddTension.Click += new System.EventHandler(this.buttonAddTension_Click);
            // 
            // labelAddBias
            // 
            this.labelAddBias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAddBias.AutoSize = true;
            this.labelAddBias.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddBias.ForeColor = System.Drawing.Color.White;
            this.labelAddBias.Location = new System.Drawing.Point(3, 9);
            this.labelAddBias.Name = "labelAddBias";
            this.labelAddBias.Size = new System.Drawing.Size(45, 20);
            this.labelAddBias.TabIndex = 4;
            this.labelAddBias.Text = "Bias";
            // 
            // labelAddTension
            // 
            this.labelAddTension.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAddTension.AutoSize = true;
            this.labelAddTension.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddTension.ForeColor = System.Drawing.Color.White;
            this.labelAddTension.Location = new System.Drawing.Point(81, 9);
            this.labelAddTension.Name = "labelAddTension";
            this.labelAddTension.Size = new System.Drawing.Size(72, 20);
            this.labelAddTension.TabIndex = 2;
            this.labelAddTension.Text = "Tension";
            // 
            // hermiteSplineControl
            // 
            this.hermiteSplineControl.BackColor = System.Drawing.Color.Firebrick;
            this.hermiteSplineControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hermiteSplineControl.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.hermiteSplineControl.ForeColor = System.Drawing.Color.LightSalmon;
            this.hermiteSplineControl.MySpline = null;
            this.hermiteSplineControl.Location = new System.Drawing.Point(0, 0);
            this.hermiteSplineControl.MouseHoverUpdatesOnly = false;
            this.hermiteSplineControl.Name = "hermiteSplineControl";
            this.hermiteSplineControl.SetCenterTransformMode = MonoGame.SplineFlower.Samples.Controls.TransformControl.CenterTransformMode.ScaleRotate;
            this.hermiteSplineControl.Size = new System.Drawing.Size(774, 524);
            this.hermiteSplineControl.TabIndex = 0;
            this.hermiteSplineControl.Text = "Hermite Spline";
            // 
            // tabPagePolygonSplineControl
            // 
            this.tabPagePolygonSplineControl.Controls.Add(this.buttonPolygonHelp);
            this.tabPagePolygonSplineControl.Controls.Add(this.checkBoxShowPoints);
            this.tabPagePolygonSplineControl.Controls.Add(this.checkBoxShowLines);
            this.tabPagePolygonSplineControl.Controls.Add(this.checkBoxDirectionVectors);
            this.tabPagePolygonSplineControl.Controls.Add(this.checkBoxShowCurves);
            this.tabPagePolygonSplineControl.Controls.Add(this.polygonSplineControl1);
            this.tabPagePolygonSplineControl.Location = new System.Drawing.Point(4, 25);
            this.tabPagePolygonSplineControl.Name = "tabPagePolygonSplineControl";
            this.tabPagePolygonSplineControl.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePolygonSplineControl.Size = new System.Drawing.Size(774, 524);
            this.tabPagePolygonSplineControl.TabIndex = 7;
            this.tabPagePolygonSplineControl.Text = "PolygonSpline";
            this.tabPagePolygonSplineControl.UseVisualStyleBackColor = true;
            // 
            // buttonPolygonHelp
            // 
            this.buttonPolygonHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPolygonHelp.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPolygonHelp.Location = new System.Drawing.Point(737, 6);
            this.buttonPolygonHelp.Name = "buttonPolygonHelp";
            this.buttonPolygonHelp.Size = new System.Drawing.Size(31, 32);
            this.buttonPolygonHelp.TabIndex = 5;
            this.buttonPolygonHelp.Text = "?";
            this.buttonPolygonHelp.UseVisualStyleBackColor = true;
            this.buttonPolygonHelp.Click += new System.EventHandler(this.buttonPolygonHelp_Click);
            // 
            // checkBoxShowPoints
            // 
            this.checkBoxShowPoints.AutoSize = true;
            this.checkBoxShowPoints.Location = new System.Drawing.Point(412, 6);
            this.checkBoxShowPoints.Name = "checkBoxShowPoints";
            this.checkBoxShowPoints.Size = new System.Drawing.Size(107, 21);
            this.checkBoxShowPoints.TabIndex = 4;
            this.checkBoxShowPoints.Text = "Show Points";
            this.checkBoxShowPoints.UseVisualStyleBackColor = true;
            this.checkBoxShowPoints.CheckedChanged += new System.EventHandler(this.checkBoxShowPoints_CheckedChanged);
            // 
            // checkBoxShowLines
            // 
            this.checkBoxShowLines.AutoSize = true;
            this.checkBoxShowLines.Location = new System.Drawing.Point(304, 6);
            this.checkBoxShowLines.Name = "checkBoxShowLines";
            this.checkBoxShowLines.Size = new System.Drawing.Size(102, 21);
            this.checkBoxShowLines.TabIndex = 3;
            this.checkBoxShowLines.Text = "Show Lines";
            this.checkBoxShowLines.UseVisualStyleBackColor = true;
            this.checkBoxShowLines.CheckedChanged += new System.EventHandler(this.checkBoxShowLines_CheckedChanged);
            // 
            // checkBoxDirectionVectors
            // 
            this.checkBoxDirectionVectors.AutoSize = true;
            this.checkBoxDirectionVectors.Location = new System.Drawing.Point(122, 6);
            this.checkBoxDirectionVectors.Name = "checkBoxDirectionVectors";
            this.checkBoxDirectionVectors.Size = new System.Drawing.Size(176, 21);
            this.checkBoxDirectionVectors.TabIndex = 2;
            this.checkBoxDirectionVectors.Text = "Show Direction Vectors";
            this.checkBoxDirectionVectors.UseVisualStyleBackColor = true;
            this.checkBoxDirectionVectors.CheckedChanged += new System.EventHandler(this.checkBoxDirectionVectors_CheckedChanged);
            // 
            // checkBoxShowCurves
            // 
            this.checkBoxShowCurves.AutoSize = true;
            this.checkBoxShowCurves.Location = new System.Drawing.Point(8, 6);
            this.checkBoxShowCurves.Name = "checkBoxShowCurves";
            this.checkBoxShowCurves.Size = new System.Drawing.Size(112, 21);
            this.checkBoxShowCurves.TabIndex = 1;
            this.checkBoxShowCurves.Text = "Show Curves";
            this.checkBoxShowCurves.UseVisualStyleBackColor = true;
            this.checkBoxShowCurves.CheckedChanged += new System.EventHandler(this.checkBoxShowCurves_CheckedChanged);
            // 
            // polygonSplineControl1
            // 
            this.polygonSplineControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.polygonSplineControl1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.polygonSplineControl1.MySpline = null;
            this.polygonSplineControl1.Location = new System.Drawing.Point(3, 3);
            this.polygonSplineControl1.MouseHoverUpdatesOnly = false;
            this.polygonSplineControl1.Name = "polygonSplineControl1";
            this.polygonSplineControl1.SetCenterTransformMode = MonoGame.SplineFlower.Samples.Controls.TransformControl.CenterTransformMode.ScaleRotate;
            this.polygonSplineControl1.Size = new System.Drawing.Size(768, 518);
            this.polygonSplineControl1.TabIndex = 0;
            this.polygonSplineControl1.Text = "Polygon Spline";
            // 
            // tabPageFindNearestPoint
            // 
            this.tabPageFindNearestPoint.Controls.Add(this.labelAccuracy);
            this.tabPageFindNearestPoint.Controls.Add(this.numericUpDownAccuracy);
            this.tabPageFindNearestPoint.Controls.Add(this.buttonCatMulRomFindTest);
            this.tabPageFindNearestPoint.Controls.Add(this.buttonLoopFindTest);
            this.tabPageFindNearestPoint.Controls.Add(this.findNearestPointControl1);
            this.tabPageFindNearestPoint.Location = new System.Drawing.Point(4, 25);
            this.tabPageFindNearestPoint.Name = "tabPageFindNearestPoint";
            this.tabPageFindNearestPoint.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFindNearestPoint.Size = new System.Drawing.Size(774, 524);
            this.tabPageFindNearestPoint.TabIndex = 6;
            this.tabPageFindNearestPoint.Text = "FindNearestPoint";
            this.tabPageFindNearestPoint.UseVisualStyleBackColor = true;
            // 
            // labelAccuracy
            // 
            this.labelAccuracy.AutoSize = true;
            this.labelAccuracy.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAccuracy.Location = new System.Drawing.Point(8, 466);
            this.labelAccuracy.Name = "labelAccuracy";
            this.labelAccuracy.Size = new System.Drawing.Size(81, 20);
            this.labelAccuracy.TabIndex = 7;
            this.labelAccuracy.Text = "Accuracy";
            // 
            // numericUpDownAccuracy
            // 
            this.numericUpDownAccuracy.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownAccuracy.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownAccuracy.Location = new System.Drawing.Point(8, 489);
            this.numericUpDownAccuracy.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownAccuracy.Name = "numericUpDownAccuracy";
            this.numericUpDownAccuracy.Size = new System.Drawing.Size(120, 27);
            this.numericUpDownAccuracy.TabIndex = 6;
            this.numericUpDownAccuracy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownAccuracy.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownAccuracy.ValueChanged += new System.EventHandler(this.numericUpDownAccuracy_ValueChanged);
            // 
            // buttonCatMulRomFindTest
            // 
            this.buttonCatMulRomFindTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCatMulRomFindTest.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCatMulRomFindTest.Location = new System.Drawing.Point(657, 436);
            this.buttonCatMulRomFindTest.Name = "buttonCatMulRomFindTest";
            this.buttonCatMulRomFindTest.Size = new System.Drawing.Size(111, 37);
            this.buttonCatMulRomFindTest.TabIndex = 5;
            this.buttonCatMulRomFindTest.Text = "CatMulRom";
            this.buttonCatMulRomFindTest.UseVisualStyleBackColor = true;
            this.buttonCatMulRomFindTest.Click += new System.EventHandler(this.buttonCatMulRomFindTest_Click);
            // 
            // buttonLoopFindTest
            // 
            this.buttonLoopFindTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoopFindTest.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoopFindTest.Location = new System.Drawing.Point(657, 479);
            this.buttonLoopFindTest.Name = "buttonLoopFindTest";
            this.buttonLoopFindTest.Size = new System.Drawing.Size(111, 37);
            this.buttonLoopFindTest.TabIndex = 4;
            this.buttonLoopFindTest.Text = "Loop";
            this.buttonLoopFindTest.UseVisualStyleBackColor = true;
            this.buttonLoopFindTest.Click += new System.EventHandler(this.buttonLoopFindTest_Click);
            // 
            // findNearestPointControl1
            // 
            this.findNearestPointControl1.BackColor = System.Drawing.Color.Khaki;
            this.findNearestPointControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.findNearestPointControl1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findNearestPointControl1.ForeColor = System.Drawing.Color.CadetBlue;
            this.findNearestPointControl1.MySpline = null;
            this.findNearestPointControl1.Location = new System.Drawing.Point(3, 3);
            this.findNearestPointControl1.MouseHoverUpdatesOnly = false;
            this.findNearestPointControl1.Name = "findNearestPointControl1";
            this.findNearestPointControl1.NearestPointAccuracy = 1000F;
            this.findNearestPointControl1.SetCenterTransformMode = MonoGame.SplineFlower.Samples.Controls.TransformControl.CenterTransformMode.ScaleRotate;
            this.findNearestPointControl1.Size = new System.Drawing.Size(768, 518);
            this.findNearestPointControl1.TabIndex = 0;
            this.findNearestPointControl1.Text = "Find Nearest Point On Spline";
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
            this.advancedControls.MySpline = null;
            this.advancedControls.Location = new System.Drawing.Point(3, 3);
            this.advancedControls.MouseHoverUpdatesOnly = false;
            this.advancedControls.Name = "advancedControls";
            this.advancedControls.SetCenterTransformMode = MonoGame.SplineFlower.Samples.Controls.TransformControl.CenterTransformMode.ScaleRotate;
            this.advancedControls.Size = new System.Drawing.Size(768, 518);
            this.advancedControls.TabIndex = 0;
            this.advancedControls.Text = "Advanced Controls";
            // 
            // tabPageInfo
            // 
            this.tabPageInfo.Controls.Add(this.richTextBoxLicense);
            this.tabPageInfo.Controls.Add(this.statusStrip);
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
            this.toolStripDropDownButtonTwitter.Size = new System.Drawing.Size(204, 36);
            this.toolStripDropDownButtonTwitter.Text = "@BlizzCrafter";
            this.toolStripDropDownButtonTwitter.Click += new System.EventHandler(this.toolStripDropDownButtonTwitter_Click);
            // 
            // richTextBoxLicense
            // 
            this.richTextBoxLicense.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxLicense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxLicense.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxLicense.Name = "richTextBoxLicense";
            this.richTextBoxLicense.Size = new System.Drawing.Size(768, 480);
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
            this.tabPageChainSpline.ResumeLayout(false);
            this.tabPageBezierSpline.ResumeLayout(false);
            this.tabPageCatMulRom.ResumeLayout(false);
            this.tabPageHermiteSpline.ResumeLayout(false);
            this.panelAddSubstractTangentValues.ResumeLayout(false);
            this.panelAddSubstractTangentValues.PerformLayout();
            this.tabPagePolygonSplineControl.ResumeLayout(false);
            this.tabPagePolygonSplineControl.PerformLayout();
            this.tabPageFindNearestPoint.ResumeLayout(false);
            this.tabPageFindNearestPoint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAccuracy)).EndInit();
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
        private Controls.AdvancedControl advancedControls;
        private System.Windows.Forms.Button buttonHelp;
        private Controls.CatMulRomSplineControl catMulRomSpline;
        private System.Windows.Forms.ComboBox comboBoxCenterTransformMode;
        private System.Windows.Forms.ComboBox comboBoxCenterTransformMode_2;
        private System.Windows.Forms.TabPage tabPageFindNearestPoint;
        private Controls.FindNearestPointControl findNearestPointControl1;
        private System.Windows.Forms.Button buttonCatMulRomFindTest;
        private System.Windows.Forms.Button buttonLoopFindTest;
        private System.Windows.Forms.Label labelAccuracy;
        public System.Windows.Forms.NumericUpDown numericUpDownAccuracy;
        private System.Windows.Forms.TabPage tabPagePolygonSplineControl;
        private Controls.PolygonSplineControl polygonSplineControl1;
        private System.Windows.Forms.TabPage tabPageHermiteSpline;
        private Controls.HermiteSplineControl hermiteSplineControl;
        public System.Windows.Forms.Panel panelAddSubstractTangentValues;
        private System.Windows.Forms.Button buttonSubstractBias;
        private System.Windows.Forms.Button buttonAddBias;
        private System.Windows.Forms.Button buttonSubstractTension;
        private System.Windows.Forms.Button buttonAddTension;
        private System.Windows.Forms.Label labelAddBias;
        private System.Windows.Forms.Label labelAddTension;
        private System.Windows.Forms.CheckBox checkBoxShowCurves;
        private System.Windows.Forms.CheckBox checkBoxShowPoints;
        private System.Windows.Forms.CheckBox checkBoxShowLines;
        private System.Windows.Forms.CheckBox checkBoxDirectionVectors;
        private System.Windows.Forms.Button buttonPolygonHelp;
        private System.Windows.Forms.TabPage tabPageChainSpline;
        private Controls.ChainSplineControl chainSplineControl;
    }
}

