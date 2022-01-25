using UnityEditor;
using UnityEngine;

namespace Assets.Script.Interfaces
{
    public interface IWeaponController
    {

        public void Shoot();
        public void CureWeapon(float amontHeal);

        public bool getStatusLocked();

        public void TakeNewInstance();
    }
}