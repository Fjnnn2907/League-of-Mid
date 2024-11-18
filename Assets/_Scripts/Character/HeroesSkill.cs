using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroesSkill : MonoBehaviour
{
    public GameObject barrelPrefab; // Prefab của thùng
    public float range = 5f; // Tầm đặt thùng

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 mousePosition = hit.point;

                if (Vector3.Distance(transform.position, mousePosition) <= range)
                {
                    var Box = Instantiate(barrelPrefab, mousePosition, Quaternion.Euler(-90f, 0f, 0f));
                    Box.SetActive(true);
                }
            }
        }
    }
}
