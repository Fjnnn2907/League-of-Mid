using System.Collections;
using UnityEngine;
using TMPro;

public class CointManager : GUIManger
{
    public static CointManager instance;
    [SerializeField] protected TextMeshProUGUI textCount;
    public int coint = 0;

    private void Start()
    {
        instance = this;
        StartCoroutine(CountCountToTime());
    }
    public override void LogicCanvas()
    {
        textCount.text = coint.ToString();  
    }
    public void AddCoint(int _coint)
    {
        coint += _coint;
    }
    public void Remove(int _coint)
    {
        coint -= _coint;
    }
    IEnumerator CountCountToTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            coint ++;
        }
    }
}
