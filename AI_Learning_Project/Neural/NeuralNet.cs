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

        void INeuralNet.ApplyLearning()
        {
            lock (this)
            {
                m_hiddenLayer.ApplyLearning(this);
                m_outputLayer.ApplyLearning(this);
            }
        }

        void INeuralNet.Pulse()
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

            INeuron outputNeuron, inputNode, hiddenNode, node, node2;

            //Calculate output error values
            for (i = 0; i < m_outputLayer.Count; i++)
            {
                temp = m_outputLayer[i].Output;
            }
        }

        public void Initialize(int randomSeed, int inputNeuronCount, int hiddenNeuronCount, int outputNeuronCount)
        {
            int i, j, k, layerCount;
            Random rand;
            INeuralLayer layer;

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
