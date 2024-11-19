using UnityEngine;

public class BoomItem : MonoBehaviour
{
    private Vector3 moveDirection; // Hướng di chuyển
    private float speed;           // Tốc độ di chuyển

    public void SetVelocityBoomItem(Vector3 direction, float projectileSpeed)
    {
        moveDirection = direction;
        speed = projectileSpeed;
    }
    private void Update()
    {
        // Di chuyển đạn theo hướng đã tính
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

        Boom();
        Destroy(gameObject, .5f);
    }
    public void Boom()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, .5f);

        foreach (Collider hit in hits)
        {
            Stats targetStats = hit.GetComponent<Stats>();
            if (targetStats != null)
            {
                targetStats.TakeDamge(hit.gameObject, 10);
                Destroy(this.gameObject);
            }
        }
        
    }

}
