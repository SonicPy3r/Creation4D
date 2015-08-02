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

namespace Creation4D
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Variabeln
        bool itrue = true;                  //itrue
        bool ifalse = false;                //ifalse
        string Datei;                       //Datei
        bool ObjektModus;                   //Objekt Modus
        bool EditModus;                     //Edit Modus
        bool PaintModus;                    //Mal Modus
        public int x;                       //X Achse
        public int y;                       //Y Achse
        public int z;                       //X Achse
        int[] NN = new int[] { 0, 0, 0 };   //X, Y, Z | Coordinaten
        int Maus;                           //Mauszeiger
        #endregion Variabeln

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void webseiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.creation4d.tk/");
            //if (Homepage == true) {
            //    //Say Hello
            //} //Ehrlich???
        }

        private void StatusBar_Click(object sender, EventArgs e)
        {

        }

        private void Backward_Click(object sender, EventArgs e)
        {
            StatusBar.Text = "Aktion: Rückgängig gemacht";
        }

        private void Forward_Click(object sender, EventArgs e)
        {
            StatusBar.Text = "Aktion: Wiederholt";
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog OpenFileDialogOpenDefaultFile = new OpenFileDialog();
            OpenFileDialogOpenDefaultFile.Filter = "Creation4D Datei (*.c4d)|*.c4d";
            OpenFileDialogOpenDefaultFile.FilterIndex = 2;
            OpenFileDialogOpenDefaultFile.RestoreDirectory = true;

            if (OpenFileDialogOpenDefaultFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = OpenFileDialogOpenDefaultFile.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            // Insert code to read the stream here.
                            StatusBar.Text = "Aktion: Datei Geöffnet";
                            StatusBar.ForeColor = Color.FromArgb(25,200,25);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fehler: " + ex.Message, "Fehler", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
            }
        }

        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog SaveFileDialogDefaultFile = new SaveFileDialog();

            SaveFileDialogDefaultFile.Filter = "Creation4D Datei|*.c4d";
            SaveFileDialogDefaultFile.FilterIndex = 2;
            SaveFileDialogDefaultFile.RestoreDirectory = true;

            if (SaveFileDialogDefaultFile.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = SaveFileDialogDefaultFile.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    myStream.Close();
                }
            }
        }

        private void New_Click(object sender, EventArgs e)
        {
            StatusBar.Text = "Aktion: Neue Datei/Modell";
        }

        private void Import_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog ImportFile = new OpenFileDialog();

            ImportFile.Filter = "Wavefront Obj (*.obj)|*.obj|Collada (*.dae)|*.dae|3DS Max (*.3ds)|*.3ds|FBX Datei (*.fbx)|*.fbx";
            ImportFile.FilterIndex = 2;
            ImportFile.RestoreDirectory = true;

            if (ImportFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = ImportFile.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            // Insert code to read the stream here.
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void Rendern_Click(object sender, EventArgs e)
        {
            Rendern renderer = new Rendern();
            renderer.Show();
        }
    }
}
