using System;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Logic.Interfaces.Weapon
{
    public interface IWeapon
    {
        ReactiveProperty<bool> IsReady { get; }
        GameObject GameObject { get; }
        Transform Transform { get; }
        void SetFireStream(IObservable<IShotPoint> stream);
    }
}
