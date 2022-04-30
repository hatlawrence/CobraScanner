using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cobra_Scanner
{
    public partial class frmLog : Form
    {
        public frmLog()
        {
            InitializeComponent();

            //get file and store data in list, but check for errors
            try
            {
                //clear box in case it was already opened
                lstLog.Items.Clear();

                //pull all lines and store in list
                string[] studentList = File.ReadLines(clsFilePath.logFilePath).ToArray();

                //add list elements to box
                lstLog.Items.AddRange(studentList);

            }
            catch (IOException exc)
            {
                //show error if it couldn't read
                MessageBox.Show("Couldn't read log file!");
            }
        }
    }
}
