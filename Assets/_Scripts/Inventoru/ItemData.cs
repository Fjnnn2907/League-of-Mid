using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new data",menuName =("ItemData"))]
public class ItemData : ScriptableObject
{
    public string NameItem;
    public string DescriptionItem;
    public int PriceItem;
    public Sprite IconItem;
    public List<StasItem> itemDatas;
}

[System.Serializable]
public class StasItem
{
    public int Heeal;
    public int Damage;
    public int deff;
    public int speed;
}
