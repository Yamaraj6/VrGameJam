using UnityEngine;

public class OriginalAlien : MonoBehaviour, IOriginal
{
    private IHealth health;
    private IDestroyable destroyable;
    private ISmashable smashable;
    private ResistanceController resistanceController;

    private void Awake()
    {
        health = GetComponentInChildren<IHealth>();
        destroyable = GetComponentInChildren<IDestroyable>();
        smashable = GetComponentInChildren<ISmashable>();
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
        if (damageType==DamageType.Smash)
        {
            health.AddHealth(-100000);
            smashable.Smash();
            destroyable.DestroyWithDelay();
            return;
        }
        

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
    }
}
