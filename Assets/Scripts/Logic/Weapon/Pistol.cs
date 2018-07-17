using System;
using Assets.Scripts.Logic.Interfaces.Weapon;
using Assets.Scripts.Logic.Weapon.Damages;
using UniRx;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Logic.Weapon
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
