using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralStock
{
    public partial class Form1 : Form
    {
        NeuralNetwork network;

        public Form1()
        {
            InitializeComponent();
            network = new NeuralNetwork();
            network.Teach();
            textBox1.Text = network.Think(new double[] { 0, 0 })[0].ToString();
            textBox2.Text = network.Think(new double[] { 0, 1 })[0].ToString();
            textBox3.Text = network.Think(new double[] { 1, 0 })[0].ToString();
            textBox4.Text = network.Think(new double[] { 1, 1 })[0].ToString();
        }
    }
}
