using UnityEngine;
using UniRx;
using Assets.Interfaces.Weapon;
using Assets.Interfaces;
using Zenject;
using Assets.Logic.Weapon;
using System;
using Assets.Interfaces.Players;

namespace Assets.Logic.Players
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
