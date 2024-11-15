using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOutLine : MonoBehaviour
{
    protected float deplay = 0.01f;
    [SerializeField] protected Outline outline;

    protected void Start()
    {
        Invoke("DisOutLine",deplay);
    }
    protected void DisOutLine()
    {
        outline.enabled = false;
    }
}
