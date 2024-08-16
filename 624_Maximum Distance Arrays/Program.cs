using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _624_Maximum_Distance_Arrays
{
    internal class Program
    {
       
        public static int MaxDistance(IList<IList<int>> arrays)
        {
            int max, min, M = 0, N = 0;
            max = arrays[0][arrays[0].Count - 1];
            for (int i = 1; i < arrays.Count; i++)
                if (max <= arrays[i][arrays[i].Count - 1])
                {
                    max = arrays[i][arrays[i].Count - 1];
                    M = i;
                }
            min = arrays[0][0];
            for (int i = 1; i < arrays.Count; i++)
            {

                if (i != M)
                {
                    if (min >= arrays[i][0])
                    {
                        min = arrays[i][0];
                    }
                }
                if (M == 0)
                {
                    min = arrays[1][0];
                }
            }

            int Max, Min, m = 0, n = 0;
            Min = arrays[0][0];
            for (int i = 1; i < arrays.Count; i++)
                if (Min >= arrays[i][0])
                {
                    Min = arrays[i][0];
                    n = i;
                }
            Max = arrays[0][arrays[0].Count - 1];
            for (int i = 1; i < arrays.Count; i++)
            {

                if (i != n)
                {
                    if (Max <= arrays[i][arrays[i].Count - 1])
                    {
                        Max = arrays[i][arrays[i].Count - 1];
                    }
                }
                if (n == 0)
                {
                    Max = arrays[1][arrays[1].Count - 1];
                }
            }

            if (Math.Abs(max - min) <= Math.Abs(Max - Min))
                return Math.Abs(Max - Min);
            else
                return Math.Abs(max - min);
            return 0;
        }
        static void Main(string[] args)
        {
            IList<IList<int>> a = new List<IList<int>>
            {
                new List<int>{ -7,-4,-3,0},
                new List<int>{ 1,4 },
                new List<int>{ -6, 0, 1, 4, 4, 4 },
                new List<int>{ -5, -5, 0, 0, 2 },
                new List<int>{-10,-10,-9,-7,-7,-7,-2,-1,4 },
                new List<int>{-6,0,1,3 },
                new List<int>{ -7, -5, -4, -1, -1 }

            };
            Console.WriteLine(MaxDistance(a));
            Console.ReadLine();
        }
    }
}
