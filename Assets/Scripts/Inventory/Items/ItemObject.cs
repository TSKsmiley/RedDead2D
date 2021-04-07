using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Inventory.Interfaces;

namespace Inventory
{
    public class ItemObject : MonoBehaviour
    {
        public IItem Item;

        public new TextMeshProUGUI name;
        public Image spriteRenderer;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        public void UpdateUI()
        {
            if (Item.sprite == null) spriteRenderer.enabled = false;
            spriteRenderer.sprite = Item.sprite;
            if (Item.sprite != null) spriteRenderer.enabled = true;
        }
    }
}
