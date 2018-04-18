﻿using System;
using System.Collections.Generic;
using System.Text;
using AI_Learning_Project.Neural;

namespace AI_Learning_Project.TrainingRoom
{
    public class TrainingRoom
    {
        private NeuralNet net;

        public TrainingRoom()
        {
            net = new NeuralNet();
            double high, mid, low;

            high = .9;
            mid = .5;
            low = .1;

            //Initialize with
            // 2 Perceptions Neurons
            // 2 Hidden Layer Neurons
            // 1 Output Neuron
            net.Initialize(1, 2, 2, 1);

            double[][] input = new double[4][];
            input[0] = new double[] { high, high };
            input[1] = new double[] { low, high };
            input[2] = new double[] { high, low };
            input[3] = new double[] { low, low };
            
            double[][] output = new double[4][];
            output[0] = new double[] { low };
            output[1] = new double[] { high };
            output[2] = new double[] { high };
            output[3] = new double[] { low };

            double ll, lh, hl, hh;
            int count = 0;

            do
            {
                count++;

                for (int i = 0; i < 100; i++)
                    net.Train(input, output);

                net.ApplyLearning();

                net.PerceptionLayer[0].Output = low;
                net.PerceptionLayer[1].Output = low;

                net.Pulse();

                ll = net.OutputLayer[0].Output;

                net.PerceptionLayer[0].Output = high;
                net.PerceptionLayer[1].Output = low;

                net.Pulse();

                hl = net.OutputLayer[0].Output;

                net.PerceptionLayer[0].Output = low;
                net.PerceptionLayer[1].Output = high;

                net.Pulse();

                lh = net.OutputLayer[0].Output;

                net.PerceptionLayer[0].Output = high;
                net.PerceptionLayer[1].Output = high;

                net.Pulse();

                hh = net.OutputLayer[0].Output;

            } while (hh > mid || lh < mid || hl < mid || ll > mid);

            Console.WriteLine((count*100).ToString() + " interations required for training");
        }
    }
}
