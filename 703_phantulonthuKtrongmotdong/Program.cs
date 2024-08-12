using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _703_phantulonthuKtrongmotdong
{
    internal class KthLargest
    {
        public int k;
        public List<int> stream;
        public KthLargest(int k, int[] nums)
        {
            this.k = k;
            this.stream = new List<int>();
            foreach(int i in nums)
            {
                stream.Add(i);
            }
            Console.WriteLine();
            stream.Sort();
        }

        public int Add(int val)
        {
            int index = getIndex(val);
            Console.WriteLine(index);
            stream.Insert(index, val);
            foreach(int i in stream)
                Console.Write(i+ " ");
            return stream[stream.Count - k];
        }
        private int getIndex(int val)
        {
            int left = 0;
            int right = stream.Count - 1;
            while(left<=right)
            {
                int mid = (left + right) / 2;
                int midValue = stream[mid];
                if (midValue == val) return mid;
                if (midValue > val)
                    right = mid - 1;
                if (midValue < val)
                    left = mid + 1;
            }
            return left;
        }
        static void Main(string[] args)
        {
            int[] a = { 4, 5, 8, 2 };
            KthLargest k = new KthLargest(3,a);

            Console.WriteLine(k.Add(7));
            Console.ReadLine();
        }
    }
}
