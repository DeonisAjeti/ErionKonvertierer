using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace txtConverter
{
    public partial class Konvertierer : Form
    {
        public Konvertierer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Readtxt();
        }
        private void Readtxt()
        {
            string filePath = textBox1.Text;
            string text = File.ReadAllText(filePath);
            string[] abschnitte = text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            label1.Text = abschnitte[0] + "\n";

            string ersteZeile = abschnitte[0].Replace("\t", "    ");

            label1.Text += ersteZeile;
        }


        private void Konverter_Load(object sender, EventArgs e)
        {

        }

        private void Konvertierer_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        


        private void Writetxt()
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Pathfinder();
        }

        private void Pathfinder()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Datei auswählen";
                ofd.Filter = "Textdateien (*.txt)|*.txt|Alle Dateien (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName;
                    textBox1.Text = filePath;
                    string[] abschnitte = filePath.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries);

                    int len = abschnitte.Length;
                    string savepath = "";
                    for (int i = 0; i < len - 1; i++)
                    {
                        savepath += abschnitte[i] + "\\";
                    }

                    textBox2.Text = savepath;

                    string speicherName = "Kassenbuch ";

                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        if (reader == null)
                        {
                            return;
                        }
                        string ersteZeile;
                        int zeile = 0;
                        while ((ersteZeile = reader.ReadLine()) != null && zeile < 1)
                        {
                            zeile++;
                        }
                        //string ersteZeile = reader.ReadLine(); // Nur die erste Zeile

                        if (ersteZeile == null)
                        { return; }
                        string[] split = ersteZeile.Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                        speicherName += split[2].Substring(3) + " Bringd..txt";
                        textBox3.Text = speicherName;

                    }
                }

            }
        }

    }
}