using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Neuro;
using AForge.Neuro.Learning;

namespace NeuralStock
{
    public class Model
    {
        private NeuralNetwork network = new NeuralNetwork();

        public void Teach()
        {
            network.Teach();
        }

        public void PrepareData(string filename) 
        {
            network.PrepareData(filename);
        }

        public double[] Compute(double[] input)
        {
            return network.Think(input);
        }
    }
}
