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
    public partial class frmSubnets : Form
    {
        public frmSubnets()
        {
            InitializeComponent();
            loadSubnets();
        }

        private void btnRefreshSubnets_Click(object sender, EventArgs e)
        {
            loadSubnets();
        }

        /// <summary>
        /// Method to load all of the subnets into the list box
        /// </summary>
        public void loadSubnets()
        {
            //clear the list box
            lstSubnets.Items.Clear();


            //load the subnets into the list box from c:\ITS\subnets.txt
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader textfile = new StreamReader(clsFilePath.subnetFilePath);

                //Read first line
                line = textfile.ReadLine();

                

                //Continue to read until you reach end of file
                while (line != null)
                {
                    //add line to list box
                    lstSubnets.Items.Add(line);

                    //get next line
                    line = textfile.ReadLine();

                   
                    
                    
                }

                //close subnet doc
                textfile.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception: " + e.Message);
            }

            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddSubnet addSubnetForm = new frmAddSubnet();
            addSubnetForm.ShowDialog();

            //relaod subnets
            loadSubnets();
        }

        private void frmSubnets_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Method for deleting subnets
        /// </summary>
        public void deleteSubnet()
        {
            if (lstSubnets.SelectedIndex > -1)
            {
                //remove from list box
                lstSubnets.Items.Remove(lstSubnets.SelectedItem);

                //refresh
                lstSubnets.Refresh();


                //create variable for line data
                string line = "";

                try
                {
                    //create writer
                    StreamWriter textFile = new StreamWriter(clsFilePath.subnetFilePath);

                    //loop through all items in text box
                    for (int count = 0; count < lstSubnets.Items.Count; count++)
                    {
                        //set line equal to listbox item
                        line = lstSubnets.Items[count].ToString();

                        //add line to text file
                        textFile.WriteLine(line);
                    }

                    //close file
                    textFile.Close();
                }
                catch
                {
                    //nothing
                }

                //relaod subnets
                loadSubnets();
            }
            else
            {
                MessageBox.Show("Please select a subnet to delete.");
            }
           
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            deleteSubnet();

            //relaod subnets
            loadSubnets();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
