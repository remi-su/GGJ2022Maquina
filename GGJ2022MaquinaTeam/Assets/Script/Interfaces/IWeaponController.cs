using UnityEditor;
using UnityEngine;

namespace Assets.Script.Interfaces
{
    public interface IWeaponController
    {

        public void Shoot();
        public void Reload();

        public bool getStatusLocked();
    }
}