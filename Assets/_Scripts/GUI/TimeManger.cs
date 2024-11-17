using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManger : GUIManger
{
    [SerializeField] protected TextMeshProUGUI timeText;
    protected float time = 0;

    public override void LogicCanvas()
    {
        time += Time.deltaTime;
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timeText.text = string.Format("{00:00}:{01:00}",minutes,seconds);
    }
}
