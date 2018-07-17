using Assets.Scripts.Logic.Interfaces.Players.Stats;
using Assets.Scripts.Logic.Interfaces.SiSystem;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Logic.SiSystems
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
