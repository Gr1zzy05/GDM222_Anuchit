using System.Collections;
using System.Collections.Generic;
using System.Text;
using AssignmentSystem.Services;
using UnityEngine;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;

namespace Assignment01
{
    public class StudentSolution : MonoBehaviour, IAssignment
    {

        #region Lecture

        public void LCT01_SyntaxArray()
        {
            string[] ironManSuit = new string[2];
            ironManSuit[0] = "Mark I";
            ironManSuit[1] = "Mark II";
            string tonyStarkWear = ironManSuit[0];
            Debug.Log($"TonyStark Wear: {tonyStarkWear}");
            Debug.Log($"Room size: {ironManSuit.Length}");
            Debug.Log(ironManSuit[0]);
            Debug.Log(ironManSuit[1]);
        }

        public void LCT02_ArrayInitialize()
        {
            string[] SpiderMan_suits = new string[3];
            SpiderMan_suits[0] = "Classic SpiderMan";
            SpiderMan_suits[1] = "Black Suit";
            SpiderMan_suits[2] = "Iron Spider Suit";
            string[] BatMan_suits = new string[2];
            BatMan_suits[0] = "Classic BatMan";
            BatMan_suits[1] = "White bat";
            Debug.Log($"Room size: {SpiderMan_suits.Length}");
            Debug.Log(SpiderMan_suits[0]);
            Debug.Log(SpiderMan_suits[1]);
            Debug.Log(SpiderMan_suits[2]);
            Debug.Log($"Room size: {BatMan_suits.Length}");
            Debug.Log(BatMan_suits[0]);
            Debug.Log(BatMan_suits[1]);
        }

        public void LCT03_SyntaxLoop()
        {
            for (int i = 0; i < 10; i++)
            {
                Debug.Log("<10 : " + i);
            }
            Debug.Log("===");
            for (int i = 1; i <= 10; i++)
            {
                Debug.Log("<=10 : " + i);
            }
        }

        public void LCT04_LoopAndArray(string[] ironManSuitNames)
        {
            for (int i = 0; i < ironManSuitNames.Length; i++)
            {
                Debug.Log(ironManSuitNames[i]);
            }
            Debug.Log("===");
            for (int i = 0; i < ironManSuitNames.Length; i += 2)
            {
                Debug.Log(ironManSuitNames[i]);
            }
        }

        public void LCT05_Syntax2DArray()
        {
            int[,] my2DArray = new int[2, 2]
            {
                {1,2},{3,4}
            };
            Debug.Log("my2DArray[0, 0] = " + my2DArray[0, 0]);
            Debug.Log("my2DArray[0, 1] = " + my2DArray[0, 1]);
            Debug.Log("my2DArray[1, 0] = " + my2DArray[1, 0]);
            Debug.Log("my2DArray[1, 1] = " + my2DArray[1, 1]);

            my2DArray[0, 1] = 6;
            my2DArray[1, 1] = 8;
            Debug.Log("After change value");
            Debug.Log("my2DArray[0, 1] = " + my2DArray[0, 1]);
            Debug.Log("my2DArray[1, 1] = " + my2DArray[1, 1]);
        }

        public void LCT06_SizeOf2DArray(int[,] my2DArray)
        {
            int row = my2DArray.GetLength(0);
            int column = my2DArray.GetLength(1);
            Debug.Log($"rows = {row}");
            Debug.Log($"cols = {column}");
        }

        public void LCT07_SyntaxNestedLoop(int columns, int rows)
        {
            for (int i = 0; i < rows; i++)
            {
                string row = "";
                for (int j = 0; j < columns; j++)
                {
                    row += "*";
                }
                Debug.Log(row);
            }
        }
        #endregion

        #region Assignment

        public void AS01_RandomItemDrop(GameObject[] items)
        {
            int ranNUm = Random.Range(0, items.Length);
            GameObject newInstance = Instantiate(items[ranNUm], transform.position, transform.rotation);
            newInstance.name = items[ranNUm].name;
            Debug.Log($"Got item: {newInstance.name}");
        }

