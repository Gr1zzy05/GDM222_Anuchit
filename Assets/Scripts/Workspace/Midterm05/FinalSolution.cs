using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;

namespace Midterm
{
    public class FinalSolution : IAssignment
    {
        public void EXAM01_FindWords(string[,] board, string[] words)
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
    }
}
