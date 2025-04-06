using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector2 target;
    public float speed = 1f;
    public float bulletSpeed = 5f;
    private GameObject player;
    public GameObject bulletPrefab;
    public float shootInterval = 1f;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(ShootAtPlayer());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    IEnumerator ShootAtPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootInterval);
            Shoot();
        }
    }
    public void Shoot()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().linearVelocity = direction * bulletSpeed;
    }
    public void SetTarget(Vector2 target)
    {
        this.target = target;
    }

}
