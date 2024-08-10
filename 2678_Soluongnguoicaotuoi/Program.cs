using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2678_Soluongnguoicaotuoi
{
    internal class Program
    {
        public static int CountSeniors(string[] details)
        {
            int index = 0;
            foreach(string s in details)
            {
                if ((int.Parse(s[11].ToString()) == 6 && int.Parse(s[12].ToString()) > 0) || int.Parse(s[11].ToString()) > 6)
                    index++;
            }
            return index;
        }
        static void Main(string[] args)
        {
            string[] a = { "7868190130M7522", "5303914400F9211", "9273338290F4010" };
            Console.WriteLine(CountSeniors(a));
            Console.ReadLine();
            // co khong giu mat dung tim
            // yeu xa kho lam nguoi oi
        }
    }
}
