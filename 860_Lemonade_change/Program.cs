using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _860_Lemonade_change
{
    internal class Program
    {
        public static bool LemonadeChange(int[] bills)
        {
            int residual_5 = 0;
            int residual_10 = 0;
            
            for (int i = 0; i < bills.Length; i++)
            {
                bool kiemtra = false;
                if (bills[i] == 5)
                {
                    residual_5++;
                    kiemtra = true;
                } 
                if (bills[i] == 10)
                {
                    residual_10++;
                    if(residual_5>0)
                    {
                        residual_5--;
                        kiemtra = true;
                    }
                    
                }
                if (bills[i] == 20)
                {
                    if(residual_10>0 && residual_5>0)
                    {
                        residual_10--;
                        residual_5--;
                        kiemtra = true;
                    }
                    else
                    if(residual_10<=0 && residual_5 >=3)
                    {
                        residual_5 -= 3; 
                        kiemtra = true;
                    }
                   
                }
                Console.WriteLine(kiemtra);
                if (kiemtra==false)
                {
                    return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            int[] a = { 5, 5, 5, 5, 10, 5, 20, 10, 5, 5 };
            Console.WriteLine(LemonadeChange(a));
            Console.ReadLine();
        }
    }
}
