using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace bai_2053
{
    internal class Program
    {
        public static string kthDistinct(string[] arr, int k)
        {
            /*int index = 0;
            bool kiemtra = false;
            for (int i=0;i<arr.Length;i++)
            {
               for( int j=i+1;j<arr.Length;j++)
                {
                    if (arr[i].Equals(arr[j]))
                    {
                        arr[j] = "";
                        kiemtra = true;
                    }
                    if(j==arr.Length-1)
                    {
                        if(kiemtra)
                        {
                            arr[i] = "";
                            kiemtra = false;
                        }
                    }
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (!arr[i].Equals(""))
                {
                    index++;
                    if (index == k)
                    {
                        return arr[i];
                    }
                }

            }*/
            int index = 0;
            for(int i=0;i<arr.Length;i++)
            {
                for(int j=0;j<arr.Length;j++)
                {
                    if (i != j && arr[i] == arr[j])
                        break;
                    if(j==arr.Length-1)
                    {
                        index++;
                    }
                }
                if(index==k)
                {
                    return arr[i];
                }
            }
                return "";
        }
        static void Main(string[] args)
        {
            string[] arr = { "a", "b", "a", "c" };
            int k = 2;
            Console.WriteLine(kthDistinct(arr,k));
            Console.ReadLine();
        }
    }
}
