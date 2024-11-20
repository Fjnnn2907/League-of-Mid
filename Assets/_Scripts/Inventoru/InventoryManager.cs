using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] protected ItemSlot[] itemSlots;

    public void AddItemToInventory(string _itemName, Sprite _itemSprite)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (!itemSlots[i].isFull)
            {
                itemSlots[i].AddItemToItemSlot(_itemName, _itemSprite);
                return;
            }
        }

        Debug.Log("Inventory full!");
    }
}
