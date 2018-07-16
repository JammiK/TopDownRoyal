using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Interfaces.Players;
using Assets.Interfaces.Players.Stats;
using Assets.Interfaces.Weapon;
using UnityEngine;
using Zenject;

namespace Assets.Logic.Players
{
    class DamageTaker : MonoBehaviour, IDamageTaker
    {
        [Inject] readonly IHaveHealth _healthStats;

        public void TakeDamage(IDamage damage)
        {
            _healthStats.Health.Value -= damage.Value;
        }
    }
}
