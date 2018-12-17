using System;
using System.Collections.Generic;
using UnityEngine;

public class ResistanceController : MonoBehaviour
{
   public const float MAX_RESISTANCE = 100f;
   
   [SerializeField] private List<Resistance> resistances;

   public float GetResistance(DamageType damageType)
   {
      foreach (var resistance in resistances)
      {
         if (resistance.damageType == damageType)
         {
            return resistance.value;
         }
      }

      return 0;
   }
}
[Serializable]
public class Resistance
{
   public DamageType damageType;
   [UnityEngine.Range(0, ResistanceController.MAX_RESISTANCE)] 
   public float value;
}
