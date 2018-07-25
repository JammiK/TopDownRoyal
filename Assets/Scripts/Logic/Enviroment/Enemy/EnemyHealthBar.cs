using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Logic.Interfaces.Players.Stats;
using UniRx;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Logic.Enviroment.Enemy
{
    class EnemyHealthBar : MonoBehaviour
    {
        [Inject(Id = "Parent")] private IHaveHealth _parentHealthStats;

        [Inject(Id = "Self")] private Transform _healthBarTransform;

        void Start()
        {
            if (_healthBarTransform == null)
            {
                throw new Exception(nameof(_healthBarTransform));
            }

            Observable.CombineLatest(_parentHealthStats.Health, _parentHealthStats.MaxHealth).Subscribe(healths => UpdateHealthBar(healths[0], healths[1]));
        }

        void UpdateHealthBar(int health, int maxHealth)
        {
            var percent = (float) health / (float) maxHealth;
            _healthBarTransform.localScale = new Vector3(percent,1,1);
        }

    }
}
