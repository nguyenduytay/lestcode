using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_3016
{
    internal class Program
    {
        public static int sodem(string[] list,string x)
        {
            for(int i=0;i<list.Length;i++)                
                if (list[i].Equals(x))
                    if (i >= 0 && i <= 7)
                        return 1;
                    else if (i >= 8 && i <= 15)
                        return 2;
                    else if (i >= 16 && i <= 23)
                        return 3;

                        return 4;
        }
        public static int MininumPushes(string word)
        {
            string[] list = {"a","d","g","j","m","p","t","w",
                             "b","e","h","k","n","q","u","x",
                             "c","f","i","l","o","r","v","y",
                             "s","z"};
            int j = 0;
            int tong = 0;
            for (int i = 0; i < word.Length; i++)
            {
                tong += sodem(list, word[i].ToString());
            }
            return tong; ;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(MininumPushes("ab"));
            Console.ReadLine();
        }
    }
}
