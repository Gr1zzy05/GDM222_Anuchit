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
            throw new System.NotImplementedException();
        }

        public void LCT02_ArrayInitialize()
        {
            throw new System.NotImplementedException();
        }

        public void LCT03_SyntaxLoop()
        {
            throw new System.NotImplementedException();
        }

        public void LCT04_LoopAndArray(string[] ironManSuitNames)
        {
            throw new System.NotImplementedException();
        }

        public void LCT05_Syntax2DArray()
        {
            throw new System.NotImplementedException();
        }

        public void LCT06_SizeOf2DArray(int[,] my2DArray)
        {
            throw new System.NotImplementedException();
        }

        public void LCT07_SyntaxNestedLoop(int columns, int rows)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Assignment

        public void AS01_RandomItemDrop(GameObject[] items)
        {
            throw new System.NotImplementedException();
        }

        public void AS02_NestedLoopForCreate2DMap(GameObject[] floorTiles, int columns, int rows)
        {
            throw new System.NotImplementedException();
        }

        public void AS03_NestedLoopForMakingWallAround(GameObject wall, int columns, int rows)
        {
            throw new System.NotImplementedException();
        }

        public void AS04_AttackEnemy(int[] enemyHP, int damage, int target)
        {
            throw new System.NotImplementedException();
        }

        public void AS05_DynamicIterationLoop(int n)
        {
            throw new System.NotImplementedException();
        }

        public void AS06_WhileLoopAndArray(string[] ironManSuitNames)
        {
            throw new System.NotImplementedException();
        }

        public void AS07_HealTargetAtIndex(int[] heroHPs, int heal, int targetIndex)
        {
            throw new System.NotImplementedException();
        }

        public void AS08_RandomPickingDialogue(string[] dialogues)
        {
            throw new System.NotImplementedException();
        }

        public void AS09_MultiplicationTable(int n)
        {
            throw new System.NotImplementedException();
        }

        public void AS10_FindSummationFromZeroToNUsingWhileLoop(int n)
        {
            throw new System.NotImplementedException();
        }

        public void AS11_SpawnEnemies(int[] enemyHPs, GameObject enemyPrefab)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator AS12_CountTime(float CountTime)
        {
            throw new System.NotImplementedException();
        }

        public void AS13_SumOfNumbersInRow(int[,] matrix, int row)
        {
            throw new System.NotImplementedException();
        }

        public void AS14_SumOfNumbersInColumn(int[,] matrix, int column)
        {
            throw new System.NotImplementedException();
        }

        public void AS15_MakeTheTriangle(int size)
        {
            throw new System.NotImplementedException();
        }

        public void AS16_MultiplicationTableOf_2_3_and_4()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Extra assignment

        public void EX_01_TicTacToeGame_TurnPlay(string[,] board, string playerTurn, int row, int column)
        {
            throw new System.NotImplementedException();
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

}
