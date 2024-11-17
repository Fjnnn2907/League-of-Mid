using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GUIManger : MonoBehaviour
{
    protected void Update()
    {
        this.LogicCanvas();
    }
    public abstract void LogicCanvas();
}
