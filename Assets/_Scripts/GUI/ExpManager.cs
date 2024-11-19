using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExpManager : GUIManger
{   
    public static ExpManager instance;
    [SerializeField] protected TextMeshProUGUI textLevel;
    [SerializeField] protected Slider slider;

    public int Exp = 0; 
    public int currentLevel = 1; 
    public int expToNextLevel = 100; 

    private void Start()
    {
        instance = this;    
        UpdateUI();
    }

    // Hàm gọi để thêm kinh nghiệm
    public void AddExp(int _Exp)
    {
        Exp += _Exp; 

        while (Exp >= expToNextLevel)
        {
            LevelUp();
        }

        UpdateUI(); 
    }

    private void LevelUp()
    {
        Exp -= expToNextLevel;
        currentLevel++;
        expToNextLevel = Mathf.CeilToInt(expToNextLevel * 1.5f);
    }

    private void UpdateUI()
    {
        slider.value = (float)Exp / expToNextLevel;
        textLevel.text = currentLevel.ToString();
    }

    public override void LogicCanvas()
    {
        UpdateUI();
    }
}
