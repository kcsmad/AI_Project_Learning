using System.Collections.Generic;

namespace AI_Learning_Project.Interfaces
{
    public interface INeuralLayer : IList<INeuron>
    {
        void Pulse(INeuralNet net);
        void ApplyLearning(INeuralNet net);
    }
}
