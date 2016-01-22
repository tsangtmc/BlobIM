using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlobIDS.GUI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void HTML_Click(object sender, EventArgs e)
        {
            string file = Path.GetDirectoryName(Config.Settings.SnapShotFileName_Baseline);
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                file = openFileDialog1.FileName;
                View.SnapShot.HTML_Format(file);
                Close();
            }
        }

        private void RawText_Click(object sender, EventArgs e)
        {
            string file = Path.GetDirectoryName(Config.Settings.SnapShotFileName_Baseline);
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                file = openFileDialog1.FileName;
                System.Diagnostics.Process.Start(file);
                Close();
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CSV_Click(object sender, EventArgs e)
        {
            string file = Path.GetDirectoryName(Config.Settings.SnapShotFileName_Baseline);
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                file = openFileDialog1.FileName;
                View.SnapShot.CSV_Format(file);
                Close();
            }
        }
    }
}
