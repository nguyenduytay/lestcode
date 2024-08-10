using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _959_cacvungbicatboidaugachcheo
{
    internal class Program
    { 
        public  static int[][]  FloodFill(int[][] grid, int sr, int sc, int newColor)
        {
            int originalColor = grid[sr][sc]; // máu của điểm cần thay đổi 
            if (originalColor == newColor) return grid; // trùng màu thì trả về mảng
            int rows = grid.Length;
            int cols = grid[0].Length;
            Queue<(int, int)> queue = new Queue<(int, int)>();//khởi tạo hàng đợi
            queue.Enqueue((sr, sc)); // thêm cặp giá trị vào hàng đợi
            grid[sr][sc] = newColor; // thay đổi màu vị trí đầu tiên

            //các hướng đi: xuống, lên, phải,trái
            int[][] directions = new int[][]
            {
                new int[]{1,0},//xuống
                new int[]{-1,0},//lên
                new int[]{0,1},//phải
                new int[]{0,-1}//trái
            };

            while(queue.Count >0)
            {
                var (r, c) = queue.Dequeue(); // lấy cặp giá trị đầu tiên trong hàng đợi
                foreach(var dir in directions)
                {
                    //tahy đổi vị trí
                    int newR = r + dir[0];
                    int newC = c + dir[1];
                    if(newR>=0 && newR<rows && newC>=0 &&newC<cols && grid[newR][newC]==originalColor)
                    {
                        queue.Enqueue((newR, newC)); //thêm cặp vị trí vào hàng đowij
                        grid[newR][newC] = newColor; // thay đổi màu của vị trí 
                    }
                }
            }
            return grid;
        }
        public static int RegionBySlashes(string[] grid)
        {
            int n = grid.Length;
            int[][] expandedGrid = new int[n*3][];
            for(int i=0;i<n*3;i++)
            {
                expandedGrid[i] = new int[n * 3];
            }
            int index = 0;
            int baseRow = 0, baseCol = 0;
            for (int i=0;i<n;i++)
            {
                for(int j = 0; j < grid[i].Length;j++)
                {
                    
                    if (grid[i][j].Equals('\\'))
                    {
                        expandedGrid[baseRow][baseCol] = 1;
                        expandedGrid[baseRow + 1][baseCol + 1] = 1;
                        expandedGrid[baseRow + 2][baseCol + 2] = 1;
                    }
                    if(grid[i][j].Equals('/'))
                    {
                        expandedGrid[baseRow][baseCol+2] = 1;
                        expandedGrid[baseRow + 1][baseCol + 1] = 1;
                        expandedGrid[baseRow + 2][baseCol ] = 1;
                    }
                    baseCol += 3;
                }
                baseRow += 3;baseCol = 0;
            }
            for(int i=0;i<n*3;i++)
            {
                for(int j=0;j<3*n;j++)
                {
                    if (expandedGrid[i][j]==0)
                    {
                        expandedGrid = FloodFill(expandedGrid, i, j, 2);
                        index++;
                    }
                   
                }
            }
            for(int i=0;i<n*3;i++)
            {
                for(int j=0;j<n*3;j++)
                {
                    Console.Write(expandedGrid[i][j]+" ");
                }
                Console.WriteLine();
            }
            return index ;
        }
        static void Main(string[] args)
        {
            string[] a = { "/\\", "\\/" };
            Console.WriteLine(RegionBySlashes(a));
            Console.ReadLine();
        }
    }
}
