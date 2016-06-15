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
        enum OutputType
        {
            Octal,
            Hex
        }

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
            OutputType ot = OutputType.Octal;

            if (this.octalRadioButton.Checked)
            {
                ot = OutputType.Octal;
            }
            else if (this.hexRadioButton.Checked)
            {
                ot = OutputType.Hex;
            }

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
                StringBuilder sb = new StringBuilder();
                while (true)
                {
                    Int32 c = inStream.ReadByte();
                    if (c < 0)
                    {
                        break;
                    }

                    if (c > 127)
                    {
                        string ec;
                        //oct = oct.PadLeft(3, '0');
                        switch(ot)
                        {
                            case OutputType.Hex:
                                ec = "\\u" + ((int)c).ToString("x4");
                                break;

                            case OutputType.Octal:
                            default:
                                ec = "\\0" + System.Convert.ToString(c, 8);
                                break;
                        }
                        sb.Append(ec);
                    }
                    else
                    {
                        sb.Append((char)c);
                    }
                }
                outWriter.Write(sb.ToString());
                inStream.Close();
                outWriter.Close();
            }
        }
    }
}
