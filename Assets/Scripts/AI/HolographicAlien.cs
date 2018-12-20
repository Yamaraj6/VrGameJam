using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolographicAlien : ADamageHandler
{
    [SerializeField] private OriginalAlien originalAlien;
    
    public void Initialize(OriginalAlien originalAlien)
    {
        this.originalAlien = originalAlien;
    }

    public override void DealDamage(float damage, DamageType damageType = DamageType.Physical)
    {
        originalAlien.DealDamage(damage, damageType);
    }
}
