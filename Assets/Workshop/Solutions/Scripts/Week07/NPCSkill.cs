using UnityEngine;

namespace Solution
{
    public class NPCSkill : Identity
    {
        public GameObject skillUi;
        public bool canTalk = true;
        public override void SetUP()
        {
            base.SetUP();
            Name = "NPC";
            Invoke("SetMapData", 0.1f);
        }
        void SetMapData()
        {
            mapGenerator = FindFirstObjectByType<OOPMapGenerator>();
            mapGenerator.mapdata[positionX, positionY] = this;
        }
        public override void Hit(Identity identity)
        {
            if (canTalk && identity is OOPPlayer)
            {
                Debug.Log("NPC Skill");
                skillUi.SetActive(true);
            }
            else {
                Debug.Log("I don't need to take to you.");
            }
        }
    }
}
