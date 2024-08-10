using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_840_cac_o_vuong_ma_thuat
{
    internal class Program
    {
        public static int NumMagicSquaresInside(int[][] grid)
        {
            int row = grid.Length;
            int col = grid[0].Length;
            int Number_array = row * col;
            int number = 0;
            if (Number_array<9 || row<3 || col <3)
            {
                return 0;
            }
            int[][] new_array = new int[3][];
            for(int i=0;i<new_array.Length;i++)
            {
                new_array[i] = new int[3];
            }
            int c_i = 0, r_i = 0, c = 3, r = 3, index = 0;
            while(c<=col && r<=row)
            {
                int x = 0,y = 0;
                for (int i=r_i;i<r;i++)
                {
                    for(int j=c_i;j<c;j++)
                    {
                        new_array[x][y] = grid[i][j];
                        y++;
                    }
                    y = 0;
                    x++;
                }
                index++;
                if(index<=(col-3))
                {
                    c_i++;c++;
                }
                else
                {
                    index = 0;
                    r_i++;r++;
                    c_i = 0;c = 3;
                }
                int sum_row = 0, sum_col = 0, sum_cross1 = 0, sum_cross2 = 0;
                int kiemtra = 0;
                sum_cross1 = new_array[0][0] + new_array[1][1] + new_array[2][2];
                sum_cross2 = new_array[0][2] + new_array[2][0] + new_array[1][1];
                for (int i=0;i<3;i++)
                {
                    for(int j=0;j<3;j++)
                    {
                       sum_row += new_array[i][j];
                       sum_col += new_array[j][i];
                        if (new_array[i][j] == new_array[0][0])
                            kiemtra++;
                        if (new_array[i][j] > 9 || new_array[i][j]<1)
                        {
                            sum_row = 0;
                            break;
                        }
                           
                    }  
                    if (sum_col != sum_row || sum_col != sum_cross1 || sum_col != sum_cross2 || sum_row != sum_cross1 || sum_row != sum_cross2 || sum_cross1 != sum_cross2 || kiemtra==9 )
                    {
                        break;
                    }
                    if (i == 2)
                        number++;
                    sum_row = 0; sum_col = 0;
                }
            }
                return number;
        }
        static void Main(string[] args)
        {
            int[][] a =new int[][]
                {
                new int[] { 8,0,7,4,3,2},
                new int[] { 1,10,4,4,3,8}, 
                new int[] { 8,5,2,9,5,1},
                new int[] { 6,0,9,2,7,6},
                new int[] { 9,0,6,9,5,1},
                new int[] {4,2,1,4,3,8}
                };
            Console.WriteLine(NumMagicSquaresInside(a));
            
            Console.ReadLine();

        }
    }
}
