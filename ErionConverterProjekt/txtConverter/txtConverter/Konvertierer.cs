using System;
using System.IO;
using System.Windows.Forms;

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
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Datei auswählen";
                ofd.Filter = "Textdateien (*.txt)|*.txt|Alle Dateien (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName;
                    string content = File.ReadAllText(filePath); // Lies den Inhalt der Datei ein
                    MessageBox.Show(content); // Beispielausgabe
                }
            }
        }

        private void Konverter_Load(object sender, EventArgs e)
        {

        }

        private void Konvertierer_Load(object sender, EventArgs e)
        {

        }
    }
}