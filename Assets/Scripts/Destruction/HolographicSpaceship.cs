using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HolographicSpaceship : MonoBehaviour, IDamageHandler
{
    [SerializeField] private OriginalSpaceship originalSpaceship;
    [SerializeField] private Image healthPanel;

    public void Initialize(OriginalSpaceship originalSpaceship)
    {
        this.originalSpaceship = originalSpaceship;
    }

    public void DealDamage(float damage)
    {
        originalSpaceship.DealDamage(damage);
        if (originalSpaceship.IsDestroyed())
        {
            gameObject.SetActive(false);
        }
        healthPanel.fillAmount = originalSpaceship.GetPercentageCurrentHealth()/100f;
    }
}
