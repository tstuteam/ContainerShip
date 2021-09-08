using ContainerShipClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContainerShipWindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        /// <summary>
        /// File selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pathTB.Clear();
                var path = openFileDialog1.FileName;
                pathTB.Text = path;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Make output to the screen.
        /// Checks the validity of the input.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            outputTB.Clear();

            ContainerShip ship = null;
            var str = "";


            try
            {
                ship = new ContainerShip(Convert.ToInt32(maxLiftTB.Text));
            }
            catch (Exception)
            {
                MessageBox.Show($"Enter max lifting capacity.", "Error");
                return;
            }

            try
            {
                ship.TryReadAddCargoWeights(pathTB.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("File read error.", "Error");
                return;
            }


            ship.TakeMaxAmountCrates().ForEach(x =>
            {
                str += x;
                str += Environment.NewLine;
            });

            outputTB.Text = str;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
