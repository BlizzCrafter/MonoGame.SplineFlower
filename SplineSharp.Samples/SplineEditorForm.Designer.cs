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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplineEditorForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAddPoint = new System.Windows.Forms.ToolStripButton();
            this.tabControlEditorTabs = new System.Windows.Forms.TabControl();
            this.tabPageLineEditor = new System.Windows.Forms.TabPage();
            this.splineEditorLine = new SplineSharp.Samples.SplineEditorLine();
            this.tabPageCurveEditor = new System.Windows.Forms.TabPage();
            this.splineEditorCurve = new SplineSharp.Samples.SplineEditorCurve();
            this.toolStrip1.SuspendLayout();
            this.tabControlEditorTabs.SuspendLayout();
            this.tabPageLineEditor.SuspendLayout();
            this.tabPageCurveEditor.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddPoint});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(482, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonAddPoint
            // 
            this.toolStripButtonAddPoint.Checked = true;
            this.toolStripButtonAddPoint.CheckOnClick = true;
            this.toolStripButtonAddPoint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonAddPoint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonAddPoint.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddPoint.Image")));
            this.toolStripButtonAddPoint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddPoint.Name = "toolStripButtonAddPoint";
            this.toolStripButtonAddPoint.Size = new System.Drawing.Size(78, 24);
            this.toolStripButtonAddPoint.Text = "Add Point";
            this.toolStripButtonAddPoint.CheckedChanged += new System.EventHandler(this.toolStripButtonAddPoint_CheckedChanged);
            // 
            // tabControlEditorTabs
            // 
            this.tabControlEditorTabs.Controls.Add(this.tabPageLineEditor);
            this.tabControlEditorTabs.Controls.Add(this.tabPageCurveEditor);
            this.tabControlEditorTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlEditorTabs.Location = new System.Drawing.Point(0, 27);
            this.tabControlEditorTabs.Name = "tabControlEditorTabs";
            this.tabControlEditorTabs.SelectedIndex = 0;
            this.tabControlEditorTabs.Size = new System.Drawing.Size(482, 426);
            this.tabControlEditorTabs.TabIndex = 2;
            // 
            // tabPageLineEditor
            // 
            this.tabPageLineEditor.Controls.Add(this.splineEditorLine);
            this.tabPageLineEditor.Location = new System.Drawing.Point(4, 25);
            this.tabPageLineEditor.Name = "tabPageLineEditor";
            this.tabPageLineEditor.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLineEditor.Size = new System.Drawing.Size(474, 397);
            this.tabPageLineEditor.TabIndex = 0;
            this.tabPageLineEditor.Text = "Line Editor";
            this.tabPageLineEditor.UseVisualStyleBackColor = true;
            // 
            // splineEditorLine
            // 
            this.splineEditorLine.AddPointsMode = true;
            this.splineEditorLine.BackColor = System.Drawing.Color.Lavender;
            this.splineEditorLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splineEditorLine.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splineEditorLine.ForeColor = System.Drawing.Color.CadetBlue;
            this.splineEditorLine.Location = new System.Drawing.Point(3, 3);
            this.splineEditorLine.MyLine = null;
            this.splineEditorLine.Name = "splineEditorLine";
            this.splineEditorLine.Size = new System.Drawing.Size(468, 391);
            this.splineEditorLine.TabIndex = 0;
            this.splineEditorLine.Text = "Line Editor Sample";
            this.splineEditorLine.TryGetTransformFromPosition = null;
            // 
            // tabPageCurveEditor
            // 
            this.tabPageCurveEditor.Controls.Add(this.splineEditorCurve);
            this.tabPageCurveEditor.Location = new System.Drawing.Point(4, 25);
            this.tabPageCurveEditor.Name = "tabPageCurveEditor";
            this.tabPageCurveEditor.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCurveEditor.Size = new System.Drawing.Size(474, 397);
            this.tabPageCurveEditor.TabIndex = 1;
            this.tabPageCurveEditor.Text = "Curve Editor";
            this.tabPageCurveEditor.UseVisualStyleBackColor = true;
            // 
            // splineEditorCurve
            // 
            this.splineEditorCurve.AddPointsMode = true;
            this.splineEditorCurve.BackColor = System.Drawing.Color.LavenderBlush;
            this.splineEditorCurve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splineEditorCurve.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splineEditorCurve.Location = new System.Drawing.Point(3, 3);
            this.splineEditorCurve.Name = "splineEditorCurve";
            this.splineEditorCurve.Size = new System.Drawing.Size(468, 391);
            this.splineEditorCurve.TabIndex = 0;
            this.splineEditorCurve.Text = "Curve Editor Sample";
            this.splineEditorCurve.TryGetTransformFromPosition = null;
            // 
            // SplineEditorForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(482, 453);
            this.Controls.Add(this.tabControlEditorTabs);
            this.Controls.Add(this.toolStrip1);
            this.Name = "SplineEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spline Editor";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControlEditorTabs.ResumeLayout(false);
            this.tabPageLineEditor.ResumeLayout(false);
            this.tabPageCurveEditor.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SplineEditorLine splineEditorLine;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddPoint;
        private System.Windows.Forms.TabControl tabControlEditorTabs;
        private System.Windows.Forms.TabPage tabPageLineEditor;
        private System.Windows.Forms.TabPage tabPageCurveEditor;
        private SplineEditorCurve splineEditorCurve;
    }
}

