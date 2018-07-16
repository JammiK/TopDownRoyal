using Assets.Interfaces.Weapon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Logic.Weapon.Damages;
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

        [SerializeField]
        int _damageValue = 5;
        
        [Inject]
        readonly SimpleDamage.Factory _simpleDamageFactory;

        public override void SetFireStream(IObservable<IShotPoint> stream)
        {
            for (int i = 0; i < _shotAmount; i++)
            {
                stream.Delay(new TimeSpan(0,0,0,0,i * _miliSecondsBetweenShots))
                    .Subscribe(shotPoint => Shot(shotPoint, _simpleDamageFactory.Create(_damageValue)))
                    .AddTo(this);
            }
        }

        public class Factory : PlaceholderFactory<Gun> { }
    }
}
