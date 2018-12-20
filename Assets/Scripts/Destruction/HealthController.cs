using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(IDestroyable))]
public class HealthController : MonoBehaviour
{
    private ResistanceController resistanceController;
    private IDestroyable destroyable;

    [SerializeField]private Image healthPanel;
    [Range(0f, 100f)] [SerializeField] private float maxHealth;
    private float currentHealth;

    private void Awake()
    {
        destroyable = GetComponent<IDestroyable>();
        resistanceController = GetComponent<ResistanceController>();
        currentHealth = maxHealth;
        if(healthPanel){healthPanel.fillAmount = currentHealth / maxHealth;}
    }

    public void SetHealthPanel(Image healtPanel)
    {
        this.healthPanel = healtPanel;
        healtPanel.fillAmount = currentHealth / maxHealth;
    }

    public void GetDamage(float damage, DamageType damageType = DamageType.Physical)
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

        destroyable.UpdateDestroyState(currentHealth / maxHealth);
        if(healthPanel){healthPanel.fillAmount = currentHealth / maxHealth;}
    }
}
