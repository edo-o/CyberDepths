using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image healthBarSprite;
    private float target = 1f;
    [SerializeField] private float fillSpeed = 2f;
    
    public void UpdateHealth(float currentHealth, float maxHealth)
    {
        target = currentHealth / maxHealth;
    }

    private void Update()
    {
        healthBarSprite.fillAmount = Mathf.MoveTowards(healthBarSprite.fillAmount, target, fillSpeed * Time.deltaTime);
    }
}
