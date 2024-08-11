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
        public static bool Isconnected(int[][] grid)
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
        }
        static void Main(string[] args)
        {
            int[][] a =
            {
                /*new int[]{ 0, 1, 1, 0 },
                new int[]{ 0, 1, 1, 0 },
                new int[]{ 0, 1, 1, 0 }*/
                new int[]{1,1}
            };
            Console.WriteLine(MinDays(a));
            Console.ReadLine();
        }
    }
}
