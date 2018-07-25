using Assets.Scripts.Logic.Interfaces.Players.Stats;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Logic.Players.Stats
{
    class CharacterStats : MonoBehaviour, IHaveHealth
    {
        [SerializeField]
        [Range(1,100)]
        private int _defaultMaxHealth = 50;

        public IntReactiveProperty Health { get; private set; }
        public IntReactiveProperty MaxHealth { get; private set; }

        void Awake()
        {
            MaxHealth = new IntReactiveProperty(_defaultMaxHealth);
            Health = new IntReactiveProperty(_defaultMaxHealth);
        }

        void Reset()
        {
            Health.Value = MaxHealth.Value;
        }


    }
}
