using Assets.Scripts.Logic.Interfaces.Players;
using Assets.Scripts.Logic.Interfaces.Players.Stats;
using Assets.Scripts.Logic.Interfaces.Weapon;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Logic.Players
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
