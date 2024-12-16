using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApp2
{
    internal class NumberGeherateYield
    {

        public IEnumerable<int> GenerateNumbers(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Thread.Sleep(500);
                yield return i;
            }
        }

    }
}
