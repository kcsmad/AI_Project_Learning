using System;
using System.Collections.Generic;
using System.Text;
using AI_Learning_Project.Interfaces;

namespace AI_Learning_Project.Neural
{
    public class NeuralNet : INeuralNet
    {
        private INeuralLayer m_hiddenLayer;
        private INeuralLayer m_inputLayer;
        private double m_learningRate;
        private INeuralLayer m_outputLayer;

        public INeuralLayer HiddenLayer { get ; set; }
        public INeuralLayer OutputLayer { get; set; }
        public INeuralLayer PerceptionLayer { get; set; }

        public void ApplyLearning()
        {
            lock (this)
            {
                m_hiddenLayer.ApplyLearning(this);
                m_outputLayer.ApplyLearning(this);
            }
        }

        public void Pulse()
        {
            lock (this)
            {
                m_hiddenLayer.Pulse(this);
                m_outputLayer.Pulse(this);
            }
        }

        private void BackPropogation(double[] desiredResults)
        {
            int i, j;
            double temp, error;

            INeuron outputNode, inputNode, hiddenNode, node;

            //Calculate output error values
            for (i = 0; i < m_outputLayer.Count; i++)
            {
                temp = m_outputLayer[i].Output;
                m_outputLayer[i].Error = (desiredResults[i] - temp) * temp * (1.0F - temp);
            }

            //Calculate hidden layer errors values
            for (i = 0; i < m_hiddenLayer.Count; i++)
            {
                node = m_hiddenLayer[i];

                error = 0;

                for (j = 0; j < m_outputLayer.Count; j++)
                {
                    outputNode = m_outputLayer[j];
                    error += outputNode.Error * outputNode.Input[node].Weight * node.Output * (1.0 - node.Output);
                }

                node.Error = error;
            }

            //adjust output layer weight change
            for (i = 0; i < m_outputLayer.Count; i++)
            {
                node = m_hiddenLayer[i];

                for (j = 0; j < m_outputLayer.Count; j++)
                {
                    outputNode = m_outputLayer[j];
                    outputNode.Input[node].Weight += m_learningRate * m_outputLayer[j].Error * node.Output;
                    outputNode.Bias.Delta += m_learningRate * m_outputLayer[j].Error * outputNode.Bias.Weight;
                }
            }

            //adjust hidden layer weight change
            for (i = 0; i < m_inputLayer.Count; i++)
            {
                inputNode = m_inputLayer[i];

                for (j = 0; j < m_hiddenLayer.Count; j++)
                {
                    hiddenNode = m_hiddenLayer[j];
                    hiddenNode.Input[inputNode].Weight += m_learningRate * hiddenNode.Error * inputNode.Output;
                    hiddenNode.Bias.Delta += m_learningRate * hiddenNode.Error * inputNode.Bias.Weight;
                }
            }
        }

        public void Train(double[] input, double[] desiredResult)
        {
            int i;

            if (input.Length != m_inputLayer.Count)
                throw new ArgumentException(string.Format("Expecting {0} inputs for this net", m_inputLayer.Count));

            for (i = 0; i < m_inputLayer.Count; i++)
            {
                Neuron n = m_inputLayer[i] as Neuron;

                if (n != null) //maybe make interface get;set;
                    n.Output = input[i];
            }

            Pulse();
            BackPropogation(desiredResult);
        }

        public void Train(double[][] inputs, double[][] expected)
        {
            for(int i = 0; i < inputs.Length; i++)
                Train(inputs[i], expected[i]);
        }

        public void Initialize(int randomSeed, int inputNeuronCount, int hiddenNeuronCount, int outputNeuronCount)
        {
            int i, j, k;
            Random rand;

            //initializations
            rand = new Random(randomSeed);
            m_inputLayer = new NeuralLayer();
            m_hiddenLayer = new NeuralLayer();
            m_outputLayer = new NeuralLayer();

            for(i = 0; i < inputNeuronCount; i++)
                m_inputLayer.Add(new Neuron());

            for (j = 0; j < hiddenNeuronCount; j++)
                m_hiddenLayer.Add(new Neuron());

            for (k = 0; k < outputNeuronCount; k++)
                m_outputLayer.Add(new Neuron());

            //wire-up input layer to hidden layer
            for(i = 0; i < m_hiddenLayer.Count; i++)
                for (j = 0; j < m_inputLayer.Count; j++)
                    m_hiddenLayer[i].Input.Add(m_inputLayer[j],
                        new NeuralFactor(rand.NextDouble()));

            //wire-up output layer to hidden layer
            for (i = 0; i < m_outputLayer.Count; i++)
                for (j = 0; j < m_hiddenLayer.Count; j++)
                m_outputLayer[i].Input.Add(HiddenLayer[j],
                    new NeuralFactor(rand.NextDouble()));
        }
    }
}
