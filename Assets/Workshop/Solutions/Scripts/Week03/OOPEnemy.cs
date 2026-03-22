using TMPro;
using UnityEngine;
using Workshop.Solution;

namespace Solution
{

    public class OOPEnemy : Character
    {
        public TMP_Text txtHp;

        public override void SetUP()
        {
            base.SetUP();
            GetRemainEnergy();
            txtHp.text = energy.ToString();

        }

        public void Attack(OOPPlayer _player)
        {
            _player.energy -= AttackPoint;
            Debug.Log("player is energy " + _player.energy);
        }

        public override void Hit(Identity hitBy)
        {
            base.Hit(hitBy);
            if (hitBy is OOPPlayer) { 
                OOPPlayer player = (OOPPlayer)hitBy;
                Attack(player);
            }
        }
        public override void TakeDamage(int Damage)
        {
            energy -= Damage;
            txtHp.text = energy.ToString();
            Debug.Log(name + " Current Energy : " + energy);
            UpdateSpriteColorBasedOnHealth();
            CheckDead();
        }
        protected override void CheckDead()
        {
            if (energy <= 0)
            {
                mapGenerator.EnemysOnMap.Remove(this);
                mapGenerator.mapdata[positionX, positionY] = null;
                Destroy(gameObject);
            }
        }
    }
}