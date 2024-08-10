using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _200_soluongdao
{
    internal class Program
    {  
        public static int NumIslands(char[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            char land = '1',water='0';
            Queue<(int, int)> queue = new Queue<(int, int)>();
            int[][] jump =new int[][]
            {
                new int[]{1,0},
                new int[]{-1,0},
                new int[]{0,1},
                new int[]{0,-1}
            };
            int index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j]=='1')
                    {
                        queue.Enqueue((i, j));
                        grid[i][j] = '2';
                        do
                        {
                            var (r, c) = queue.Dequeue();
                            foreach(var dir in jump)
                            {
                                int newR = r + dir[0];
                                int newC = c + dir[1];
                                if(newR>=0 && newC>=0 && newR<rows && newC<cols && grid[newR][newC]=='1')
                                {
                                    queue.Enqueue((newR, newC));
                                    grid[newR][newC] = '2';
                                }
                            }
                        }
                        while (queue.Count > 0);
                        index++;
                    }
                   
                }
            }
           for(int i=0;i<rows;i++)
            {
                for(int j=0;j<cols;j++)
                {
                    Console.Write(grid[i][j]+" ");
                }
                Console.WriteLine();
            }
            return index;
        }
        static void Main(string[] args)
        {
            char[][] a = {
  new char[]{'1', '1', '0', '0', '0'},
  new char[]{'1', '1', '0', '0', '0'},
  new char[]{'0', '0', '1', '0', '0'},
  new char[]{'0', '0', '0', '1', '1'}
                         };
            Console.WriteLine(NumIslands(a)); 
            Console.ReadLine();
        }
    }
}
