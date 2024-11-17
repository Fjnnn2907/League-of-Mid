using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HightLightManager : MonoBehaviour
{
    protected Transform hightLightObj;
    protected Transform selectObj;
    [SerializeField] protected LayerMask selectableLayerMask;

    protected Outline hightLightOutLine;
    protected RaycastHit hit;

    protected void Update()
    {
        HoverHightLight();
    }
    protected void HoverHightLight()
    {
        if(hightLightObj != null)
        {
            hightLightOutLine.enabled = false;
            hightLightObj = null;
        }
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out hit, selectableLayerMask))
        {
            hightLightObj = hit.transform;

            if(hightLightObj.CompareTag("Enemy") && hightLightObj != selectObj)
            {
                hightLightOutLine = hightLightObj.GetComponent<Outline>();
                hightLightOutLine.enabled = true;
            }
            else
            {
                hightLightObj = null;
            }
        }
    }

    public void SelectedHightLight()
    {
        if (hightLightObj.CompareTag("Enemy"))
        {
            if (selectObj != null)
                selectObj.GetComponent<Outline>().enabled = false;

            selectObj = hit.transform;
            selectObj.GetComponent<Outline>().enabled = true;

            hightLightOutLine.enabled = true;
            hightLightObj = null;
        }
    }
    public void DeSelectHightLight()
    {
        selectObj.GetComponent<Outline>().enabled = false;
        selectObj = null;
    }
}
