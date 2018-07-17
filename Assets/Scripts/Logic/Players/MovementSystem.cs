using Assets.Scripts.Logic.Interfaces;
using UniRx;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Logic.Players
{
    class MovementSystem : MonoBehaviour
    {
        [Inject]
        readonly IMouseScreenClickObservable _inputSystem;

        [Inject]
        Rigidbody _rigidBody;

        float _moveSpeed = 0.1f;

        void Start()
        {
            _inputSystem.OnMouseScreenClick()
                .Subscribe(Move);
        }

        void Move(Vector2 direction)
        {
            transform.Translate(new Vector3(direction.x,0,direction.y) * _moveSpeed);
        }

    }
}
