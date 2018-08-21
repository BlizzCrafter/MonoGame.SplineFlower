using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MonoGame.SplineFlower.Editor
{
    public partial class TriggerEditor : Form
    {
        public event Action<List<string>> UpdateTriggerNames = delegate { };

        public TriggerEditor(List<string> splineTrigger)
        {
            InitializeComponent();

            foreach (string trigger in splineTrigger)
            {
                ListViewItem item = new ListViewItem(trigger);
                listViewTrigger.Items.Add(item);
            }

            UpdateListViewColumn();
        }

        private void TriggerEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            List<string> finalTrigger = new List<string>(listViewTrigger.Items.Count);
            for (int i = 0; i < listViewTrigger.Items.Count; i++) finalTrigger.Add(listViewTrigger.Items[i].Text);
            UpdateTriggerNames.Invoke(finalTrigger);
        }

        private void buttonAdd_Click(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                if (listViewTrigger.FindItemWithText(textBoxName.Text) == null)
                {
                    listViewTrigger.Items.Add(textBoxName.Text);
                    UpdateListViewColumn();
                }
            }
        }

        private void buttonRemove_Click(object sender, System.EventArgs e)
        {
            if (listViewTrigger.SelectedItems != null)
            {
                listViewTrigger.SelectedItems[0].Remove();
                UpdateListViewColumn();
            }
        }

        private void UpdateListViewColumn()
        {
            listViewTrigger.Columns[0].Width = -2;
        }
    }
}
