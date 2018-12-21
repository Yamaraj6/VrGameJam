using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashDetector : MonoBehaviour
{
    [SerializeField] private ADamageHandler damageHandler;
    [SerializeField] private List<Mark> marksInProperOrder;
    [SerializeField] private float blockTime=0.5f;
    private float timer;
    
    public void Check(Mark checkedMark)
    {
        if ((timer != 0)) return;
        
        for (var i = 0; i < marksInProperOrder.Count; i++)
        {
            var mark = marksInProperOrder[i];

            if (!mark.isChecked && !mark.Equals(checkedMark))
            {
                UncheckAll();
                return;
            }

            if (mark.Equals(checkedMark))
            {
                mark.isChecked = true;
                if (marksInProperOrder.Count - 1 == i)
                {
                    UncheckAll();
                    damageHandler.DealDamage(100, DamageType.Smash);
                }
            }
        }
    }

    public void UncheckAll()
    {
        
        Debug.Log("Uncheck all!");
        marksInProperOrder.ForEach(mark => mark.isChecked = false);
        timer = blockTime;
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                timer = 0;
            }
        }
    }
}