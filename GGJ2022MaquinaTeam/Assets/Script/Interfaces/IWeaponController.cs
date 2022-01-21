using UnityEditor;
using UnityEngine;

namespace Assets.Script.Interfaces
{
    public interface IWeaponController
    {

        public void Shoot(Transform fireSpot);
        public void Reload();
    }
}