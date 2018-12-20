using UnityEngine;

public abstract class ADamageHandler:MonoBehaviour
{
    public abstract void DealDamage(float damage, DamageType damageType=DamageType.Physical);
}
