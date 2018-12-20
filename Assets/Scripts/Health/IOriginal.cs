public interface IOriginal
{
    bool IsDestroyed();
    float GetPercentageCurrentHealth();
    void DealDamage(float damage, DamageType damageType = DamageType.Physical);
}
