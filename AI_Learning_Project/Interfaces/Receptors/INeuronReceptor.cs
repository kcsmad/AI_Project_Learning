using System.Collections.Generic;
using AI_Learning_Project.Interfaces.Signals;

namespace AI_Learning_Project.Interfaces.Receptors
{
    public interface INeuronReceptor
    {
        Dictionary<INeuronSignal, NeuralFactor> Input { get; }
    }
}