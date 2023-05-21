namespace ShortestBridge
{
    internal class Program
    {
        public class BridgeShortest
        {
            public int ShortestBridge(int[][] grid)
            {
                int n = grid.Length;
                int firstPositionX = -1;
                int firstPositionY = -1;
                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j < n; ++j)
                    {
                        if (grid[i][j] == 1)
                        {
                            firstPositionX = i;
                            firstPositionY = j;
                            break;
                        }
                    }
                }
                int[] deltaX = new int[] { 0, -1, 0, 1 };
                int[] deltaY = new int[] { -1, 0, 1, 0 };
                Queue<int[]> firstQueue = new();
                Queue<int[]> secondQueue = new();
                firstQueue.Enqueue(new int[] { firstPositionX, firstPositionY });
                secondQueue.Enqueue(new int[] { firstPositionX, firstPositionY });
                grid[firstPositionX][firstPositionY] = 2;
                while(firstQueue.Count > 0 )
                {
                    int queueSize = firstQueue.Count;
                    for (; queueSize > 0; --queueSize)
                    {
                        int[] cell = firstQueue.Dequeue();
                        for (int i = 0; i < 4; ++i)
                        {
                            int newX = cell[0] + deltaX[i];
                            int newY = cell[1] + deltaY[i];
                            if (newX >= 0 && newX < n && newY >= 0 && newY < n && grid[newX][newY] == 1)
                            {
                                firstQueue.Enqueue(new int[] { newX, newY });
                                secondQueue.Enqueue(new int[] { newX, newY });
                                grid[newX][newY] = 2;
                            }
                        }
                    }
                }
                int distance = 0;
                while(secondQueue.Count > 0)
                {
                    int queueSize = secondQueue.Count;
                    for (; queueSize > 0; --queueSize)
                    {
                        int[] cell = secondQueue.Dequeue();
                        for (int i = 0; i < 4; ++i)
                        {
                            int newX = cell[0] + deltaX[i];
                            int newY = cell[1] + deltaY[i];
                            if (newX >= 0 && newX < n && newY >= 0 && newY < n)
                            {
                                if (grid[newX][newY] == 1)
                                {
                                    return distance;
                                }
                                else if (grid[newX][newY] == 0)
                                {
                                    secondQueue.Enqueue(new int[] { newX, newY });
                                    grid[newX][newY] = -1;
                                }
                            }
                        }
                    }
                    ++distance;
                }
                return distance;
            }
        }

        static void Main(string[] args)
        {
            BridgeShortest bridgeShortest = new();
            Console.WriteLine(bridgeShortest.ShortestBridge(new int[][]
            {
                new int[] { 1, 0 },
                new int[] { 0, 1 }
            }));
            Console.WriteLine(bridgeShortest.ShortestBridge(new int[][]
            {
                new int[] { 0, 1, 0 },
                new int[] { 0, 0, 0 },
                new int[] { 0, 0, 1 }
            }));
            Console.WriteLine(bridgeShortest.ShortestBridge(new int[][]
            {
                new int[] { 1, 1, 1, 1, 1 },
                new int[] { 1, 0, 0, 0, 1 },
                new int[] { 1, 0, 1, 0, 1 },
                new int[] { 1, 0, 0, 0, 1 },
                new int[] { 1, 1, 1, 1, 1 }
            }));
        }
    }
}