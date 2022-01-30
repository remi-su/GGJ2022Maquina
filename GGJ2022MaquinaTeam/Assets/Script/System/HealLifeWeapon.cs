using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealLifeWeapon : MonoBehaviour
{
    [SerializeField] float healAmount = 30;

    public float getHeal()
    {
        return healAmount;
    }
}
