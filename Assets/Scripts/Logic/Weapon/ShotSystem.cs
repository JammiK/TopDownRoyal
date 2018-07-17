using Assets.Scripts.Logic.Interfaces.Players;
using Assets.Scripts.Logic.Interfaces.Weapon;
using Assets.Scripts.Logic.Weapon.Damages;
using JetBrains.Annotations;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Logic.Weapon
{
    public class ShotSystem : MonoBehaviour, IShot
    {
        [SerializeField]
        float _speed;

        Rigidbody _rigidbody;
        ShotParticle.Factory _shotParticleFactory;
        SimpleDamage.Factory _simpleDamageFactory;

        public Vector3 Direction { get; set; }

        public float Spread { get; set; }

        //Construction from factory
        [Inject]
        public void Construct(IShotPoint shotPoint,
            float spread,
            IDamage damage,
            [NotNull] [Inject(Id = "Self")] Rigidbody selfRigidbody,
            [NotNull] ShotParticle.Factory shotParticleFactory,
            [NotNull] SimpleDamage.Factory simpleDamageFactory)
        {
            //Initialize
            _rigidbody = GetComponent<Rigidbody>();
            _shotParticleFactory = shotParticleFactory;
            _simpleDamageFactory = simpleDamageFactory;
            Spread = spread;
            transform.position = shotPoint.Position;
            
            //Logic
            Direction = Quaternion.AngleAxis(Random.Range(-spread / 2, spread / 2 ), Vector3.up) * shotPoint.Forward;
            
            SubscribeToStreams(damage);
        }

        void Start()
        {
            _rigidbody.AddForce(Direction.normalized * _speed * 10);
        }

        void SubscribeToStreams(IDamage damage)
        {
            var stream = this.OnCollisionEnterAsObservable()
                .Where(collision => collision.gameObject.GetComponent<IShot>() == null);

            stream.Subscribe(Destroy);

            stream.Select(collision => collision.gameObject.GetComponent<IDamageTaker>())
                .Where(damageTaker => damageTaker != null)
                .Subscribe(damageTaker => damageTaker.TakeDamage(damage));
        }

        void Destroy(Collision collision)
        {
            var particle = _shotParticleFactory.Create();
            particle.transform.position = collision.contacts[0].point;
            particle.transform.rotation = Quaternion.LookRotation(collision.contacts[0].normal);
            Destroy(particle.gameObject, 0.5f);
            Destroy(gameObject);
        }

        public class Factory : PlaceholderFactory<IShotPoint, float, IDamage, ShotSystem>
        {

        }

    }
}
