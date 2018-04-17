using System;
using System.Collections.Generic;
using System.Text;

namespace AI_Learning_Project.Interfaces
{
    public interface INeuralNet
    {
        INeuralLayer HiddenLayer { get; set; }
        INeuralLayer OutputLayer { get; set; }
        INeuralLayer PerceptionLayer { get; set; }

        void ApplyLearning();
        void Pulse();
    }
}
