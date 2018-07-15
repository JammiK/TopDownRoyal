using System;
using Assets.Interfaces.Enviroment.Weapon;
using Assets.Interfaces.Players;
using Assets.Interfaces.Weapon;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Assets.Logic.Enviroment.Weapon
{
    [RequireComponent(typeof(IWeaponDealSelector))]
    class WeaponDealer : MonoBehaviour
    {
        [SerializeField] private IWeapon _weapon;

        [SerializeField] private GameObject _place;

        [Inject(Id = "Self")] private Collider _selfCollider;
        [Inject(Id = "Self")] private IWeaponDealSelector _weaponDealSelector;

        void Start()
        {
            var stream = this.OnCollisionEnterAsObservable()
                .Select(collision => collision.gameObject.GetComponent<IWeaponSystem>())
                .Where(weaponSystem => weaponSystem != null);
                
            stream.Subscribe(DealWeapon);
            stream.Delay(new TimeSpan(0, 0, 10))
                .Subscribe(_ => SetEnable(true));
            _weapon = _weaponDealSelector.GetWeapon();
            _weapon.Transform.SetParent(_place.transform);
        }

        void DealWeapon(IWeaponSystem weaponSystem)
        {
            weaponSystem.SetWeapon(_weaponDealSelector.GetWeapon());
            SetEnable(false);
        }

        void SetEnable(bool enabled)
        {
            _selfCollider.enabled = enabled;
            _weapon.GameObject.SetActive(enabled);
        }

    }
}
