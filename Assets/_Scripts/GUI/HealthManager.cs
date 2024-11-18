using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : GUIManger
{
    protected Transform cameraTransform;
    [SerializeField] protected Slider healthSlider;
    [SerializeField] protected Stats healthStats;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        healthSlider.maxValue = healthStats.health;
    }
    public override void LogicCanvas()
    {
        healthSlider.value = healthStats.health;
    }
    protected void LateUpdate()
    {
        this.transform.LookAt(transform.position + cameraTransform.rotation
            * -Vector3.forward, cameraTransform.rotation * Vector3.up);
    }


}
