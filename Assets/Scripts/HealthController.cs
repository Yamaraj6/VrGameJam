using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(IDestroyable))]
public class HealthController : MonoBehaviour
{
    private ResistanceController resistanceController;
    private IDestroyable destroyable;

    [SerializeField] private Image healtPanel;
    [Range(0f, 100f)] [SerializeField] private float maxHealth;
    private float currentHealth;

    private void Awake()
    {
        destroyable = GetComponent<IDestroyable>();
        resistanceController = GetComponent<ResistanceController>();
        if(healtPanel){healtPanel.fillAmount = currentHealth / maxHealth;}
    }

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void DealDamage(float damage, DamageType damageType = DamageType.Physical)
    {
        if (resistanceController)
        {
            currentHealth -= ((ResistanceController.MAX_RESISTANCE - resistanceController.GetResistance(damageType)) /
                ResistanceController.MAX_RESISTANCE * damage);
        }
        else
        {
            currentHealth -= damage;
        }

        destroyable.SetDestroyState(currentHealth / maxHealth);
        if(healtPanel){healtPanel.fillAmount = currentHealth / maxHealth;}
    }
}
