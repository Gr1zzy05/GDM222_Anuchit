using UnityEngine;

namespace Solution
{
    [CreateAssetMenu(fileName = "KeyItem", menuName = "Items/KeyItem")]
    public class ItemKey : ItemData
    {
        public int ID;
      
        public override void Use(Identity identity)
        {
            OOPPlayer player = identity as OOPPlayer;
            if (player != null)
            {
                player.inventory.AddItem(this,1);
            }

        }

    }
}
