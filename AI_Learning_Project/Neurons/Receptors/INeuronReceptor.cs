using System.Collections.Generic;
using AI_Learning_Project.Neurons.Signals;

namespace AI_Learning_Project.Neurons.Receptors
{
    public interface INeuronReceptor
    {
        Dictionary<INeuronSignal, NeuralFactor> Input { get; }
    }
}