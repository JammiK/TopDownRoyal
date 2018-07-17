using Assets.Scripts.Logic.Interfaces.Weapon;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Logic.Weapon
{
    class PlayerWeaponData : MonoBehaviour, IWeaponData
    {
        
        public IShotPoint ShotPoint { get; private set; }

        private IWeapon _currentWeapon;
        public IWeapon CurrentWeapon
        {
            get { return _currentWeapon; }
            set
            {
                if (CurrentWeapon != null)
                {
                    Destroy(CurrentWeapon.GameObject);
                }

                _currentWeapon = value;
                _currentWeapon.Transform.localPosition = Vector3.zero;
                _currentWeapon.Transform.localRotation = Quaternion.identity;

                ShotPoint = _currentWeapon.GameObject.GetComponentInChildren<IShotPoint>();
            }
        }

        [Inject(Id = "Self")]
        public Transform Transform { get; }
    }
}
