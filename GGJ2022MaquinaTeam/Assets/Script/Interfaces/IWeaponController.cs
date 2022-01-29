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

        public void TakeDamage(float damage);

        public float getLife();

    }
}