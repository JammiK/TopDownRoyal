using Assets.Interfaces.Weapon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;
using Zenject;

namespace Assets.Logic.Weapon
{
    public class Gun : WeaponBase
    {
        [SerializeField]
        int _shotAmount;

        [SerializeField]
        int _miliSecondsBetweenShots;

        public override void SetFireStream(IObservable<IShotPoint> stream)
        {
            for (int i = 0; i < _shotAmount; i++)
            {
                stream.Delay(new TimeSpan(0,0,0,0,i * _miliSecondsBetweenShots)).Subscribe(Shot).AddTo(this);
            }
        }

        public class Factory : PlaceholderFactory<Gun> { }
    }
}
