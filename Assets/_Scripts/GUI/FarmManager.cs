using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FarmManager : GUIManger
{
    public static FarmManager instance;
    [SerializeField] protected TextMeshProUGUI farmText;
    [SerializeField] protected int CountFarm = 0;
    private void Awake()
    {
        instance = this;
    }
    public override void LogicCanvas()
    {
        farmText.text = CountFarm.ToString();
    }

    public void AddCount(int count)
    {
        CountFarm += count;
    }
}
