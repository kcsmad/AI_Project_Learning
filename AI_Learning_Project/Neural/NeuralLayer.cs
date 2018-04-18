using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using AI_Learning_Project.Interfaces;

namespace AI_Learning_Project.Neural
{
    public class NeuralLayer : INeuralLayer
    {
        private List<Neuron> m_neurons = new List<Neuron>();

        INeuron IList<INeuron>.this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
        int ICollection<INeuron>.Count => throw new NotImplementedException();

        bool ICollection<INeuron>.IsReadOnly => throw new NotImplementedException();

        void ICollection<INeuron>.Add(INeuron item)
        {
            throw new NotImplementedException();
        }

        void INeuralLayer.ApplyLearning(INeuralNet net)
        {
            foreach(INeuron n in m_neurons)
                n.ApplyLearning(this);
        }

        void ICollection<INeuron>.Clear()
        {
            throw new NotImplementedException();
        }

        bool ICollection<INeuron>.Contains(INeuron item)
        {
            throw new NotImplementedException();
        }

        void ICollection<INeuron>.CopyTo(INeuron[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        IEnumerator<INeuron> IEnumerable<INeuron>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        int IList<INeuron>.IndexOf(INeuron item)
        {
            throw new NotImplementedException();
        }

        void IList<INeuron>.Insert(int index, INeuron item)
        {
            throw new NotImplementedException();
        }

        void INeuralLayer.Pulse(INeuralNet net)
        {
            foreach (INeuron n in m_neurons)
                n.Pulse(this);
        }

        bool ICollection<INeuron>.Remove(INeuron item)
        {
            throw new NotImplementedException();
        }

        void IList<INeuron>.RemoveAt(int index)
        {
            throw new NotImplementedException();
        }
    }
}
