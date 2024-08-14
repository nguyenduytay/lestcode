using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _40_comnination_sum_2
{
   
    internal class Program
    {
        public static void backtrack(IList<IList<int>> list, IList<int> listnew, int[] candidates,int totalLeft, int index)
        {
            if (totalLeft < 0) return;
            else if (totalLeft == 0)
            {
                list.Add(new List<int>(listnew));
            }
            else
            {
                for(int i=index;i<candidates.Length && totalLeft >= candidates[i];i++)
                {

                    if (i > index && candidates[i] == candidates[i - 1])
                        continue;
                    listnew.Add(candidates[i]);
                    backtrack(list, listnew, candidates, totalLeft - candidates[i], i + 1);
                    listnew.RemoveAt(listnew.Count - 1);
                }
            }
        }
        public static IList<IList<int>> combinaTionSum2(int[] candidates, int target)
        {
            IList<IList<int>> list = new List<IList<int>>();
            IList<int> listnew = new List<int>();
            int n = candidates.Length;
            Array.Sort(candidates);
            backtrack(list, listnew, candidates, target,0);
            foreach (var childList in list)
            {
                foreach (var item in childList)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
            return list;
        }
        static void Main(string[] args)
        {
            int[] a = { 10, 1, 2, 7, 6, 1, 5 };
            Console.WriteLine(combinaTionSum2(a,8));
            Console.ReadLine();
        }
    }
}
