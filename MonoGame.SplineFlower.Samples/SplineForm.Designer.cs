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
            tabControlEditorTabs = new TabControl();
            tabPageBezierSpline = new TabPage();
            comboBoxCenterTransformMode = new ComboBox();
            comboBoxWalkerMode = new ComboBox();
            buttonResetSplineWalker = new Button();
            buttonLoop = new Button();
            buttonAddCurveRight = new Button();
            buttonAddCurveLeft = new Button();
            splineControl = new MonoGame.SplineFlower.Samples.Controls.SplineControl();
            tabPageCatMulRom = new TabPage();
            comboBoxCenterTransformMode_2 = new ComboBox();
            catMulRomSpline = new MonoGame.SplineFlower.Samples.Controls.CatMulRomSplineControl();
            tabPageHermiteSpline = new TabPage();
            panelAddSubstractTangentValues = new Panel();
            buttonSubstractBias = new Button();
            buttonAddBias = new Button();
            buttonSubstractTension = new Button();
            buttonAddTension = new Button();
            labelAddBias = new Label();
            labelAddTension = new Label();
            hermiteSplineControl = new MonoGame.SplineFlower.Samples.Controls.HermiteSplineControl();
            tabPageChainSpline = new TabPage();
            labelRotate = new Label();
            buttonGenerate = new Button();
            labelCurves = new Label();
            numericUpDownCurveCount = new NumericUpDown();
            labelResolution = new Label();
            numericUpDownResolution = new NumericUpDown();
            buttonRotateStop = new Button();
            buttonRotateMinus = new Button();
            buttonRotatePlus = new Button();
            chainSplineControl = new MonoGame.SplineFlower.Samples.Controls.ChainSplineControl();
            tabPagePolygonSplineControl = new TabPage();
            buttonPolygonHelp = new Button();
            checkBoxShowPoints = new CheckBox();
            checkBoxShowLines = new CheckBox();
            checkBoxDirectionVectors = new CheckBox();
            checkBoxShowCurves = new CheckBox();
            polygonSplineControl1 = new MonoGame.SplineFlower.Samples.Controls.PolygonSplineControl();
            tabPageFindNearestPoint = new TabPage();
            labelAccuracy = new Label();
            numericUpDownAccuracy = new NumericUpDown();
            buttonCatMulRomFindTest = new Button();
            buttonLoopFindTest = new Button();
            findNearestPointControl1 = new MonoGame.SplineFlower.Samples.Controls.FindNearestPointControl();
            tabPageAdvancedControls = new TabPage();
            buttonHelp = new Button();
            advancedControls = new MonoGame.SplineFlower.Samples.Controls.AdvancedControl();
            tabPageInfo = new TabPage();
            richTextBoxLicense = new RichTextBox();
            statusStrip = new StatusStrip();
            toolStripDropDownButtonGitHub = new ToolStripDropDownButton();
            tabControlEditorTabs.SuspendLayout();
            tabPageBezierSpline.SuspendLayout();
            tabPageCatMulRom.SuspendLayout();
            tabPageHermiteSpline.SuspendLayout();
            panelAddSubstractTangentValues.SuspendLayout();
            tabPageChainSpline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCurveCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownResolution).BeginInit();
            tabPagePolygonSplineControl.SuspendLayout();
            tabPageFindNearestPoint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAccuracy).BeginInit();
            tabPageAdvancedControls.SuspendLayout();
            tabPageInfo.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlEditorTabs
            // 
            tabControlEditorTabs.Controls.Add(tabPageBezierSpline);
            tabControlEditorTabs.Controls.Add(tabPageCatMulRom);
            tabControlEditorTabs.Controls.Add(tabPageHermiteSpline);
            tabControlEditorTabs.Controls.Add(tabPageChainSpline);
            tabControlEditorTabs.Controls.Add(tabPagePolygonSplineControl);
            tabControlEditorTabs.Controls.Add(tabPageFindNearestPoint);
            tabControlEditorTabs.Controls.Add(tabPageAdvancedControls);
            tabControlEditorTabs.Controls.Add(tabPageInfo);
            tabControlEditorTabs.Dock = DockStyle.Fill;
            tabControlEditorTabs.Location = new Point(0, 0);
            tabControlEditorTabs.Name = "tabControlEditorTabs";
            tabControlEditorTabs.SelectedIndex = 0;
            tabControlEditorTabs.Size = new Size(782, 553);
            tabControlEditorTabs.TabIndex = 2;
            tabControlEditorTabs.SelectedIndexChanged += tabControlEditorTabs_SelectedIndexChanged;
            // 
            // tabPageBezierSpline
            // 
            tabPageBezierSpline.Controls.Add(comboBoxCenterTransformMode);
            tabPageBezierSpline.Controls.Add(comboBoxWalkerMode);
            tabPageBezierSpline.Controls.Add(buttonResetSplineWalker);
            tabPageBezierSpline.Controls.Add(buttonLoop);
            tabPageBezierSpline.Controls.Add(buttonAddCurveRight);
            tabPageBezierSpline.Controls.Add(buttonAddCurveLeft);
            tabPageBezierSpline.Controls.Add(splineControl);
            tabPageBezierSpline.Location = new Point(4, 29);
            tabPageBezierSpline.Name = "tabPageBezierSpline";
            tabPageBezierSpline.Size = new Size(774, 520);
            tabPageBezierSpline.TabIndex = 3;
            tabPageBezierSpline.Text = "Beziér Spline";
            tabPageBezierSpline.UseVisualStyleBackColor = true;
            // 
            // comboBoxCenterTransformMode
            // 
            comboBoxCenterTransformMode.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            comboBoxCenterTransformMode.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCenterTransformMode.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxCenterTransformMode.FormattingEnabled = true;
            comboBoxCenterTransformMode.Items.AddRange(new object[] { "None", "Rotate", "Scale", "ScaleRotate" });
            comboBoxCenterTransformMode.Location = new Point(3, 405);
            comboBoxCenterTransformMode.MaxDropDownItems = 3;
            comboBoxCenterTransformMode.Name = "comboBoxCenterTransformMode";
            comboBoxCenterTransformMode.Size = new Size(159, 26);
            comboBoxCenterTransformMode.TabIndex = 13;
            comboBoxCenterTransformMode.SelectedIndexChanged += comboBoxCenterTransformMode_SelectedIndexChanged;
            // 
            // comboBoxWalkerMode
            // 
            comboBoxWalkerMode.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            comboBoxWalkerMode.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxWalkerMode.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxWalkerMode.FormattingEnabled = true;
            comboBoxWalkerMode.Items.AddRange(new object[] { "Once", "Loop", "PingPong" });
            comboBoxWalkerMode.Location = new Point(591, 448);
            comboBoxWalkerMode.MaxDropDownItems = 3;
            comboBoxWalkerMode.Name = "comboBoxWalkerMode";
            comboBoxWalkerMode.Size = new Size(107, 26);
            comboBoxWalkerMode.TabIndex = 5;
            comboBoxWalkerMode.SelectedIndexChanged += comboBoxWalkerMode_SelectedIndexChanged;
            // 
            // buttonResetSplineWalker
            // 
            buttonResetSplineWalker.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonResetSplineWalker.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonResetSplineWalker.Location = new Point(591, 480);
            buttonResetSplineWalker.Name = "buttonResetSplineWalker";
            buttonResetSplineWalker.Size = new Size(180, 37);
            buttonResetSplineWalker.TabIndex = 4;
            buttonResetSplineWalker.Text = "Reset SplineWalker";
            buttonResetSplineWalker.UseVisualStyleBackColor = true;
            buttonResetSplineWalker.Click += buttonResetSplineWalker_Click;
            // 
            // buttonLoop
            // 
            buttonLoop.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonLoop.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonLoop.Location = new Point(704, 437);
            buttonLoop.Name = "buttonLoop";
            buttonLoop.Size = new Size(67, 37);
            buttonLoop.TabIndex = 3;
            buttonLoop.Text = "Loop";
            buttonLoop.UseVisualStyleBackColor = true;
            buttonLoop.Click += buttonLoop_Click;
            // 
            // buttonAddCurveRight
            // 
            buttonAddCurveRight.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonAddCurveRight.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonAddCurveRight.Location = new Point(3, 480);
            buttonAddCurveRight.Name = "buttonAddCurveRight";
            buttonAddCurveRight.Size = new Size(159, 37);
            buttonAddCurveRight.TabIndex = 2;
            buttonAddCurveRight.Text = "Add Curve Right";
            buttonAddCurveRight.UseVisualStyleBackColor = true;
            buttonAddCurveRight.Click += buttonAddCurveRight_Click;
            // 
            // buttonAddCurveLeft
            // 
            buttonAddCurveLeft.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonAddCurveLeft.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonAddCurveLeft.Location = new Point(3, 437);
            buttonAddCurveLeft.Name = "buttonAddCurveLeft";
            buttonAddCurveLeft.Size = new Size(159, 37);
            buttonAddCurveLeft.TabIndex = 1;
            buttonAddCurveLeft.Text = "Add Curve Left";
            buttonAddCurveLeft.UseVisualStyleBackColor = true;
            buttonAddCurveLeft.Click += buttonAddCurve_Click;
            // 
            // splineControl
            // 
            splineControl.BackColor = Color.GreenYellow;
            splineControl.Dock = DockStyle.Fill;
            splineControl.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            splineControl.ForeColor = Color.DarkOrange;
            splineControl.Location = new Point(0, 0);
            splineControl.MouseHoverUpdatesOnly = false;
            splineControl.MySpline = null;
            splineControl.Name = "splineControl";
            splineControl.SetCenterTransformMode = Samples.Controls.TransformControl.CenterTransformMode.ScaleRotate;
            splineControl.Size = new Size(774, 520);
            splineControl.TabIndex = 12;
            splineControl.Text = "Bézier Spline";
            // 
            // tabPageCatMulRom
            // 
            tabPageCatMulRom.Controls.Add(comboBoxCenterTransformMode_2);
            tabPageCatMulRom.Controls.Add(catMulRomSpline);
            tabPageCatMulRom.Location = new Point(4, 29);
            tabPageCatMulRom.Name = "tabPageCatMulRom";
            tabPageCatMulRom.Padding = new Padding(3);
            tabPageCatMulRom.Size = new Size(774, 520);
            tabPageCatMulRom.TabIndex = 0;
            tabPageCatMulRom.Text = "CatMulRom Spline";
            tabPageCatMulRom.UseVisualStyleBackColor = true;
            // 
            // comboBoxCenterTransformMode_2
            // 
            comboBoxCenterTransformMode_2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            comboBoxCenterTransformMode_2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCenterTransformMode_2.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxCenterTransformMode_2.FormattingEnabled = true;
            comboBoxCenterTransformMode_2.Items.AddRange(new object[] { "None", "Rotate", "Scale", "ScaleRotate" });
            comboBoxCenterTransformMode_2.Location = new Point(6, 486);
            comboBoxCenterTransformMode_2.MaxDropDownItems = 3;
            comboBoxCenterTransformMode_2.Name = "comboBoxCenterTransformMode_2";
            comboBoxCenterTransformMode_2.Size = new Size(159, 26);
            comboBoxCenterTransformMode_2.TabIndex = 14;
            comboBoxCenterTransformMode_2.SelectedIndexChanged += comboBoxCenterTransformMode_2_SelectedIndexChanged;
            // 
            // catMulRomSpline
            // 
            catMulRomSpline.BackColor = Color.MediumSlateBlue;
            catMulRomSpline.Dock = DockStyle.Fill;
            catMulRomSpline.Font = new Font("Consolas", 12F, FontStyle.Bold);
            catMulRomSpline.ForeColor = Color.Orange;
            catMulRomSpline.Location = new Point(3, 3);
            catMulRomSpline.MouseHoverUpdatesOnly = false;
            catMulRomSpline.MySpline = null;
            catMulRomSpline.Name = "catMulRomSpline";
            catMulRomSpline.SetCenterTransformMode = Samples.Controls.TransformControl.CenterTransformMode.ScaleRotate;
            catMulRomSpline.Size = new Size(768, 514);
            catMulRomSpline.TabIndex = 0;
            catMulRomSpline.Text = "CatMulRom Spline";
            // 
            // tabPageHermiteSpline
            // 
            tabPageHermiteSpline.Controls.Add(panelAddSubstractTangentValues);
            tabPageHermiteSpline.Controls.Add(hermiteSplineControl);
            tabPageHermiteSpline.Location = new Point(4, 29);
            tabPageHermiteSpline.Name = "tabPageHermiteSpline";
            tabPageHermiteSpline.Size = new Size(774, 520);
            tabPageHermiteSpline.TabIndex = 8;
            tabPageHermiteSpline.Text = "Hermite Spline";
            tabPageHermiteSpline.UseVisualStyleBackColor = true;
            // 
            // panelAddSubstractTangentValues
            // 
            panelAddSubstractTangentValues.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            panelAddSubstractTangentValues.BackColor = Color.CornflowerBlue;
            panelAddSubstractTangentValues.Controls.Add(buttonSubstractBias);
            panelAddSubstractTangentValues.Controls.Add(buttonAddBias);
            panelAddSubstractTangentValues.Controls.Add(buttonSubstractTension);
            panelAddSubstractTangentValues.Controls.Add(buttonAddTension);
            panelAddSubstractTangentValues.Controls.Add(labelAddBias);
            panelAddSubstractTangentValues.Controls.Add(labelAddTension);
            panelAddSubstractTangentValues.Location = new Point(621, 453);
            panelAddSubstractTangentValues.Name = "panelAddSubstractTangentValues";
            panelAddSubstractTangentValues.Size = new Size(150, 64);
            panelAddSubstractTangentValues.TabIndex = 6;
            // 
            // buttonSubstractBias
            // 
            buttonSubstractBias.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSubstractBias.Location = new Point(39, 29);
            buttonSubstractBias.Name = "buttonSubstractBias";
            buttonSubstractBias.Size = new Size(28, 30);
            buttonSubstractBias.TabIndex = 8;
            buttonSubstractBias.Text = "-";
            buttonSubstractBias.UseVisualStyleBackColor = true;
            buttonSubstractBias.Click += buttonSubstractBias_Click;
            // 
            // buttonAddBias
            // 
            buttonAddBias.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonAddBias.Location = new Point(6, 29);
            buttonAddBias.Name = "buttonAddBias";
            buttonAddBias.Size = new Size(28, 30);
            buttonAddBias.TabIndex = 7;
            buttonAddBias.Text = "+";
            buttonAddBias.UseVisualStyleBackColor = true;
            buttonAddBias.Click += buttonAddBias_Click;
            // 
            // buttonSubstractTension
            // 
            buttonSubstractTension.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSubstractTension.Location = new Point(117, 29);
            buttonSubstractTension.Name = "buttonSubstractTension";
            buttonSubstractTension.Size = new Size(28, 30);
            buttonSubstractTension.TabIndex = 6;
            buttonSubstractTension.Text = "-";
            buttonSubstractTension.UseVisualStyleBackColor = true;
            buttonSubstractTension.Click += buttonSubstractTension_Click;
            // 
            // buttonAddTension
            // 
            buttonAddTension.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonAddTension.Location = new Point(84, 29);
            buttonAddTension.Name = "buttonAddTension";
            buttonAddTension.Size = new Size(28, 30);
            buttonAddTension.TabIndex = 5;
            buttonAddTension.Text = "+";
            buttonAddTension.UseVisualStyleBackColor = true;
            buttonAddTension.Click += buttonAddTension_Click;
            // 
            // labelAddBias
            // 
            labelAddBias.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            labelAddBias.AutoSize = true;
            labelAddBias.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelAddBias.ForeColor = Color.White;
            labelAddBias.Location = new Point(3, 9);
            labelAddBias.Name = "labelAddBias";
            labelAddBias.Size = new Size(45, 20);
            labelAddBias.TabIndex = 4;
            labelAddBias.Text = "Bias";
            // 
            // labelAddTension
            // 
            labelAddTension.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            labelAddTension.AutoSize = true;
            labelAddTension.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelAddTension.ForeColor = Color.White;
            labelAddTension.Location = new Point(31, 9);
            labelAddTension.Name = "labelAddTension";
            labelAddTension.Size = new Size(72, 20);
            labelAddTension.TabIndex = 2;
            labelAddTension.Text = "Tension";
            // 
            // hermiteSplineControl
            // 
            hermiteSplineControl.BackColor = Color.Firebrick;
            hermiteSplineControl.Dock = DockStyle.Fill;
            hermiteSplineControl.Font = new Font("Consolas", 12F, FontStyle.Bold);
            hermiteSplineControl.ForeColor = Color.LightSalmon;
            hermiteSplineControl.Location = new Point(0, 0);
            hermiteSplineControl.MouseHoverUpdatesOnly = false;
            hermiteSplineControl.MySpline = null;
            hermiteSplineControl.Name = "hermiteSplineControl";
            hermiteSplineControl.SetCenterTransformMode = Samples.Controls.TransformControl.CenterTransformMode.ScaleRotate;
            hermiteSplineControl.Size = new Size(774, 520);
            hermiteSplineControl.TabIndex = 0;
            hermiteSplineControl.Text = "Hermite Spline";
            // 
            // tabPageChainSpline
            // 
            tabPageChainSpline.Controls.Add(labelRotate);
            tabPageChainSpline.Controls.Add(buttonGenerate);
            tabPageChainSpline.Controls.Add(labelCurves);
            tabPageChainSpline.Controls.Add(numericUpDownCurveCount);
            tabPageChainSpline.Controls.Add(labelResolution);
            tabPageChainSpline.Controls.Add(numericUpDownResolution);
            tabPageChainSpline.Controls.Add(buttonRotateStop);
            tabPageChainSpline.Controls.Add(buttonRotateMinus);
            tabPageChainSpline.Controls.Add(buttonRotatePlus);
            tabPageChainSpline.Controls.Add(chainSplineControl);
            tabPageChainSpline.Location = new Point(4, 29);
            tabPageChainSpline.Name = "tabPageChainSpline";
            tabPageChainSpline.Size = new Size(774, 520);
            tabPageChainSpline.TabIndex = 9;
            tabPageChainSpline.Text = "ChainSpline";
            tabPageChainSpline.UseVisualStyleBackColor = true;
            // 
            // labelRotate
            // 
            labelRotate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelRotate.AutoSize = true;
            labelRotate.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelRotate.Location = new Point(3, 462);
            labelRotate.Name = "labelRotate";
            labelRotate.Size = new Size(63, 20);
            labelRotate.TabIndex = 13;
            labelRotate.Text = "Rotate";
            // 
            // buttonGenerate
            // 
            buttonGenerate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonGenerate.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonGenerate.Location = new Point(464, 485);
            buttonGenerate.Name = "buttonGenerate";
            buttonGenerate.Size = new Size(50, 25);
            buttonGenerate.TabIndex = 12;
            buttonGenerate.Text = "OK";
            buttonGenerate.UseVisualStyleBackColor = true;
            buttonGenerate.Click += buttonGenerate_Click;
            // 
            // labelCurves
            // 
            labelCurves.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            labelCurves.AutoSize = true;
            labelCurves.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCurves.Location = new Point(520, 462);
            labelCurves.Name = "labelCurves";
            labelCurves.Size = new Size(63, 20);
            labelCurves.TabIndex = 11;
            labelCurves.Text = "Curves";
            // 
            // numericUpDownCurveCount
            // 
            numericUpDownCurveCount.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            numericUpDownCurveCount.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numericUpDownCurveCount.Location = new Point(520, 485);
            numericUpDownCurveCount.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            numericUpDownCurveCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownCurveCount.Name = "numericUpDownCurveCount";
            numericUpDownCurveCount.Size = new Size(120, 27);
            numericUpDownCurveCount.TabIndex = 10;
            numericUpDownCurveCount.TextAlign = HorizontalAlignment.Center;
            numericUpDownCurveCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // labelResolution
            // 
            labelResolution.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            labelResolution.AutoSize = true;
            labelResolution.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelResolution.Location = new Point(646, 462);
            labelResolution.Name = "labelResolution";
            labelResolution.Size = new Size(99, 20);
            labelResolution.TabIndex = 9;
            labelResolution.Text = "Resolution";
            // 
            // numericUpDownResolution
            // 
            numericUpDownResolution.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            numericUpDownResolution.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numericUpDownResolution.Location = new Point(646, 485);
            numericUpDownResolution.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDownResolution.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownResolution.Name = "numericUpDownResolution";
            numericUpDownResolution.Size = new Size(120, 27);
            numericUpDownResolution.TabIndex = 8;
            numericUpDownResolution.TextAlign = HorizontalAlignment.Center;
            numericUpDownResolution.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDownResolution.ValueChanged += numericUpDownResolution_ValueChanged;
            // 
            // buttonRotateStop
            // 
            buttonRotateStop.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonRotateStop.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonRotateStop.Location = new Point(34, 487);
            buttonRotateStop.Name = "buttonRotateStop";
            buttonRotateStop.Size = new Size(25, 25);
            buttonRotateStop.TabIndex = 3;
            buttonRotateStop.Text = "■";
            buttonRotateStop.UseVisualStyleBackColor = true;
            buttonRotateStop.Click += buttonRotateStop_Click;
            // 
            // buttonRotateMinus
            // 
            buttonRotateMinus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonRotateMinus.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonRotateMinus.Location = new Point(65, 487);
            buttonRotateMinus.Name = "buttonRotateMinus";
            buttonRotateMinus.Size = new Size(25, 25);
            buttonRotateMinus.TabIndex = 2;
            buttonRotateMinus.Text = "-";
            buttonRotateMinus.UseVisualStyleBackColor = true;
            buttonRotateMinus.Click += buttonRotateMinus_Click;
            // 
            // buttonRotatePlus
            // 
            buttonRotatePlus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonRotatePlus.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonRotatePlus.Location = new Point(3, 487);
            buttonRotatePlus.Name = "buttonRotatePlus";
            buttonRotatePlus.Size = new Size(25, 25);
            buttonRotatePlus.TabIndex = 1;
            buttonRotatePlus.Text = "+";
            buttonRotatePlus.UseVisualStyleBackColor = true;
            buttonRotatePlus.Click += buttonRotatePlus_Click;
            // 
            // chainSplineControl
            // 
            chainSplineControl.BackColor = Color.FromArgb(69, 129, 142);
            chainSplineControl.Dock = DockStyle.Fill;
            chainSplineControl.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chainSplineControl.ForeColor = Color.FromArgb(169, 182, 105);
            chainSplineControl.Location = new Point(0, 0);
            chainSplineControl.MouseHoverUpdatesOnly = false;
            chainSplineControl.MySpline = null;
            chainSplineControl.Name = "chainSplineControl";
            chainSplineControl.SetCenterTransformMode = Samples.Controls.TransformControl.CenterTransformMode.ScaleRotate;
            chainSplineControl.Size = new Size(774, 520);
            chainSplineControl.TabIndex = 0;
            chainSplineControl.Text = "Chain Spline";
            // 
            // tabPagePolygonSplineControl
            // 
            tabPagePolygonSplineControl.Controls.Add(buttonPolygonHelp);
            tabPagePolygonSplineControl.Controls.Add(checkBoxShowPoints);
            tabPagePolygonSplineControl.Controls.Add(checkBoxShowLines);
            tabPagePolygonSplineControl.Controls.Add(checkBoxDirectionVectors);
            tabPagePolygonSplineControl.Controls.Add(checkBoxShowCurves);
            tabPagePolygonSplineControl.Controls.Add(polygonSplineControl1);
            tabPagePolygonSplineControl.Location = new Point(4, 29);
            tabPagePolygonSplineControl.Name = "tabPagePolygonSplineControl";
            tabPagePolygonSplineControl.Padding = new Padding(3);
            tabPagePolygonSplineControl.Size = new Size(774, 520);
            tabPagePolygonSplineControl.TabIndex = 7;
            tabPagePolygonSplineControl.Text = "PolygonSpline";
            tabPagePolygonSplineControl.UseVisualStyleBackColor = true;
            // 
            // buttonPolygonHelp
            // 
            buttonPolygonHelp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonPolygonHelp.Font = new Font("Consolas", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonPolygonHelp.Location = new Point(737, 6);
            buttonPolygonHelp.Name = "buttonPolygonHelp";
            buttonPolygonHelp.Size = new Size(31, 32);
            buttonPolygonHelp.TabIndex = 5;
            buttonPolygonHelp.Text = "?";
            buttonPolygonHelp.UseVisualStyleBackColor = true;
            buttonPolygonHelp.Click += buttonPolygonHelp_Click;
            // 
            // checkBoxShowPoints
            // 
            checkBoxShowPoints.AutoSize = true;
            checkBoxShowPoints.Location = new Point(412, 6);
            checkBoxShowPoints.Name = "checkBoxShowPoints";
            checkBoxShowPoints.Size = new Size(110, 24);
            checkBoxShowPoints.TabIndex = 4;
            checkBoxShowPoints.Text = "Show Points";
            checkBoxShowPoints.UseVisualStyleBackColor = true;
            checkBoxShowPoints.CheckedChanged += checkBoxShowPoints_CheckedChanged;
            // 
            // checkBoxShowLines
            // 
            checkBoxShowLines.AutoSize = true;
            checkBoxShowLines.Location = new Point(304, 6);
            checkBoxShowLines.Name = "checkBoxShowLines";
            checkBoxShowLines.Size = new Size(104, 24);
            checkBoxShowLines.TabIndex = 3;
            checkBoxShowLines.Text = "Show Lines";
            checkBoxShowLines.UseVisualStyleBackColor = true;
            checkBoxShowLines.CheckedChanged += checkBoxShowLines_CheckedChanged;
            // 
            // checkBoxDirectionVectors
            // 
            checkBoxDirectionVectors.AutoSize = true;
            checkBoxDirectionVectors.Location = new Point(122, 6);
            checkBoxDirectionVectors.Name = "checkBoxDirectionVectors";
            checkBoxDirectionVectors.Size = new Size(184, 24);
            checkBoxDirectionVectors.TabIndex = 2;
            checkBoxDirectionVectors.Text = "Show Direction Vectors";
            checkBoxDirectionVectors.UseVisualStyleBackColor = true;
            checkBoxDirectionVectors.CheckedChanged += checkBoxDirectionVectors_CheckedChanged;
            // 
            // checkBoxShowCurves
            // 
            checkBoxShowCurves.AutoSize = true;
            checkBoxShowCurves.Location = new Point(8, 6);
            checkBoxShowCurves.Name = "checkBoxShowCurves";
            checkBoxShowCurves.Size = new Size(114, 24);
            checkBoxShowCurves.TabIndex = 1;
            checkBoxShowCurves.Text = "Show Curves";
            checkBoxShowCurves.UseVisualStyleBackColor = true;
            checkBoxShowCurves.CheckedChanged += checkBoxShowCurves_CheckedChanged;
            // 
            // polygonSplineControl1
            // 
            polygonSplineControl1.Dock = DockStyle.Fill;
            polygonSplineControl1.Font = new Font("Consolas", 12F, FontStyle.Bold);
            polygonSplineControl1.Location = new Point(3, 3);
            polygonSplineControl1.MouseHoverUpdatesOnly = false;
            polygonSplineControl1.MySpline = null;
            polygonSplineControl1.Name = "polygonSplineControl1";
            polygonSplineControl1.SetCenterTransformMode = Samples.Controls.TransformControl.CenterTransformMode.ScaleRotate;
            polygonSplineControl1.Size = new Size(768, 514);
            polygonSplineControl1.TabIndex = 0;
            polygonSplineControl1.Text = "Polygon Spline";
            // 
            // tabPageFindNearestPoint
            // 
            tabPageFindNearestPoint.Controls.Add(labelAccuracy);
            tabPageFindNearestPoint.Controls.Add(numericUpDownAccuracy);
            tabPageFindNearestPoint.Controls.Add(buttonCatMulRomFindTest);
            tabPageFindNearestPoint.Controls.Add(buttonLoopFindTest);
            tabPageFindNearestPoint.Controls.Add(findNearestPointControl1);
            tabPageFindNearestPoint.Location = new Point(4, 29);
            tabPageFindNearestPoint.Name = "tabPageFindNearestPoint";
            tabPageFindNearestPoint.Padding = new Padding(3);
            tabPageFindNearestPoint.Size = new Size(774, 520);
            tabPageFindNearestPoint.TabIndex = 6;
            tabPageFindNearestPoint.Text = "FindNearestPoint";
            tabPageFindNearestPoint.UseVisualStyleBackColor = true;
            // 
            // labelAccuracy
            // 
            labelAccuracy.AutoSize = true;
            labelAccuracy.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelAccuracy.Location = new Point(8, 466);
            labelAccuracy.Name = "labelAccuracy";
            labelAccuracy.Size = new Size(81, 20);
            labelAccuracy.TabIndex = 7;
            labelAccuracy.Text = "Accuracy";
            // 
            // numericUpDownAccuracy
            // 
            numericUpDownAccuracy.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numericUpDownAccuracy.Increment = new decimal(new int[] { 20, 0, 0, 0 });
            numericUpDownAccuracy.Location = new Point(8, 489);
            numericUpDownAccuracy.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDownAccuracy.Name = "numericUpDownAccuracy";
            numericUpDownAccuracy.Size = new Size(120, 27);
            numericUpDownAccuracy.TabIndex = 6;
            numericUpDownAccuracy.TextAlign = HorizontalAlignment.Center;
            numericUpDownAccuracy.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDownAccuracy.ValueChanged += numericUpDownAccuracy_ValueChanged;
            // 
            // buttonCatMulRomFindTest
            // 
            buttonCatMulRomFindTest.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCatMulRomFindTest.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonCatMulRomFindTest.Location = new Point(657, 432);
            buttonCatMulRomFindTest.Name = "buttonCatMulRomFindTest";
            buttonCatMulRomFindTest.Size = new Size(111, 37);
            buttonCatMulRomFindTest.TabIndex = 5;
            buttonCatMulRomFindTest.Text = "CatMulRom";
            buttonCatMulRomFindTest.UseVisualStyleBackColor = true;
            buttonCatMulRomFindTest.Click += buttonCatMulRomFindTest_Click;
            // 
            // buttonLoopFindTest
            // 
            buttonLoopFindTest.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonLoopFindTest.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonLoopFindTest.Location = new Point(657, 475);
            buttonLoopFindTest.Name = "buttonLoopFindTest";
            buttonLoopFindTest.Size = new Size(111, 37);
            buttonLoopFindTest.TabIndex = 4;
            buttonLoopFindTest.Text = "Loop";
            buttonLoopFindTest.UseVisualStyleBackColor = true;
            buttonLoopFindTest.Click += buttonLoopFindTest_Click;
            // 
            // findNearestPointControl1
            // 
            findNearestPointControl1.BackColor = Color.Khaki;
            findNearestPointControl1.Dock = DockStyle.Fill;
            findNearestPointControl1.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            findNearestPointControl1.ForeColor = Color.CadetBlue;
            findNearestPointControl1.Location = new Point(3, 3);
            findNearestPointControl1.MouseHoverUpdatesOnly = false;
            findNearestPointControl1.MySpline = null;
            findNearestPointControl1.Name = "findNearestPointControl1";
            findNearestPointControl1.SetCenterTransformMode = Samples.Controls.TransformControl.CenterTransformMode.ScaleRotate;
            findNearestPointControl1.Size = new Size(768, 514);
            findNearestPointControl1.TabIndex = 0;
            findNearestPointControl1.Text = "Find Nearest Point On Spline";
            // 
            // tabPageAdvancedControls
            // 
            tabPageAdvancedControls.Controls.Add(buttonHelp);
            tabPageAdvancedControls.Controls.Add(advancedControls);
            tabPageAdvancedControls.Location = new Point(4, 29);
            tabPageAdvancedControls.Name = "tabPageAdvancedControls";
            tabPageAdvancedControls.Padding = new Padding(3);
            tabPageAdvancedControls.Size = new Size(774, 520);
            tabPageAdvancedControls.TabIndex = 5;
            tabPageAdvancedControls.Text = "AdvancedControls";
            tabPageAdvancedControls.UseVisualStyleBackColor = true;
            // 
            // buttonHelp
            // 
            buttonHelp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonHelp.Font = new Font("Consolas", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonHelp.Location = new Point(735, 6);
            buttonHelp.Name = "buttonHelp";
            buttonHelp.Size = new Size(31, 32);
            buttonHelp.TabIndex = 1;
            buttonHelp.Text = "?";
            buttonHelp.UseVisualStyleBackColor = true;
            buttonHelp.Click += buttonHelp_Click;
            // 
            // advancedControls
            // 
            advancedControls.BackColor = Color.Tan;
            advancedControls.Dock = DockStyle.Fill;
            advancedControls.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            advancedControls.ForeColor = Color.GhostWhite;
            advancedControls.Location = new Point(3, 3);
            advancedControls.MouseHoverUpdatesOnly = false;
            advancedControls.MySpline = null;
            advancedControls.Name = "advancedControls";
            advancedControls.SetCenterTransformMode = Samples.Controls.TransformControl.CenterTransformMode.ScaleRotate;
            advancedControls.Size = new Size(768, 514);
            advancedControls.TabIndex = 0;
            advancedControls.Text = "Advanced Controls";
            // 
            // tabPageInfo
            // 
            tabPageInfo.Controls.Add(richTextBoxLicense);
            tabPageInfo.Controls.Add(statusStrip);
            tabPageInfo.Location = new Point(4, 29);
            tabPageInfo.Name = "tabPageInfo";
            tabPageInfo.Padding = new Padding(3);
            tabPageInfo.Size = new Size(774, 520);
            tabPageInfo.TabIndex = 4;
            tabPageInfo.Text = "Info";
            tabPageInfo.UseVisualStyleBackColor = true;
            // 
            // richTextBoxLicense
            // 
            richTextBoxLicense.BorderStyle = BorderStyle.None;
            richTextBoxLicense.Dock = DockStyle.Fill;
            richTextBoxLicense.Location = new Point(3, 3);
            richTextBoxLicense.Name = "richTextBoxLicense";
            richTextBoxLicense.Size = new Size(768, 477);
            richTextBoxLicense.TabIndex = 2;
            richTextBoxLicense.Text = resources.GetString("richTextBoxLicense.Text");
            richTextBoxLicense.ZoomFactor = 1.5F;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripDropDownButtonGitHub });
            statusStrip.Location = new Point(3, 480);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(768, 37);
            statusStrip.SizingGrip = false;
            statusStrip.TabIndex = 3;
            // 
            // toolStripDropDownButtonGitHub
            // 
            toolStripDropDownButtonGitHub.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            toolStripDropDownButtonGitHub.Image = (Image)resources.GetObject("toolStripDropDownButtonGitHub.Image");
            toolStripDropDownButtonGitHub.ImageTransparentColor = Color.Magenta;
            toolStripDropDownButtonGitHub.Name = "toolStripDropDownButtonGitHub";
            toolStripDropDownButtonGitHub.Size = new Size(318, 35);
            toolStripDropDownButtonGitHub.Text = "MonoGame.SplineFlower";
            toolStripDropDownButtonGitHub.Click += toolStripDropDownButtonGitHub_Click;
            // 
            // SplineForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(782, 553);
            Controls.Add(tabControlEditorTabs);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SplineForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MonoGame.SplineFlower";
            Load += SplineEditorForm_Load;
            ResizeEnd += SplineEditorForm_ResizeEnd;
            Resize += SplineEditorForm_Resize;
            tabControlEditorTabs.ResumeLayout(false);
            tabPageBezierSpline.ResumeLayout(false);
            tabPageCatMulRom.ResumeLayout(false);
            tabPageHermiteSpline.ResumeLayout(false);
            panelAddSubstractTangentValues.ResumeLayout(false);
            panelAddSubstractTangentValues.PerformLayout();
            tabPageChainSpline.ResumeLayout(false);
            tabPageChainSpline.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCurveCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownResolution).EndInit();
            tabPagePolygonSplineControl.ResumeLayout(false);
            tabPagePolygonSplineControl.PerformLayout();
            tabPageFindNearestPoint.ResumeLayout(false);
            tabPageFindNearestPoint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAccuracy).EndInit();
            tabPageAdvancedControls.ResumeLayout(false);
            tabPageInfo.ResumeLayout(false);
            tabPageInfo.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);

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
        private System.Windows.Forms.Button buttonRotatePlus;
        private System.Windows.Forms.Button buttonRotateMinus;
        private System.Windows.Forms.Button buttonRotateStop;
        private System.Windows.Forms.Label labelResolution;
        public System.Windows.Forms.NumericUpDown numericUpDownResolution;
        private System.Windows.Forms.Label labelCurves;
        public System.Windows.Forms.NumericUpDown numericUpDownCurveCount;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Label labelRotate;
    }
}

