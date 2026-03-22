using System;
using System.Collections.Generic;
using UnityEngine;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;

namespace Assignment07
{
    public class StudentSolution : IAssignment
    {
        #region Lecture

        public void LCT01_RecursiveFactorial(int n)
        {
            int result = Factorial(n);
            Debug.Log($"{result}");
        }

        private int Factorial(int n)
        {
            // base case
            if(n <= 1) return 1;
            // recursive case
            return n * Factorial(n-1);
            //10 * Factorial(10-1)
            //9 * Factorial(9-1)
            //..
            //1 * Factorial(1-1)
        }

        public void LCT02_RecursiveFibonacci(int n)
        {
            int result = Fibonacci(n);
            Debug.Log($"{result}");
        }

        private int Fibonacci(int n)
        {
            // base case
            if(n <= 1) return n;
            // recursive case
            return Fibonacci(n-1) + Fibonacci(n - 2);
        }

        public void LCT03_RecursiveSumOfOneToN(int n)
        {
            int result = SumOfOneToN(n);
            Debug.Log($"{result}");
        }

        private int SumOfOneToN(int n)
        {
            // base case
            if(n<=0) return 0;
            // recursive case
            return n + SumOfOneToN(n-1);
        }

        public void LCT04_RecursiveSumOfNumbers(int[] numbers)
        {
            int result = SumOfNumbers(numbers, 0);
            Debug.Log($"{result}");
        }

        private int SumOfNumbers(int[] numbers, int index)
        {
            // base case

            // recursive case

            return -1;
        }

        #endregion

        #region Assignment

        public void ASN01_RecursivePower(int baseNum, int exponent)
        {
            int result = Power(baseNum, exponent);
            Debug.Log($"{result}");
        }

        private int Power(int baseNum, int exponent)
        {
            return -1;
        }

        public void ASN02_IsPalindrome(string str)
        {
            bool result = IsPalindrome(str, 0, str.Length - 1);
            if (result)
                Debug.Log($"is a palindrome");
            else
                Debug.Log($"is not a palindrome");

        }

        private bool IsPalindrome(string str, int start, int end)
        {
            return false;
        }

        public void ASN03_RecursiveGCD(int a, int b)
        {
            int result = GCD(a, b);
            Debug.Log($"{result}");
        }

        private int GCD(int a, int b)
        {
            return -1;
        }

        public void ASN04_RecursiveBinarySearch(int[] arr, int target)
        {
            int result = BinarySearch(arr, target, 0, arr.Length - 1);
            Debug.Log($"{result}");
        }

        private int BinarySearch(int[] arr, int target, int low, int high)
        {
            return -1;
        }

        #endregion


        #region Extra

        public void EX01_FindWords(string[,] board, string[] words)
        {
            EX01_Solution2(board, words);
        }

        private class PathNode
        {
            public int x;
            public int y;
            public int index;
            public int nextDir;

            public PathNode(int x, int y, int index, int nextDir)
            {
                this.x = x;
                this.y = y;
                this.index = index;
                this.nextDir = nextDir;
            }
        }

        private void EX01_Solution1(string[,] board, string[] words)
        {
            var foundWords = new List<string>();

            var visited = new bool[board.GetLength(0), board.GetLength(1)];
            var directions = new (int, int)[]
            {
                (-1, -1), (-1, 0), (-1, 1),
                (0, -1),          (0, 1),
                (1, -1),  (1, 0),  (1, 1)
            };

            foreach (var word in words)
            {
                bool wordFound = false;
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        if (board[i, j] == word[0].ToString())
                        {
                            Array.Clear(visited, 0, visited.Length);
                            if (FindWord(board, word, i, j, visited, directions))
                            {
                                foundWords.Add(word);
                                wordFound = true;
                                break;
                            }
                        }
                    }
                    if (wordFound) break;
                }
            }

            foreach (var word in foundWords)
            {
                Debug.Log(word);
            }
        }

        private bool FindWord(string[,] board, string word, int startX, int startY, bool[,] visited, (int, int)[] directions)
        {
            if (string.IsNullOrEmpty(word))
            {
                return false;
            }

            if (board[startX, startY] != word[0].ToString())
            {
                return false;
            }

            var path = new LinkedList<PathNode>();
            path.AddLast(new PathNode(startX, startY, 0, 0));
            visited[startX, startY] = true;

            while (path.Count > 0)
            {
                var node = path.Last;

                var cx = node.Value.x;
                var cy = node.Value.y;
                var cindex = node.Value.index;
                var nextDir = node.Value.nextDir;

                if (cindex == word.Length - 1)
                {
                    return true;
                }

                if (nextDir >= directions.Length)
                {
                    visited[cx, cy] = false;
                    path.RemoveLast();
                    continue;
                }

                var (dx, dy) = directions[nextDir];
                node.Value = new PathNode(cx, cy, cindex, nextDir + 1);

                int nx = cx + dx;
                int ny = cy + dy;
                int nextIndex = cindex + 1;

                if (nx < 0 || nx >= board.GetLength(0) || ny < 0 || ny >= board.GetLength(1))
                {
                    continue;
                }

                if (visited[nx, ny])
                {
                    continue;
                }

                if (board[nx, ny] != word[nextIndex].ToString())
                {
                    continue;
                }

                visited[nx, ny] = true;
                path.AddLast(new PathNode(nx, ny, nextIndex, 0));
            }

            return false;
        }

        private void EX01_Solution2(string[,] board, string[] words)
        {
            var foundWords = new List<string>();
            var visited = new bool[board.GetLength(0), board.GetLength(1)];
            var directions = new (int, int)[]
            {
                (-1, 0), (1, 0), (0, -1), (0, 1)
            };

            foreach (var word in words)
            {
                bool wordFound = false;
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        if (board[i, j] == word[0].ToString())
                        {
                            Array.Clear(visited, 0, visited.Length);
                            if (DFS(board, word, i, j, 0, visited, directions))
                            {
                                foundWords.Add(word);
                                wordFound = true;
                                break;
                            }
                        }
                    }
                    if (wordFound) break;
                }
            }

            foreach (var word in foundWords)
            {
                Debug.Log(word);
            }
        }

        private bool DFS(string[,] board, string word, int x, int y, int index, bool[,] visited, (int, int)[] directions)
        {
            // Base case: if we've matched all characters
            if (index == word.Length - 1)
            {
                return true;
            }

            // Mark current cell as visited
            visited[x, y] = true;

            // Explore all 8 directions
            foreach (var (dx, dy) in directions)
            {
                int nx = x + dx;
                int ny = y + dy;

                // Check bounds
                if (nx < 0 || nx >= board.GetLength(0) || ny < 0 || ny >= board.GetLength(1))
                {
                    continue;
                }

                // Check if already visited
                if (visited[nx, ny])
                {
                    continue;
                }

                // Check if next character matches
                if (board[nx, ny] == word[index + 1].ToString())
                {
                    // Recursively search for the rest of the word
                    if (DFS(board, word, nx, ny, index + 1, visited, directions))
                    {
                        visited[x, y] = false; // Backtrack
                        return true;
                    }
                }
            }

            // Backtrack: unmark current cell
            visited[x, y] = false;
            return false;
        }

        #endregion
    }
}
