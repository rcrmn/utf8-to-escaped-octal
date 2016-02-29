using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UTF8_escape_C
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string filePath in files)
            {
                Console.WriteLine(filePath);

                string outName = Path.GetFileNameWithoutExtension(filePath) + "_escaped";
                string outPath = Path.GetDirectoryName(filePath) + "\\" + outName + Path.GetExtension(filePath);

                FileStream inStream = new FileStream(filePath, FileMode.Open);
                // Check for BOM
                for (int i = 0; i < 3; ++i)
                {
                    Int32 c = inStream.ReadByte();
                    if (c < 0)
                    {
                        inStream.Seek(0, SeekOrigin.Begin);
                        break;
                    }
                    if (!((i == 0 && c == 0xef)
                        || (i == 1 && c == 0xbb)
                        || (i == 2 && c == 0xbf)))
                    {
                        inStream.Seek(0, SeekOrigin.Begin);
                    }
                }

                StreamWriter outWriter = new StreamWriter(outPath);
                while (true)
                {
                    Int32 c = inStream.ReadByte();
                    if (c < 0)
                    {
                        break;
                    }

                    if (c > 127)
                    {
                        string oct = System.Convert.ToString(c, 8);
                        oct = oct.PadLeft(3, '0');
                        outWriter.Write("\\" + oct);
                    }
                    else
                    {
                        outWriter.Write((char)c);
                    }
                }
                inStream.Close();
                outWriter.Close();
            }
        }
    }
}
