using Assets.Interfaces.Weapon;
using System;
using Assets.Logic.Weapon.Damages;
using UnityEngine;
using UniRx;
using Zenject;

namespace Assets.Logic.Weapon
{
    public class Pistol : WeaponBase
    {

        [Inject]
        readonly ShotSystem.Factory _shotFactory;

        [SerializeField]
        int _damageValue;

        [Inject]
        readonly SimpleDamage.Factory _simpleDamageFactory;

        public override void SetFireStream(IObservable<IShotPoint> stream)
        {
            stream.Subscribe(shotPoint => Shot(shotPoint, _simpleDamageFactory.Create(_damageValue)))
                .AddTo(this);
        }

        public class Factory : PlaceholderFactory<Pistol> { }
    }
}
