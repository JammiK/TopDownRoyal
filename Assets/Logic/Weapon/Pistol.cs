using Assets.Interfaces.Weapon;
using System;
using UnityEngine;
using UniRx;
using Zenject;

namespace Assets.Logic.Weapon
{
    public class Pistol : WeaponBase
    {

        public override void SetFireStream(IObservable<IShotPoint> stream)
        {
            stream.Subscribe(Shot)
                .AddTo(this);
        }

        public class Factory : PlaceholderFactory<Pistol> { }
    }
}
