using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace NotePad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            richTextBox1.Lines =  File.ReadAllLines(openFileDialog1.FileName);
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllLines(openFileDialog1.FileName, richTextBox1.Lines);
            }
            catch
            {
                //
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                saveFileDialog1.Filter = "TextFiles|(*.txt)";
                saveFileDialog1.ShowDialog();
                File.WriteAllLines(saveFileDialog1.FileName, richTextBox1.Lines);            
            }
            else
            {
                //
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox1.Font = fontDialog1.Font;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void exitToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                DialogResult result = MessageBox.Show("Save", "Would you like to save?", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == result)
                {
                    saveFileDialog1.Filter = "Text Files|(*.txt)";
                    saveFileDialog1.ShowDialog();
                    File.Create(saveFileDialog1.FileName);
                    Thread.Sleep(400);
                    string name = saveFileDialog1.FileName;
                    saveFileDialog1.Reset();
                    saveFileDialog1.Dispose();
                    File.WriteAllLines(name, richTextBox1.Lines);
                    Environment.Exit(0);
                }
                if (DialogResult.No == result)
                {
                    Environment.Exit(0);
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("About", "This Program was made for a speed code video and was coded by Jasoniful/Raid7", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font("Tahoma", 12, FontStyle.Regular);
        }
    }
}
