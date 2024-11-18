using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Stats : MonoBehaviour
{
    public float health;
    public float damgage;
    public int attackSpeed;
    
    public void TakeDamge(GameObject target, float damgage,float timeDeah)
    {
        target.GetComponent<Stats>().health -= damgage;

        if (target.GetComponent<Stats>().health <= 0)
        {
            //target.SetActive(false);
            Destroy(target, timeDeah);
        }
    }
}
