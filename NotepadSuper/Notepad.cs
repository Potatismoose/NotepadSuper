using System;
using System.IO;
using System.Windows.Forms;

namespace NotepadSuper
{
    public partial class Notepad : Form
    {
        private string filePath = null;
        public Notepad()
        {
            InitializeComponent();
            UpdateTitle();
        }

        private void nyttToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Text = string.Empty;
            filePath = null;
            UpdateTitle();
        }

        private void avslutaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void öppnaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
                filePath = openFileDialog.FileName;
                UpdateTitle();
            }

        }

        private void UpdateTitle()
        {
            string file = null;
            if (string.IsNullOrEmpty(filePath))
            {
                file = "Namnlös";
            }
            else
            {
                file = Path.GetFileName(filePath);
            }

            Text = $"{file} - Notepad";
        }

        private void sparaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return;
            }

            File.WriteAllText(filePath, textBox.Text);
        }
    }
}
