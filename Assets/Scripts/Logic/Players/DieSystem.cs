using Assets.Scripts.Logic.Interfaces.Players;
using Assets.Scripts.Logic.Interfaces.Players.Stats;
using UniRx;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Logic.Players
{
    class DieSystem : MonoBehaviour, IDieSystem
    {

        [Inject(Id="Self")] private readonly IHaveHealth _selfHealth;

        void Start()
        {
            _selfHealth.Health
                .Where(health => health <= 0)
                .Subscribe(health => Die());
        }

        void Die()
        {
            Destroy(gameObject);
        }
    }
}
