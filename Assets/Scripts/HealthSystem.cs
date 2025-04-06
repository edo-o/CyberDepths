using System.Collections;
using System.Runtime.CompilerServices;
using UnityEditor.Build.Content;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameManager LoseGame;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    [SerializeField] private HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;

        if (healthBar != null)
        {
            healthBar.UpdateHealth(currentHealth, maxHealth);
        }

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (healthBar != null)
        {
            healthBar.UpdateHealth(currentHealth, maxHealth);
        }

        StartCoroutine(FlashRed());

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = originalColor;

        if (healthBar != null)
        {
            healthBar.UpdateHealth(currentHealth, maxHealth);
        }
    }

    void Die()
    {
        if (gameObject.CompareTag("Player"))
        {
            GameManager.instance.GameOver();
            Destroy(gameObject);
        }

        if (gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

}