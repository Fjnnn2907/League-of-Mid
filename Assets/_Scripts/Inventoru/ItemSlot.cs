using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public string itemName;
    public Sprite itemSprite; // Đổi sang Sprite vì UI.Image dùng Sprite
    public bool isFull;

    [SerializeField] TextMeshProUGUI quantityText;
    [SerializeField] Image itemImage;

    public void AddItemToItemSlot(string _itemName, Sprite _itemSprite)
    {
        itemName = _itemName;
        itemSprite = _itemSprite;
        isFull = true;

        // Cập nhật hình ảnh và hiển thị số lượng
        itemImage.sprite = itemSprite;
        itemImage.enabled = true; // Hiển thị hình ảnh nếu nó bị ẩn
        quantityText.text = "";  // Đặt số lượng ban đầu
    }

    public void ClearSlot()
    {
        itemName = "";
        itemSprite = null;
        isFull = false;

        itemImage.sprite = null;
        itemImage.enabled = false; // Ẩn hình ảnh khi slot trống
        quantityText.text = "";
    }
}
