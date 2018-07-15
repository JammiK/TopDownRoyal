using Assets.Interfaces.Players.Stats;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.UI
{
    class HealthText : MonoBehaviour
    {
        [Inject(Id = "Self")]
        Text _selfText;

        [Inject(Id = "MainPlayer")]
        IHaveHealth _playerHealth;

        void Start()
        {
            _playerHealth.Health.Select(health => $"Health: {health}")
                .SubscribeToText(_selfText);
        }
    }
}