        public void AS02_NestedLoopForCreate2DMap(GameObject[] floorTiles, int columns, int rows)
        {
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    GameObject g = Instantiate(floorTiles[0], new Vector2(x, y), Quaternion.identity);
                    g.name = $"[{x}:{y}]";
                }
            }
        }

        public void AS03_NestedLoopForMakingWallAround(GameObject wall, int columns, int rows)
        {
            for (int x = 0; x < columns; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    if (x == 0 || x == columns - 1 || y == 0 || y == rows - 1)
                    {
                        GameObject g = Instantiate(wall, new Vector2(x, y), transform.rotation);
                        g.name = $"[{x}:{y}]";
                    }
                }
            }

        }

        public void AS04_AttackEnemy(int[] enemyHP, int damage, int target)
        {
            int first_enemy = enemyHP[0] = Mathf.Max(0, enemyHP[0] - damage);
            int last_enemy = enemyHP[enemyHP.Length - 1] = Mathf.Max(0, enemyHP[enemyHP.Length - 1] - damage);
            int target_enemy = Mathf.Max(0, enemyHP[target] - damage);

            Debug.Log($"FirstEnemy hp :{first_enemy}");
            Debug.Log($"LastEnemy hp :{last_enemy}");
            Debug.Log($"TargetEnemy {target} hp :{target_enemy}");
        }

        public void AS05_DynamicIterationLoop(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Debug.Log(i);
            }
        }

        public void AS06_WhileLoopAndArray(string[] ironManSuitNames)
        {
            int length = ironManSuitNames.Length;
            int i = 0;
            while (i < length)
            {
                Debug.Log(ironManSuitNames[i]);
                i += 1;
            }
            Debug.Log("===");
            i = 0;
            while (i < length)
            {
                Debug.Log(ironManSuitNames[i]);
                i += 2;
            }

        }

        public void AS07_HealTargetAtIndex(int[] heroHPs, int heal, int targetIndex)
        {
            int first_hero = heroHPs[0] = Mathf.Max(0, heroHPs[0] + heal);
            int last_hero = heroHPs[heroHPs.Length - 1] = Mathf.Max(0, heroHPs[heroHPs.Length - 1] + heal);
            int target_hero = Mathf.Max(0, heroHPs[targetIndex] + heal);

            Debug.Log($"FirstHero hp :{first_hero}");
            Debug.Log($"LastHero hp :{last_hero}");
            Debug.Log($"TargetHero {targetIndex} hp :{target_hero}");
        }

        public void AS08_RandomPickingDialogue(string[] dialogues)
        {
            int talk = UnityEngine.Random.Range(0, dialogues.Length);
            Debug.Log(dialogues[talk]);
        }

        public void AS09_MultiplicationTable(int n)
        {
            for (int i = 1; i <= 12; i++)
            {
                Debug.Log($"{n}x{i}={n * i}");
            }
        }

        public void AS10_FindSummationFromZeroToNUsingWhileLoop(int n)
        {
            int i = 0;
            int sum = 0;
            while (i < n)
            {
                i++;
                sum += i;

            }
            Debug.Log($"ผลรวมของ n จาก 0 ถึง {n} คือ {sum}");
        }

        public void AS11_SpawnEnemies(int[] enemyHPs, GameObject enemyPrefab)
        {
            int length = enemyHPs.Length;

            for (int i = 0; i < length; i++)
            {
                Vector2 pos = new Vector2(i + 1, 0);
                Debug.Log($"new enemy at position x = {(int)pos.x}");
            }
        }

        public IEnumerator AS12_CountTime(float CountTime)
        {
            float timer = 0f;
            while (timer < CountTime)
            {
                timer += Time.deltaTime;
                Debug.Log($"timer : {timer.ToString("F2")}");
                yield return null;
            }
            Debug.Log($"End timer : {timer}");
        }

        public void AS13_SumOfNumbersInRow(int[,] matrix, int row)
        {
            int sum = 0;
            int length = matrix.GetLength(1);
            for (int i = 0; i < length; i++)
            {
                sum += matrix[row, i];
            }
            Debug.Log(sum);
        }

        public void AS14_SumOfNumbersInColumn(int[,] matrix, int column)
        {
            int sum = 0;
            int length = matrix.GetLength(0);
            for (int i = 0; i < length; i++)
            {
                sum += matrix[i, column];
            }
            Debug.Log(sum);
        }

        public void AS15_MakeTheTriangle(int size)
        {
            string stars = "*";
            for (int i = 0; i < size; i++)
            {
                Debug.Log(stars);
                stars += "*";
            }
        }

        public void AS16_MultiplicationTableOf_2_3_and_4()
        {
            for (int i = 1; i <= 12; i++)
            {
                Debug.Log($"2 x {i} = {2 * i}\t" + $"3 x {i} = {3 * i}\t" + $"4 x {i} = {4 * i}");
            }

        }


        #endregion

        #region Extra assignment

        public void EX_01_TicTacToeGame_TurnPlay(string[,] board, string playerTurn, int row, int column)
        {
            PrintBoard(board);
        }

        private void PrintBoard(string[,] board)
        {
            StringBuilder sb = new();
            for (int i = 0; i < 3; i++)
            {
                sb.AppendLine("-------------");
                sb.AppendLine("| " + board[i, 0] + " | " + board[i, 1] + " | " + board[i, 2] + " |");
            }
            sb.AppendLine("-------------");
            Debug.Log(sb.ToString());
        }
        #endregion
    }
    //All code assignment write by Anuchit K. (1040)...

}
