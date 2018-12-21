using UnityEngine;

public class OriginalSpaceship : MonoBehaviour, IOriginal
{
    private IHealth health;
    private IDestroyable destroyable;
    private ResistanceController resistanceController;

    private void Awake()
    {
        health = GetComponentInChildren<IHealth>();
        destroyable = GetComponentInChildren<IDestroyable>();
        resistanceController = GetComponentInChildren<ResistanceController>();
    }

    public bool IsDestroyed()
    {
        return destroyable.IsDestroyed();
    }

    public float GetPercentageCurrentHealth()
    {
        return health.GetPercentageCurrentHealth();
    }

    public void DealDamage(float damage, DamageType damageType = DamageType.Physical)
    {
        if (resistanceController)
        {
            health.AddHealth(-((ResistanceController.MAX_RESISTANCE - resistanceController.GetResistance(damageType)) /
                              ResistanceController.MAX_RESISTANCE * damage));
        }
        else
        {
            health.AddHealth(-damage);
        }

        destroyable.UpdateDestroyState(health.GetPercentageCurrentHealth());
        if (health.GetPercentageCurrentHealth() == 0)
        {
            destroyable.Destroy();
        }
    }
}
