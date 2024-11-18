using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelController : MonoBehaviour
{
    public float lifetime = 20f; // Thời gian tồn tại
    public float explosionRadius = 2f; // Bán kính nổ
    public GameObject explosionEffect; // Hiệu ứng nổ

    private bool isExploded = false;

    private void Start()
    {
        Destroy(gameObject, lifetime); // Xóa thùng sau thời gian tồn tại
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
