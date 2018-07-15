using Assets.Interfaces.Weapon;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Assets.Logic.Weapon
{
    class ShotSystem : MonoBehaviour, IShot
    {
        [SerializeField]
        float _speed;

        [SerializeField]
        float _spread;

        public Vector3 Direction { get; set; }

        public float Spread { get; set; }

        [Inject(Id = "Self")]
        Rigidbody _rigidbody;

        [Inject]
        ShotParticle.Factory _shotParticleFactory;

        void Start()
        {
            Direction = Quaternion.AngleAxis(Random.Range(-_spread, _spread), Vector3.up) * Direction;
            _rigidbody.AddForce(Direction.normalized * _speed * 10);
            this.OnCollisionEnterAsObservable()
                .Where(collision => collision.gameObject.GetComponent<ShotSystem>() == null)
                .Subscribe(Destroy);
        }

        void Destroy(Collision collision)
        {
            var particle = _shotParticleFactory.Create();
            particle.transform.position = collision.contacts[0].point;
            particle.transform.rotation = Quaternion.LookRotation(collision.contacts[0].normal);
            Destroy(particle.gameObject, 0.5f);
            Destroy(gameObject);
        }

    }
}
