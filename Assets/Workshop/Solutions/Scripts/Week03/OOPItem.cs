using Assignment02.StudentSolution;
using UnityEngine;
using UnityEngine.UIElements;

namespace Solution
{

    public class OOPItem : Identity
    {
        SpriteRenderer spriteRenderer;
        public ItemData itemData;

        public override void SetUP()
        {
            base.SetUP();
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = itemData.icon;
            
        }
        public override void Hit(Identity hitBy)
        {
            itemData.Use(hitBy);
            if (hitBy is Character) {
                Character character = (Character)hitBy;
                character.UpdatePosition(positionX, positionY);
            }
            

            Destroy(this.gameObject);
        }
    }
}