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
    public partial class frmAddSubnet : Form
    {
        public frmAddSubnet()
        {
            InitializeComponent();
        }

        private void btnAddSubnet_Click(object sender, EventArgs e)
        {
            //create list to store IPS
            List<string> ipaddresses = new List<string>();

            try
            {
                //create streamreader
                //Pass the file path and file name to the StreamReader constructor
                StreamReader textfile = new StreamReader(clsFilePath.subnetFilePath);

                //Read first line
                string line;
                line = textfile.ReadLine();

                //read in all IPS to list
                //continue until file is empty
                while (line != null)
                {
                    //add line to list
                    ipaddresses.Add(line);

                    //get next line
                    line = textfile.ReadLine();
                }

                //close file
                textfile.Close();

                //add text from textbox to list
                ipaddresses.Add(txtAddSubnet.Text);
            }
            catch (Exception fileError)
            {
                MessageBox.Show("Exception: " + fileError.Message);
            }

            try
            {
                //write list to text file line by line
                //open stream writer
                //create writer
                StreamWriter textFile = new StreamWriter(clsFilePath.subnetFilePath);

                for(int counter = 0; counter < ipaddresses.Count; counter++)
                {
                    textFile.WriteLine(ipaddresses[counter]);
                }
                textFile.Close();
            }
            catch
            {
                //do nothing
            }

            

            //close form
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
