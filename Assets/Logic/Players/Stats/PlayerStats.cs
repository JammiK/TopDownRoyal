using Assets.Interfaces.Players.Stats;
using UniRx;
using UnityEngine;

namespace Assets.Logic.Players.Stats
{
    class PlayerStats : MonoBehaviour, IHaveHealth
    {
        public IntReactiveProperty Health { get; private set; }
        public IntReactiveProperty MaxHealth { get; private set; } = new IntReactiveProperty(100);

        void Awake()
        {
            Health = new IntReactiveProperty(85);
        }

        void Reset()
        {
            Health.Value = MaxHealth.Value;
        }


    }
}
