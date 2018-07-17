using Assets.Scripts.Logic.Interfaces;
using Assets.Scripts.Logic.Interfaces.Players;
using Assets.Scripts.Logic.Interfaces.Weapon;
using UniRx;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Logic.Players
{
    class WeaponSystem : MonoBehaviour, IWeaponSystem
    {
        [Inject]
        IMouseScreenClickObservable _mouseScreenClickObservable;

        [Inject(Id = "Child")]
        IWeaponData _weaponData;

        public void SetWeapon(IWeapon weapon)
        {
            weapon.GameObject
                .transform
                .SetParent(_weaponData.Transform);

            _weaponData.CurrentWeapon = weapon;

            var fireStream = _mouseScreenClickObservable.OnMouseTwitchUp()
                .Select(_ => _weaponData.ShotPoint);

            //_mouseScreenClickObservable.OnMouseTwitchUp().Subscribe(tuple => Debug.Log(tuple));

            weapon.SetFireStream(fireStream);
            
        }
    }
}
