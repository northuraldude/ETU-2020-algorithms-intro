using System.Collections.Generic;

namespace KruskalsAlgorithm.UFDS
{
    public class UfdsForest : IUfds<int>
    {
        private readonly List<int> _parent = new List<int>();
        private readonly List<int> _rank = new List<int>();
        
        public void Union(int itemA, int itemB)
        {
            var a = Find(itemA);
            var b = Find(itemB);

            if (a == b)
                return;
            
            if (_rank[a] == _rank[b])
                _rank[a]++;
            if (_rank[a] < _rank[b])
                _parent[a] = b;
            else
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
            _rank.Add(0);
        }
    }
}