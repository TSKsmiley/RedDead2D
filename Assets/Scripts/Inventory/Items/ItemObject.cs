using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class ItemObject : MonoBehaviour
    {
        public Item Item;

        public TextMeshProUGUI Quantity;
        public Image spriteRenderer;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        public void UpdateUI(int amount)
        {
            Quantity.text = amount > 1 ? amount.ToString() : "";
            
            if (Item.sprite == null) spriteRenderer.enabled = false;
            spriteRenderer.sprite = Item.sprite;
            if (Item.sprite != null) spriteRenderer.enabled = true;
        }
    }
}
