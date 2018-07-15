using Assets.Interfaces.Players.Stats;
using UnityEngine;
using Zenject;

namespace Assets.Logic.SiSystem
{
    class HealSystem : IHealSystem, IInitializable
    {
        public void Heal(IHaveHealth health, int value)
        {
            health.Health.Value = Mathf.Clamp(health.Health.Value + value, 0, health.MaxHealth.Value);
        }

        public void Initialize()
        {
            
        }
    }
}
