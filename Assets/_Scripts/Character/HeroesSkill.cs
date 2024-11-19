using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeroesSkill : MonoBehaviour
{
    [Header("Stats Skill 1")]
    public GameObject projectilePrefab; // Prefab của đạn kỹ năng Q
    public Transform firePoint;         // Vị trí xuất phát của kỹ năng
    public float projectileSpeed = 15f; // Tốc độ đạn

    [Header("Stats Skill 2")]
    public GameObject barrelPrefab;     // Prefab của thùng
    public float range = 5f;            // Tầm đặt thùng

    private void Update()
    {
        SkillOne(KeyCode.Q);
    }
    public void SkillTwo(KeyCode keyCode)
    {
        if (Input.GetKeyDown(keyCode))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 mousePosition = hit.point;
                DiractionToSkill(hit);
                if (Vector3.Distance(transform.position, mousePosition) <= range)
                {
                    var Box = Instantiate(barrelPrefab, mousePosition, Quaternion.Euler(-90f, 0f, 0f));
                    Box.SetActive(true);
                }
            }
        }
    }
    protected void DiractionToSkill(RaycastHit hit)
    {
        Vector3 targetPosition = hit.point;
        Vector3 direction = (targetPosition - firePoint.position).normalized; // Tính hướng bắn từ firePoint tới mục tiêu
        direction.y = 0; // Loại bỏ thành phần Y để giữ đạn bay nằm ngang (nếu cần)

        // Quay nhân vật về hướng chuột
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = targetRotation;
    }
    public void SkillOne(KeyCode keyCode)
    {
        if (Input.GetKeyDown(keyCode))
        {
           
        }
    }
    public void BoomItem()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            DiractionToSkill(hit);
            Vector3 targetPosition = hit.point;
            Vector3 direction = (targetPosition - firePoint.position).normalized; // Tính hướng bắn từ firePoint tới mục tiêu
            direction.y = 0; // Loại bỏ thành phần Y để giữ đạn bay nằm ngang (nếu cần)
                             // Tạo đạn và gán hướng di chuyển
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.Euler(-90, 0, 0));
            projectile.gameObject.SetActive(true);
            projectile.GetComponent<BoomItem>().SetVelocityBoomItem(direction, projectileSpeed); // Gọi hàm di chuyển
        }
    }
}
