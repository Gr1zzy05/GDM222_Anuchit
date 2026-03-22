using UnityEngine;

namespace Solution
{
    [CreateAssetMenu(fileName = "NewItemData", menuName = "ScriptableObjects/ItemData")]
    public abstract class ItemData : ScriptableObject
    {
        public string ItemName;
        public Sprite icon;
        [TextArea] public string description;
        public virtual void Use(Identity identity)
        {
            Debug.Log("Use Item " + identity.Name);
        }
    }
}
