using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_GUI.Model;

namespace WF_GUI
{
    public partial class Form1 : Form
    {
        private int counter;
        private Thread teachThread;
        private NeuralNetwork network;

        public Form1()
        {
            InitializeComponent();
            network = new NeuralNetwork();
            teachThread = new Thread(new ThreadStart(network.Teach));
            teachThread.Start();
           // network.Teach();
            counter = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox14.Text = "Chwilka, sieć w trakcie nauki...";
            teachThread.Join();
            try
            {
                double openWIG20 = (Convert.ToDouble(textBox1.Text) - 0) * (1 + 1) / (4000 - 0) - 1;
                double closeWIG20 = (Convert.ToDouble(textBox4.Text) - 0) * (1 + 1) / (4000 - 0) - 1;
                double highestWIG20 = (Convert.ToDouble(textBox2.Text) - 0) * (1 + 1) / (4000 - 0) - 1;
                double lowestWIG20 = (Convert.ToDouble(textBox3.Text) - 0) * (1 + 1) / (4000 - 0) - 1;
                double rsi9 = (Convert.ToDouble(textBox9.Text) - 0) * (1 + 1) / (100 - 0) - 1;
                double rsi14 = (Convert.ToDouble(textBox10.Text) - 0) * (1 + 1) / (100 - 0) - 1;
                double ma4 = (Convert.ToDouble(textBox11.Text) - 0) * (1 + 1) / (4000 - 0) - 1;
                double ma9 = (Convert.ToDouble(textBox12.Text) - 0) * (1 + 1) / (4000 - 0) - 1;
                double ma18 = (Convert.ToDouble(textBox13.Text) - 0) * (1 + 1) / (4000 - 0) - 1;
                double roc = Convert.ToDouble(textBox8.Text)*10;
                double volume = (Convert.ToDouble(textBox7.Text) - 0) * (1 + 1) / (200 - 0) - 1;
                double openWIG = (Convert.ToDouble(textBox5.Text) - 20000) * (1 + 1) / (70000 - 20000) - 1;
                double closeWIG = (Convert.ToDouble(textBox6.Text) - 20000) * (1 + 1) / (70000 - 20000) - 1;

                double[] input = new double[] { openWIG20, highestWIG20, lowestWIG20, closeWIG20, volume, openWIG, closeWIG, roc, rsi9, rsi14, ma4, ma9, ma18 };

                double[] output = network.Think(input);
                double tolerance = 0;
                double mapped_output = (output[0] + 1) * (200 + 200) / (1 + 1) - 200;
                try
                {
                    tolerance = Convert.ToDouble(textBox15.Text);
                }
                catch { }

                if (mapped_output > tolerance)
                {
                    textBox14.ForeColor = Color.Green;
                    textBox14.Text = "KUPUJ";
                }
                else if (mapped_output < -tolerance)
                {
                    textBox14.ForeColor = Color.Red; // (T3+200)*(1+1)/(200+200)-1
                    textBox14.Text = "SPRZEDAWAJ";
                }
                else
                {
                    textBox14.ForeColor = Color.Gray;
                    textBox14.Text = "WSTRZYMAJ SIĘ OD DZIAŁAŃ";
                }
            }
            catch
            {
                MessageBox.Show("Popraw dane wejściowe!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (counter == 0)
            {
                textBox1.Text = "2368,03";      // otwarcie WIG20
                textBox4.Text = "2384,34";      // zamkniecie WIG20
                textBox2.Text = "2395,13";      // najwyzszy WIG20
                textBox3.Text = "2366,21";      // najnizszy WIG20
                textBox9.Text = "48,4";         // rsi9
                textBox10.Text = "64,23";       // rsi14
                textBox11.Text = "2386,723";    // ma4
                textBox12.Text = "2367,31";     // ma9
                textBox13.Text = "2362,02";     // ma18
                textBox8.Text = "0,0069";       // roc
                textBox7.Text = "24,03";        // wolumen
                textBox5.Text = "40871,6";      // otwarcie WIG
                textBox6.Text = "41069,7";      // zamknięcie WIG
            }
            else if (counter == 1)
            {
                textBox1.Text = "2364,48";      // otwarcie WIG20
                textBox4.Text = "2380,28";      // zamkniecie WIG20
                textBox2.Text = "2393,02";      // najwyzszy WIG20
                textBox3.Text = "2362";      // najnizszy WIG20
                textBox9.Text = "87,92";         // rsi9
                textBox10.Text = "61,12";       // rsi14
                textBox11.Text = "2350,795";    // ma4
                textBox12.Text = "2325,88";     // ma9
                textBox13.Text = "2330,38";     // ma18
                textBox8.Text = "0,0067";       // roc
                textBox7.Text = "30,11";        // wolumen
                textBox5.Text = "40845,5";      // otwarcie WIG
                textBox6.Text = "41036,6";      // zamknięcie WIG
            }
            else if (counter == 2)
            {
                textBox1.Text = "2283,29";      // otwarcie WIG20
                textBox4.Text = "2271,03";      // zamkniecie WIG20
                textBox2.Text = "2290,49";      // najwyzszy WIG20
                textBox3.Text = "2259,67";      // najnizszy WIG20
                textBox9.Text = "29,12";         // rsi9
                textBox10.Text = "29,927";       // rsi14
                textBox11.Text = "2305,49";    // ma4
                textBox12.Text = "2334,886";     // ma9
                textBox13.Text = "2349,70";     // ma18
                textBox8.Text = "-0,0054";       // roc
                textBox7.Text = "32,0750";        // wolumen
                textBox5.Text = "39561,7";      // otwarcie WIG
                textBox6.Text = "39392,5";      // zamknięcie WIG
            }
            else
            {
                textBox1.Text = "2223,16";      // otwarcie WIG20
                textBox4.Text = "2242,15";      // zamkniecie WIG20
                textBox2.Text = "2246,45";      // najwyzszy WIG20
                textBox3.Text = "2219,61";      // najnizszy WIG20
                textBox9.Text = "74,825";         // rsi9
                textBox10.Text = "76,229";       // rsi14
                textBox11.Text = "2254,86";    // ma4
                textBox12.Text = "2234,60";     // ma9
                textBox13.Text = "2166,06";     // ma18
                textBox8.Text = "0,0085";       // roc
                textBox7.Text = "28,54";        // wolumen
                textBox5.Text = "39898,82";      // otwarcie WIG
                textBox6.Text = "40187,43";      // zamknięcie WIG

                counter = -1;
            }
            counter++;
        }
    }
}
