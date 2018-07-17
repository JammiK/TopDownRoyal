using Assets.Scripts.Logic.Interfaces.Players.Stats;
using Assets.Scripts.Logic.Interfaces.SiSystem;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Logic.Enviroment.FirstAid
{
    class FirstAid : MonoBehaviour
    {
        [SerializeField]
        int _value;

        [SerializeField]
        int _cooldown;

        [SerializeField]
        GameObject _aidObject;

        [Inject(Id = "Self")]
        Collider _selfCollider;
        
        [Inject]
        IHealSystem _healSystem;

        void Start()
        {
            var stream = this.OnCollisionEnterAsObservable()
                .Select(collision => collision.gameObject.GetComponent<IHaveHealth>())
                .Where(healthStat => healthStat != null);

            stream.Subscribe(UseAid);
            stream.Delay(new System.TimeSpan(0, 0, _cooldown))
                .Subscribe(health => SetEnable(true));
        }

        void UseAid(IHaveHealth health)
        {
            _healSystem.Heal(health, _value);
            SetEnable(false);
        }

        void SetEnable(bool enabled)
        {
            _selfCollider.enabled = enabled;
            _aidObject.SetActive(enabled);
        }
    }
}
