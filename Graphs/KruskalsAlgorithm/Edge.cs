using System;

namespace KruskalsAlgorithm
{
    public class Edge : IComparable
    {
        public readonly int U;
        public readonly int V;
        public readonly int Weight;
        
        public Edge(int u, int v, int weight)
        {
            U = u;
            V = v;
            Weight = weight;
        }
        
        public int CompareTo(object obj)
        {
            var e = (Edge)obj;
            return this.Weight.CompareTo(e.Weight);
        }
    }
}