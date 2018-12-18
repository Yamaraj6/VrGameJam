using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HolographicSpaceship : MonoBehaviour, IDamageHandler
{
    private Transform spaceShip;
    private HealthController spaceShipHealthController;
    [SerializeField] private Image healthPanel;

    public void Initialize(Transform originalSpaceShip)
    {
        spaceShip = originalSpaceShip;
        spaceShipHealthController = spaceShip.GetComponent<HealthController>();
        spaceShipHealthController.SetHealthPanel(healthPanel);
    }

    public void GetDamage(float damage)
    {
        spaceShipHealthController.GetDamage(damage);
    }
}
