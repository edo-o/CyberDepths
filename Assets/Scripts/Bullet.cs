using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletLife = 5f;
    private float timer = 0f;
    public float bulletspeed = 5f;

    void Start()
    {
        
    }

    void Update()
    {

        if (timer > bulletLife) Destroy(this.gameObject);
        timer += Time.deltaTime;    
    }
}
