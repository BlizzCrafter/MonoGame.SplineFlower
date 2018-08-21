using System;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace MonoGame.SplineFlower.Editor.Controls.ToolStrip
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public partial class ToolStripNumericUpDown : ToolStripControlHost
    {
        public event EventHandler ValueChanged;

        public NumericUpDown NumericUpDown
        {
            get { return (NumericUpDown)Control; }
        }

        public decimal Value
        {
            get { return NumericUpDown.Value; }
            set { NumericUpDown.Value = value; }
        }

        public decimal Minimum
        {
            get { return NumericUpDown.Minimum; }
            set { NumericUpDown.Minimum = value; }
        }

        public decimal Maximum
        {
            get { return NumericUpDown.Maximum; }
            set { NumericUpDown.Maximum = value; }
        }

        public ToolStripNumericUpDown() : base(new NumericUpDown())
        {
            InitializeComponent();
            NumericUpDown.ValueChanged += NumericUpDown_ValueChanged;            
        }
        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ValueChanged?.Invoke(sender, e);
        }
    }
}
