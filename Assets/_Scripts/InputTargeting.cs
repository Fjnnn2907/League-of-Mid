using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTargeting : MonoBehaviour
{
    public GameObject selectedHeroes;
    public bool heroPlayer;
    protected RaycastHit hit;

    protected void Start()
    {
        selectedHeroes = GameObject.FindGameObjectWithTag("Player");
    }
    protected void Update()
    {
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit, Mathf.Infinity))
        {
            if(hit.collider.GetComponent<Targetable>().emenyType == Targetable.EmenyType.Minion)
            {
                selectedHeroes.GetComponent<HeroesCombat>().targetedEnemy = hit.collider.gameObject;
            }
            else if (hit.collider.gameObject.GetComponent<Targetable>() == null)
            {
                selectedHeroes.GetComponent<HeroesCombat>().targetedEnemy = null;
            }
        }        
    }
}
