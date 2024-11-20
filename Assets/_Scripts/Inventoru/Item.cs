using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] protected string itemName;
    [SerializeField] protected Sprite itemSprite; // Đổi sang Sprite
    [SerializeField] protected InventoryManager inventoryManager;

    public void OnButtonBuyToItem()
    {
        if (inventoryManager != null)
        {
            inventoryManager.AddItemToInventory(itemName, itemSprite);
        }
        else
        {
            Debug.LogError("InventoryManager is not assigned!");
        }
    }
}
