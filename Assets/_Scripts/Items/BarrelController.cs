using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelController : MonoBehaviour
{
    public float lifetime = 20f; // Thời gian tồn tại
    public float explosionRadius = 2f; // Bán kính nổ
    public Stats stats;
    public ParticleSystem effect;

    private List<GameObject> damagedObjects = new List<GameObject>(); // Lưu các đối tượng đã nhận sát thương

    private void Start()
    {
        Destroy(gameObject, lifetime); // Xóa thùng sau thời gian tồn tại
        effect.Pause();
    }

    private void Update()
    {
        CheckDeath();
    }

    public void CheckDeath()
    {
        if (stats.health <= 0)
        {
            effect.Play();
            Boom();
            Destroy(this.gameObject, 0.2f);
        }
    }

    public void Boom()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider hit in hits)
        {
            Stats targetStats = hit.GetComponent<Stats>();
            if (targetStats != null && !damagedObjects.Contains(hit.gameObject))
            {
                float explosionDamage = 10f;
                targetStats.TakeDamge(hit.gameObject, explosionDamage);

                // Thêm đối tượng vào danh sách đã nhận sát thương
                damagedObjects.Add(hit.gameObject);
            }
        }
    }
}
