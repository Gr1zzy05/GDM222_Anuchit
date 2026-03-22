using UnityEngine;
using static UnityEditor.PlayerSettings;

namespace Solution
{

    public class OOPPlayer : Character
    {
        public Inventory inventory;
        public int Gold;
        public ItemData KeyItemFireStorm;
        public bool isAutoMoving;
        public ActionHistoryManager actionhistoymanager;
        public override void SetUP()
        {
            PrintInfo();
            GetRemainEnergy();
            actionhistoymanager = GetComponent<ActionHistoryManager>();
            Vector2 pos = new Vector2(positionX, positionY);
            actionhistoymanager.SaveStateForUndo(pos);
        }

        public void Update()
        { 
            if(isAutoMoving == false)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    Move(Vector2.up);
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    Move(Vector2.down);
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    Move(Vector2.left);
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    Move(Vector2.right);
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    UseFireStorm();
                }
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    actionhistoymanager.UndoLastMove(this);
                }
                if (Input.GetKeyDown(KeyCode.Y))
                {
                    actionhistoymanager.RedoLastMove(this);
                }

                // Input for starting an example auto-move sequence (Q key)
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    actionhistoymanager.StartAutoMoveSequence(this);
                }
            }
            
        }

        public override void UpdatePosition(int toX, int toY)
        {
            base.UpdatePosition(toX, toY);
            Vector2 pos = new Vector2(positionX, positionY);
            actionhistoymanager.SaveStateForUndo(pos);
        }
        public void Attack(OOPEnemy _enemy)
        {
            _enemy.energy -= AttackPoint;
            Debug.Log(_enemy.name + " is energy " + _enemy.energy);
        }

        protected override void CheckDead()
        {
            base.CheckDead();
            if (energy <= 0)
            {
                Debug.Log("Player is Dead");
            }
        }
        public void UseFireStorm()
        {
            if (inventory.HasItem(KeyItemFireStorm, 1))
            {
                inventory.UseItem(KeyItemFireStorm, 1);
                OOPEnemy[] enemies = UtilitySortEnemies.SortEnemiesByRemainningEnergy1(mapGenerator);
                int count = 3;
                if (count > enemies.Length)
                {
                    count = enemies.Length;
                }
                for (int i = 0; i < count; i++)
                {
                    enemies[i].TakeDamage(10);
                }
            }
            else
            {
                Debug.Log("No FireStorm in inventory");
            }
        }
    }

}