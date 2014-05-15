using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Neuro;
using AForge.Neuro.Learning;

namespace NeuralStock
{
    class NeuralNetwork
    {
        private ActivationNetwork network;
        private BackPropagationLearning teacher;

        public NeuralNetwork()
        {
            network = new ActivationNetwork(new SigmoidFunction(2), 2, 2, 1);
            teacher = new BackPropagationLearning(network);
        }

        public void Teach()
        {
            double[][] input = new double[4][] {
                new double[] {0, 0}, new double[] {0, 1},
                new double[] {1, 0}, new double[] {1, 1}
            };
            double[][] output = new double[4][] {
                new double[] {0}, new double[] {1},
                new double[] {1}, new double[] {0}
            };

            bool needToStop = false;

            while (!needToStop)
            {
                double error = teacher.RunEpoch(input, output);
                // check error value to see if we need to stop
                // ...
                if (error < 0.01)
                {
                    needToStop = true;
                }
            }  
        }

        public double[] Think(double[] input)
        {
            return network.Compute(input);
        }
    }
}
