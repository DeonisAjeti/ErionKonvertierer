using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
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
            if (textBox4.Text.Length == 0)
            {
                MessageBox.Show("Bitte geben Sie eine Konto Nr. an!");
            }
            else
            {
                Readtxt();
            }
        }
        private void Readtxt()
        {
            string filePath = textBox1.Text;

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Datei nicht gefunden!");
                return;
            }

            string text = File.ReadAllText(filePath, Encoding.GetEncoding("iso-8859-1"));

            Writetxt(Stringsplitter(text));
        }

        private string[][] Stringsplitter(string text)
        {
            string[] abschnitte = text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            string[][] strings = new string[abschnitte.Length][];
            for (int i = 0; i < abschnitte.Length; i++)
            {
                strings[i] = abschnitte[i].Split(new string[] { "\t" }, StringSplitOptions.None);
            }
            string[][] adaptedString = new string[strings.Length-1][];
            string kontonr = textBox4.Text;
            for (int i = 0; i < adaptedString.Length; i++)
            {
                adaptedString[i] = new string[strings[i].Length+1];
                for(int j = 0; j < adaptedString[i].Length; j++)
                {
                    if (j < adaptedString[i].Length - 1)
                    {
                        adaptedString[i][j] = strings[i][j];
                    }
                    else
                    {
                        //Extra Zeile hinzufügen
                        if(i == 0)
                        {
                            adaptedString[i][j] = "Konto";
                        }else
                        {
                            //Kontonummer
                            adaptedString[i][j] = kontonr;
                        }
                    }
                }
            }
            return adaptedString;
        }
        private void OnlyNumbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void Writetxt(string[][] txt)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Datei speichern";
                sfd.Filter = "Textdateien (*..txt)|*..txt|Alle Dateien (*.*)|*.*";

                // Standardverzeichnis und Dateiname aus TextBoxen übernehmen
                sfd.InitialDirectory = textBox2.Text;
                sfd.FileName = textBox3.Text + "..txt"; // nur ein Punkt!

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(sfd.FileName, false, Encoding.UTF8)) // UTF-8!
                    {
                        for (int i = 0; i < txt.Length; i++)
                        {
                            string[] zeile = txt[i];
                            string line = string.Join("\t", zeile);
                            writer.WriteLine(line);
                        }
                    }

                    MessageBox.Show("Datei gespeichert!");
                }
            }
        }

        private void Konverter_Load(object sender, EventArgs e)
        {

        }

        private void Konvertierer_Load(object sender, EventArgs e)
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

                    string speicherName = "Formatierung ";

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
                        speicherName += split[2].Substring(3, 2) + " Bringd";
                        textBox3.Text = speicherName;

                    }
                }

            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}