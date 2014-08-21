using AForge.Neuro;
using AForge.Neuro.Learning;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_GUI.Model
{
    public class NeuralNetwork
    {
        private ActivationNetwork network;
        private BackPropagationLearning teacher;
        private double[][] input;
        private double[][] output;
        private double count;

        public NeuralNetwork()
        {
            network = new ActivationNetwork(new BipolarSigmoidFunction(5), 13, 7, 1);
            teacher = new BackPropagationLearning(network);
            teacher.LearningRate = 0.0001;
            teacher.Momentum = 0;
            PrepareData();
        }

        public NeuralNetwork(int alpha, int hidden, double learning, double momentum)
        {
            network = new ActivationNetwork(new BipolarSigmoidFunction(alpha), 13, hidden, 1);
            teacher = new BackPropagationLearning(network);
            teacher.LearningRate = learning;
            teacher.Momentum = momentum;
        }

        public void Teach()
        {
            bool needToStop = false;
            int i = 0;

            double error = 0;

            while (!needToStop)
            {
                i++;
                error = teacher.RunEpoch(input, output);

                if ((i > 5000))
                {
                    needToStop = true;
                }
            }
        }

        public void PrepareData(string filename = "")
        {
            filename = "../../../../Data/teaching.txt";                   //////ZMIENIC
            List<string> list = new List<string>();
            int argc, tests;
            using (StreamReader sr = new StreamReader(filename))
            {
                while (!sr.EndOfStream)
                {
                    String line = sr.ReadLine();
                    list.Add(line);
                }
            }
            argc = list[0].Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
            count = tests = list.Count;

            input = new double[tests][];
            output = new double[tests][];
            for (int i = 0; i < tests; i++)
            {
                input[i] = new double[argc - 1];
                output[i] = new double[1];
            }
            string[] bufor = list[0].Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < tests; i++)
            {
                bufor = list[i].Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                for (int k = 0; k < argc - 1; k++)
                {
                    input[i][k] = Convert.ToDouble(bufor[k]);
                }
                output[i][0] = Convert.ToDouble(bufor[argc - 1]);
            }
        }

        public double[] Think(double[] input)
        {
            return network.Compute(input);
        }

        public double Test()
        {
            double neural_result;
            double success_count = 0;
            for (int i = 0; i < count; i++)
            {
                neural_result = network.Compute(input[i])[0];
                neural_result = network.Output[0];

                if ((neural_result < 0 && output[i][0] < 0) || (neural_result > 0 && output[i][0] > 0))
                    success_count++;
            }
            return success_count / count;
        }
    }
}
