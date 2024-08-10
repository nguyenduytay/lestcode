using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_273
{
    //Convert a non-negative integer num to its English words representation.
    internal class Program
    {

        public static string  NumberTowords(int num)
        {
            string number_read = "";
            int dozens, unit_row;
            if (num == 0)
                return "Zero";
            string[] below_20 = { "", "One", "Two", "Three", "Four","Five","Six","Seven","Eight","Nine","Ten",
                                  "Eleven","Twelve","Thirteen","Fourteen","Fifteen","Sixteen","Seventeen",
                                   "Eighteen","Nineteen"};
            string[] tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            string[] thousands = { "", "Thousand", "Million", "Billion" };
            
           
                int a, b, c;
                int index = 3;
                 while(num > 0)
                {
                    a = num / (int)Math.Pow(10, 3*index);
                    num = num % (int)Math.Pow(10, 3*index);
                    b = a / 100;
                    c = a % 100;
                if (a>0)
                    {
                        if (b > 0)
                        {
                            number_read += below_20[b] + " " + "Hundred" + " ";
                        }
                        if(c>0)
                        {
                            if (c < 20)
                            {
                            number_read += below_20[c]+" ";
                            }
                            else if (c < 100)
                            {

                                dozens = c / 10;
                                number_read += tens[dozens]+" ";
                                unit_row = c % 10;
                                if(unit_row>0)
                                number_read += below_20[unit_row]+" ";
                            }
                        }
                       number_read += thousands[index]+" ";
                }
                    index--;
                }
               number_read.Trim();
                return number_read;

        }
        static void Main(string[] args)
        {
            Console.WriteLine(NumberTowords(1234567));
            Console.ReadLine();
        }
    }
}
