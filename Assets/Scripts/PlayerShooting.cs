using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float cooldown = 0.5f;
    private float nextFireTime = 0f;
    public float bulletLife = 1f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + cooldown;
        }

    }


    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Vector2 direction = -bulletSpawn.up;
        float bulletSpeed = 10f;
        rb.linearVelocity = direction * bulletSpeed;
    }
}
