using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillEnemy : GUIManger
{
    public static KillEnemy Instance;
    public int CountEnemy;
    public TextMeshProUGUI textUI;

    private void Awake()
    {
        Instance = this;
    }

    public void AddKill(int countEnemy)
    {
        CountEnemy += countEnemy;
    }

    public override void LogicCanvas()
    {
        textUI.text = $"tiêu diệt {CountEnemy}/3 quái vật";
        if(CountEnemy >= 3)
            textUI.color = Color.green;


    }
}
