using Assets.Scripts.Logic.Interfaces.Players;
using Assets.Scripts.Logic.Interfaces.Players.Stats;
using Assets.Scripts.Logic.Interfaces.Weapon;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Logic.Players
{
    [RequireComponent(typeof(IHaveHealth))]
    class DamageTaker : MonoBehaviour, IDamageTaker
    {
        [Inject(Id = "Self")] readonly IHaveHealth _selfHealthStats;

        public void TakeDamage(IDamage damage)
        {
            _selfHealthStats.Health.Value -= damage.Value;
            Debug.Log($"Get Damage {damage.Value}");
        }
    }
}
