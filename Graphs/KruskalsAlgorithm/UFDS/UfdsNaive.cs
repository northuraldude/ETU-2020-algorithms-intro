using System.Collections.Generic;

namespace KruskalsAlgorithm.UFDS
{
    public class UfdsNaive : IUfds<int>
    {
        private readonly List<int> _parent = new List<int>();
        
        public void Union(int itemA, int itemB)
        {
            var a = Find(itemA);
            var b = Find(itemB);
            if (a != b)
                _parent[b] = a;
        }

        public int Find(int item)
        {
            while (item != _parent[item])
                item = _parent[item];
            return item;
        }

        public void MakeSet(int item)
        {
            _parent.Add(item);
        }
    }
}