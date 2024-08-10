using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Lestcode
{
    public class Program
    {
        public static int RangeSum(int[] nums, int n, int left, int right)
        {
            int MOD = (int)1e9 + 7;
            int count = n * (n + 1) / 2;
            int[] subarraySums = new int[count];
            int index = 0;
            for (int i = 0; i < n; i++)
            {
                int currentsum = 0;
                for(int j=i;j<n;j++)
                {
                    currentsum += nums[j];
                    subarraySums[index++] = currentsum;
                }


            }
            Array.Sort(subarraySums);
            int result = 0;
            for (int i = left - 1; i < right; i++)
            {
                result = (result + subarraySums[i]) % MOD;
            }
            return result;
        }

        public static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 4 };
            int n = 4, left = 3, right = 4;
            int sum = RangeSum(nums, n, left, right);
            Console.WriteLine("Output = " + sum);
            Console.ReadLine();
        }
    }
}
