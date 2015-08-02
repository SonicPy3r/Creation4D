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
    public partial class Rendern : Form
    {
        public Rendern()
        {
            InitializeComponent();
        }

        void iVideo() {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Windows Media Video (*.wmv)|*.wmv|Quick Time Movie (*.mp4)|*.mp4|AVI [Unkomprimiert] (*.avi)|*.avi";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    myStream.Close();
                }
            }
        }

        void iBild()
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Portable Network Graphic (*.png)|*.png|Bitmap (*.bmp)|*.bmp|JEPG Bild (*.jpeg)|*.jpeg|GIF Bild [Eingefroren] (*.gif)|*.gif|GIF Bild [Animiert] (*.gif)|*.gif";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    myStream.Close();
                }
            }
        }

        private void ExportBild_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Export als Video oder Bild?\nJa für Video / Nein für Bild", "Frage", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes) {
                iVideo();
            }
            else {
                iBild();
            }
        }
    }
}
