using UnityEngine;

namespace Assignment02.StudentSolution
{
    public class Enemy : Entity
    {
        public int damage;
        protected int aiLevel;

        public virtual void Attack(Entity entity)
        {

        }
        protected virtual void Patrol()
        {

        }
    }
}
