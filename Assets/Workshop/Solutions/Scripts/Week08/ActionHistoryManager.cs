using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
namespace Solution
{
    public class ActionHistoryManager : MonoBehaviour
    {
        // 1. Undo System using Stack

        private Stack<Vector2> undoStack = new Stack<Vector2>();
        // 2. Auto-Move System using Queue
        private Queue<Vector2> autoMoveQueue = new Queue<Vector2>();
        #region "This Is undoStack Function"
         private Stack<Vector2> redoStack = new Stack<Vector2>();
        /// Saves the current player state (position) to the undo stack.
        public void SaveStateForUndo(Vector2 currentPosition)
        {
            if (undoStack.Count == 0 || !undoStack.Peek().Equals(currentPosition))
            {
                undoStack.Push(currentPosition);
                if (redoStack.Count > 0)
                {
                    redoStack.Clear();
                    Debug.Log("Redo stack cleared.");
                }
                Debug.Log($"State saved: position {currentPosition}");
            }
            
        }
        /// Reverts the player's state to the previous one using the undo stack.
        /// </summary>
        public void UndoLastMove(OOPPlayer player)
        {
           if(undoStack.Count > 1)
            {
                Vector2 currentposition = undoStack.Pop();
                redoStack.Push(currentposition);
                Vector2 previousState = undoStack.Peek();
                transform.position = previousState;

                int toX = (int)transform.position.x;
                int toY = (int)transform.position.y;

                player.UpdatePosition(toX, toY);
                Debug.Log($"undo successfull");
            }
        }
        public void RedoLastMove(OOPPlayer player)
        {
            if(redoStack.Count > 0)
            {
                Vector2 stateToRedo = redoStack.Pop();
                undoStack.Push(stateToRedo);
                transform.position = stateToRedo;

                int toX = (int)transform.position.x;
                int toY = (int)transform.position.y;

                player.UpdatePosition(toX, toY);
                Debug.Log($"Redo suscessfull");
            }
            else
            {
                Debug.Log("cannot redo");
            }
        }
        #endregion

        #region "This Is autoMoveQueue Function"

        public void StartAutoMoveSequence(OOPPlayer player)
        {
            List<Vector2> sequence = new List<Vector2>
            {
                
                    Vector2.up,
                    Vector2.up,
                    Vector2.up,
                    Vector2.up,
                    Vector2.up,
                    Vector2.up,
                    Vector2.up,
                    Vector2.right,
                     Vector2.right,
                      Vector2.right,
                       Vector2.right,
                      Vector2.right,
                       Vector2.right,

            }
            ;
            StartCoroutine(ProcessAutoMoveSequence(sequence, player));
        }
        public IEnumerator ProcessAutoMoveSequence(List<Vector2> moves, OOPPlayer player)
        {
            player.isAutoMoving = true;
            // 1. เตรียม Queue: ล้าง Queue เดิมและเพิ่มลำดับการเคลื่อนที่ใหม่
            autoMoveQueue.Clear();
            // 2. ประมวลผล Queue ทีละขั้นตอน
            foreach (var move in moves)
            {
                autoMoveQueue.Enqueue(move);
            }
            Debug.Log($"Auto move sequenene stared with {autoMoveQueue.Count} steps");

            while(autoMoveQueue.Count > 0)
            {
                Vector2 nextDirection = autoMoveQueue.Dequeue();
                player.Move(nextDirection);
                yield return new WaitForSeconds(0.5f);
            }
            

            player.isAutoMoving = false;
            Debug.Log("Auto-move sequence finished.");
        }

        #endregion

    }
}

