using System;
using Assets.Scripts.Logic.Interfaces.Weapon;
using UniRx;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Logic.Weapon
{
    public abstract class WeaponBase : MonoBehaviour, IWeapon
    {
        [SerializeField]
        float _spread;

        [Inject]
        ShotSystem.Factory _shotFactory;

        public ReactiveProperty<bool> IsReady { get; }

        public GameObject GameObject => gameObject;

        public Transform Transform => transform;

        void Start()
        {
            transform.localPosition = Vector3.zero;
        }

        public void Reload()
        {
            throw new NotImplementedException();
        }

        protected void Shot(IShotPoint shotPoint, IDamage damage)
        {
            _shotFactory.Create(shotPoint, _spread, damage);
        }

        public abstract void SetFireStream(IObservable<IShotPoint> stream);

    }
}
