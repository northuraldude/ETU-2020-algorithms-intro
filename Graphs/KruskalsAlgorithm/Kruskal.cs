using System.Collections.Generic;
using KruskalsAlgorithm.UFDS;

namespace KruskalsAlgorithm
{
    public class Kruskal
    {
        // Выбранная реализация
        private readonly IUfds<int> _ufds;
        public int Cost { get; private set; }
        
        public Kruskal(IUfds<int> ufds)
        {
            _ufds = ufds;
        }
        
        /// <summary>
        /// Построить минимальное остовное дерево
        /// </summary>
        /// <remarks>
        /// Список рёбер графа упорядочивается в порядке возрастания весов
        /// </remarks>
        /// <param name="edges"> Список рёбер графа </param>
        /// <param name="verticlesCount"> Количество вершин графа </param>
        /// <returns> Список ребёр минимального остовного дерева </returns>
        public List<Edge> BuildMST(List<Edge> edges, int verticlesCount)
        {
            var mst = new List<Edge>();
            Cost = 0;
            edges.Sort();

            for (var i = 0; i < verticlesCount; i++) 
                _ufds.MakeSet(i);
            
            foreach (var edge in edges)
            {
                if (_ufds.Find(edge.U) != _ufds.Find(edge.V))
                {
                    Cost += edge.Weight;
                    mst.Add(edge);
                    _ufds.Union(edge.U, edge.V);
                }
            }

            return mst;
        }
    }
}