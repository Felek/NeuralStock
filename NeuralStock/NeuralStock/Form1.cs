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
            network.PrepareData("");
            int alpha = 1;
            int hidden = 7;
            double learning = 0.0001;
            double momentum = 0;
            double result = 0;
            

            int max_alpha = 1;
            int max_hidden = 2;
            double max_learning = 0.0001;
            double max_momentum = 0;
            double max_result = 0;

            for (alpha = 1; alpha <= 10; alpha++)
            {
               // for (hidden = 4; hidden < 11; hidden++)
                {
                //    for (learning = 0.0001; learning < 1; learning*=10)
                    {
                        for (momentum = 0; momentum < 1; momentum+=0.1)
                        {
                            for (int i = 0; i < 7; i++)
                            {
                                network = new NeuralNetwork(alpha, hidden, learning, momentum);
                                network.PrepareData("");
                                network.Teach();
                                result = network.Test();
                                if (result > max_result)
                                {
                                    max_alpha = alpha;
                                    max_hidden = hidden;
                                    max_learning = learning;
                                    max_momentum = momentum;
                                    max_result = result;
                                }
                            }
                        }
                    }
                }
            }

            textBox1.Text = network.Teach().ToString();
            textBox2.Text = network.Test().ToString();
         //   textBox1.Text = network.Think(new double[] { 0, 0 })[0].ToString();
           // textBox2.Text = network.Think(new double[] { 0, 1 })[0].ToString();
            textBox3.Text = max_alpha.ToString();
            textBox4.Text = max_hidden.ToString();
            textBox5.Text = max_learning.ToString();
            textBox6.Text = max_momentum.ToString();
        }
    }
}
