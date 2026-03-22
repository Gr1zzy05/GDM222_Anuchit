using Solution;
using UnityEngine;
using Workshop.Solution;

namespace Solution
{

    public class RandomDamagetoEnemy : MonoBehaviour
    {
        OOPMapGenerator mapGenerator;
        private void Start()
        {
            mapGenerator = GetComponent<OOPMapGenerator>();
            Invoke("RandomDamageToListEnemies", 1);
        }
        public void RandomDamageToListEnemies()
        {
            OOPEnemy[] enemysOnMap = mapGenerator.GetEnemies();
            Debug.Log($"Damage to {mapGenerator.EnemysOnMap.Count} EnemysOnMap");
            foreach (var enemy in enemysOnMap)
            {
                int damage = Random.Range(1, 15);
                enemy.TakeDamage(damage);
            }
        }
    }
}
