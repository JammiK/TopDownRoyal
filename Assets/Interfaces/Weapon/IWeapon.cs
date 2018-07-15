using UniRx;
using UnityEngine;
using System;

namespace Assets.Interfaces.Weapon
{
    public interface IWeapon
    {
        ReactiveProperty<bool> IsReady { get; }
        GameObject GameObject { get; }
        Transform Transform { get; }
        void SetFireStream(IObservable<IShotPoint> stream);
    }
}
