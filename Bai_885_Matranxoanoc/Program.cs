using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_885_Matranxoanoc
{
    internal class Program
    {
        // quy luật mỗi lần dịch chuyển có 2 bước nhảy giống nhau 
        //mỗi bước nhảy cách nhau 1 đown vị 
        // phải-xuống-trái-lên 
        public static int[][] SpiralMatrixIII(int rows,int cols,int rStart,int cStart)
        {
            int totaCells = rows * cols;
            int[][] result = new int[totaCells][];
            int[][] directions =new int[4][]
            {
                new int[]{0,1},//right
                new int[]{1,0},//dowm
                new int[]{0,-1},//left
                new int[]{-1,0}//up
            };
            int directionIndex = 0;
            int steps = 1;
            int count = 0;
            result[count++] = new int[] { rStart, cStart };
            while (count<totaCells)
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < steps; j++)
                    {
                        rStart += directions[directionIndex][0];
                        cStart += directions[directionIndex][1];
                        if (rStart >= 0 && rStart < rows && cStart >= 0 && cStart < cols)
                        {
                            if (count >= totaCells)
                                break;
                            result[count++] = new int[]{ rStart, cStart };
                            
                        }
                        
                    }
                    directionIndex = (directionIndex + 1) % 4;
                }
                steps++;
            }
            return result;
        }
        static void Main(string[] args)
            
        {
            int[][] resuls = SpiralMatrixIII(3,3,1,1);
            foreach (var resul in resuls)
            {
                Console.WriteLine($"[{resul[0]},{resul[1]}]");
            }
            Console.ReadLine();
        }
    }
}
