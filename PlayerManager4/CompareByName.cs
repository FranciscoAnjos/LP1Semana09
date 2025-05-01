using System;
using System.Collections.Generic;

namespace PlayerManager4
{
    public class CompareByName: IComparer<Player>
    {
        private readonly bool _ascending;

        public CompareByName(bool ascending)
        {
            _ascending = ascending;
        }

        public int Compare(Player x, Player y)
        {
            if (x == null || y == null) return 0;

            int comparison = string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);

            return _ascending ? comparison : -comparison;
        }
    }
}