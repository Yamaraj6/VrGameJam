using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour, IHealth
{
    private Image healthPanel;
    [Range(0f, 100f)] [SerializeField] private float maxHealth;
    private float currentHealth;

    private void Awake()
    {
        ResetHealth();
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
        if(healthPanel){healthPanel.fillAmount = currentHealth / maxHealth;}
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public float GetPercentageCurrentHealth()
    {
        return currentHealth / maxHealth * 100;
    }

    public void AddHealth(float value)
    {
        currentHealth += value;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        
        if(healthPanel){healthPanel.fillAmount = currentHealth / maxHealth;}
    }
}
