using System;
using System.Collections.Generic;
using AI_Learning_Project.Interfaces;
using AI_Learning_Project.Interfaces.Signals;

namespace AI_Learning_Project.Neural
{
    public class Neuron : INeuron
    {
        #region Constructor
        public Neuron()
        {

        }

        #endregion

        #region Member Variables

        private NeuralFactor m_bias;
        private double m_biasWeight;
        private double m_error;
        private Dictionary<INeuronSignal, NeuralFactor> m_input;
        private double m_output;

        #endregion

        #region Properties

        public NeuralFactor Bias { get; set; }
        public double BiasWeight { get; set; }
        public double Error { get; set; }
        public Dictionary<INeuronSignal, NeuralFactor> Input { get; set; }
        public double Output { get; set; }
        #endregion

        public void ApplyLearning(INeuralLayer layer)
        {
            throw new NotImplementedException();
        }

        public void Pulse(INeuralLayer layer)
        {
            lock (this)
            {
                m_output = 0;

                foreach (KeyValuePair<INeuronSignal, NeuralFactor> item in m_input)
                    m_output += item.Key.Output * item.Value.Weight;

                m_output += m_biasWeight * BiasWeight;

                m_output = Sigmoid(m_output);
            }
        }

        private double Sigmoid(double value)
        {
            return 1 / (1 + Math.Exp(-value));
        }
    }
}
