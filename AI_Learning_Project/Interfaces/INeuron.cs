using System;
using System.Collections.Generic;
using System.Text;
using AI_Learning_Project.Interfaces.Receptors;
using AI_Learning_Project.Interfaces.Signals;

namespace AI_Learning_Project.Interfaces
{
    public interface INeuron : INeuronReceptor, INeuronSignal
    {
        void Pulse(INeuralLayer layer);
        void ApplyLearning(INeuralLayer layer);

        NeuralFactor Bias { get; set; }
        double BiasWeight { get; set; }
        double Error { get; set; }
    }
}
