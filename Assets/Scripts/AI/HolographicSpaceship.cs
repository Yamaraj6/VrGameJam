﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HolographicSpaceship : ADamageHandler
{
    [SerializeField] private OriginalSpaceship originalSpaceship;
    [SerializeField] private Image healthPanel;

    public void Initialize(OriginalSpaceship originalSpaceship)
    {
        this.originalSpaceship = originalSpaceship;
    }

    public override void DealDamage(float damage, DamageType damageType)
    {
        originalSpaceship.DealDamage(damage, damageType);
        if (originalSpaceship.IsDestroyed())
        {
            gameObject.SetActive(false);
        }
        healthPanel.fillAmount = originalSpaceship.GetPercentageCurrentHealth()/100f;
    }
}
