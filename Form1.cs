using System;
using System.IO;
using System.Windows.Forms;

namespace TextOpener
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt",
                Title = "Select a text file"
            };

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] lines = File.ReadAllLines(openFileDialog.FileName);

                    foreach (var line in lines)
                    {
                        DialogResult result = MessageBox.Show(line, "Line content: ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                        if (result == DialogResult.Cancel)
                        {
                            MessageBox.Show("Interruption requested",
                        "Reading cancelled",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error while opening the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
