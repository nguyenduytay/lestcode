using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1568_songaytoithieudengatketnoidao
{
    internal class Program
    {
        //hàm kiểm tra đảo còn liên thông khong
        /*   public static bool Isconnected(int[][] grid)
           {
               int m = grid.Length, n = grid[0].Length;
               bool[][] visited = new bool[m][];
               for(int i=0; i<m;i++)
               {
                   visited[i] = new bool[n];
               }
               int components = 0;
               for(int i=0;i<m;i++)
               {
                   for(int j=0;j<n;j++)
                   {
                       if (grid[i][j]==1 && !visited[i][j])
                       {
                           if (components > 0) return false;
                           DFS(grid,visited,i,j);
                           components++;
                       }
                   }
               }
               return components == 1;
           }
           //hàm DFS để đánh dấu các ô đã đươc thăm
           public static void DFS(int[][] grid, bool[][] visited,int i,int j)
           {
               int m = grid.Length, n = grid[0].Length;
               if (i < 0 || i >= m || j < 0 || j >= n || grid[i][j] != 1 || visited[i][j])
                   return;
               visited[i][j] = true;
               DFS(grid, visited, i - 1, j);
               DFS(grid, visited, i +1, j);
               DFS(grid, visited, i , j-1);
               DFS(grid, visited, i , j+1);
           }
           public static int MinDays(int[][] grid)
           {
               int m = grid.Length, n = grid[0].Length;
               if (!Isconnected(grid))
                   return 0;
               for(int i=0;i<m;i++)
               {
                   for(int j=0;j<n;j++)
                   {
                       if (grid[i][j]==1)
                       {
                           grid[i][j] = 0;
                           if (!Isconnected(grid))
                               return 1;
                           grid[i][j] = 1;
                       }
                   }
               }
               return 2;
           }*/

        //cách 2
        public static int NumisLans(int[][] grid)
        {
            int rows = grid.Length, cols = grid[0].Length;
            Queue<(int, int)> queue = new Queue<(int, int)>();
            int[][] jumb = new int[][]
            {
                new int[]{1,0},
                new int[]{-1,0},
                new int[]{0,1},
                new int[]{0,-1}
            };
            int index = 0;
            for(int i=0;i<rows;i++)
            {
                for(int j=0;j<cols;j++)
                {
                    if (grid[i][j]==1)
                    {
                        queue.Enqueue((i, j));
                        grid[i][j] = 2;
                        do
                        {
                            var (r,c) = queue.Dequeue();
                            foreach(var dir in jumb)
                            {
                                int row = r + dir[0];
                                int col = c + dir[1];
                                if(row>=0 && col>=0 && row<rows && col<cols && grid[row][col]==1)
                                {
                                    queue.Enqueue((row, col));
                                    grid[row][col] = 2;
                                }
                            }
                        }
                        while (queue.Count>0);
                        index++;
                    }
                }
            }
            for(int i=0;i<rows;i++)
            {
                for(int j=0;j<cols;j++)
                {
                    if (grid[i][j]==2)
                    grid[i][j] = 1;
                }
            }
            return index;
        }
        public static int MinDays(int[][] grid)
        {
            int m = grid.Length, n = grid[0].Length;
            int[][] jumb = new int[][]
            {
                new int[]{-1,-1},
                new int[]{-1,1},
                new int[]{1,-1},
                new int[]{1,1},
                new int[]{1,0},
                new int[]{-1,0},
                new int[]{0,1},
                new int[]{0,-1}
            };

            if (NumisLans(grid) == 0 || NumisLans(grid) >= 2)
            {
                return 0;
            }

            for (int i=0;i<m;i++)
            {
                for(int j=0;j<n;j++)
                {
                    if (grid[i][j]==1)
                    {
                        grid[i][j] = 0;
                        if (NumisLans(grid) == 0 || NumisLans(grid) >= 2)
                        {
                            return 1;
                        }
                        grid[i][j] = 1;
                    }
                }
            }

            for (int i=0; i<m;i++)
            {
                for(int j=0;j<n;j++)
                {
                    if (grid[i][j]==1)
                    {
                        grid[i][j] = 0;
                        if(NumisLans(grid)==0 || NumisLans(grid)>=2)
                        {
                            return 1;
                        }
                        else
                        {
                            foreach (var bar in jumb)
                            {
                                int row = i + bar[0];
                                int col = j + bar[1];
                                if (row<m && row>=0 && col<n && col>=0 && grid[row][col]==1)
                                {
                                    grid[row][col] = 0;
                                    if (NumisLans(grid) == 0 || NumisLans(grid) >= 2)
                                        return 2;

                                    grid[row][col] = 1;
                                }
                            }
                        }
                        grid[i][j] = 1;
                    }
                }
            }
            return 0;
        }
            static void Main(string[] args)
        {
            int[][] a =
            {
             /* new int[]{ 0, 1, 1, 0 },
                new int[]{ 0, 1, 1, 0 },
                new int[]{ 0, 0, 0, 0 }*/
             new int[]{1,1}

            };
            Console.WriteLine(MinDays(a));
            Console.ReadLine();
        }
    }
}
