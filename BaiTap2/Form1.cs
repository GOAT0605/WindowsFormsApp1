using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;

namespace BaiTap2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void địnhDạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;
            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                richTextBox1.ForeColor = fontDlg.Color;
                richTextBox1.Font = fontDlg.Font;
            }
             
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void tạoVănBảnMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.SelectionFont = new Font("Tahoma", 14);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InstalledFontCollection installedFonts = new InstalledFontCollection();
            foreach (FontFamily font in installedFonts.Families)
            {
                tscbFont.Items.Add(font.Name);
            }
            int[] DSSo = new int[] { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (int size in DSSo)
            {
                tscbSize.Items.Add(size);
            }

            tscbFont.SelectedItem = "Tahoma";
            tscbSize.SelectedItem = 14;
            richTextBox1.SelectionFont = new Font("Tahoma", 14);
            
        }
      
        private void tscbFont_Click(object sender, EventArgs e)
        {
           // richTextBox1.Font = tscbFont.Font;


        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont.Bold)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style & ~FontStyle.Bold);

            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style | FontStyle.Bold);

            }
        }



        private void toolStripButton4_Click_1(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont.Bold)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style & ~FontStyle.Italic);

            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style | FontStyle.Italic);

            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont.Bold)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style & ~FontStyle.Underline);

            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style | FontStyle.Underline);

            }
        }
        private void openFile()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Rich text file|*.rtf|Plain Text File |*.txt";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string filepath = dlg.FileName;
                richTextBox1.LoadFile(filepath, RichTextBoxStreamType.PlainText);
            }

        }
        private void mởTậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void tscbSize_Click(object sender, EventArgs e)
        {
           
            
        }
        
        private void tscbSize_TextChanged(object sender, EventArgs e)
        {

        }
        private void SaveFIle()
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            string filename = "";
            saveDlg.Filter = "Rich text file|*.rtf|Plain Text File |*.txt";
            saveDlg.DefaultExt = "*.rtf";
            saveDlg.FilterIndex = 1;
            saveDlg.Title = "lưu file";
            DialogResult retval = saveDlg.ShowDialog();
            if (retval == DialogResult.OK)
                filename = saveDlg.FileName;
            else
                return;
            RichTextBoxStreamType stream_Type;
            if (saveDlg.FilterIndex == 2)
                stream_Type = RichTextBoxStreamType.PlainText;
            else
                stream_Type = RichTextBoxStreamType.RichText;
            richTextBox1.SaveFile(filename, stream_Type);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SaveFIle();
        }

        private void lưuNộiDungVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFIle();
        }

        private void tscbSize_TextUpdate(object sender, EventArgs e)
        {

        }

        private void tscbSize_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int selectedSize = (int)tscbSize.SelectedItem;


            richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, selectedSize);
        }

        private void tscbFont_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string selectedFont = tscbFont.SelectedItem.ToString();
            Font currentFont = richTextBox1.SelectionFont;

            if (currentFont != null)
            {
                Font newFont = new Font(selectedFont, currentFont.Size, currentFont.Style);
                richTextBox1.SelectionFont = newFont;
            }


        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
