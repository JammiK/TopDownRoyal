using Assets.Interfaces;
using UniRx;
using UnityEngine;
using Zenject;

namespace Assets.Logic.Players
{
    class RotationSystem : MonoBehaviour
    {
        [Inject]
        readonly IMouseScreenClickObservable _inputSystem;

        [SerializeField]
        Transform _inGameBody;

        void Start()
        {
            _inputSystem.OnMouseTwitch()
                .Subscribe(Rotate);

            _inputSystem.OnMouseScreenClick()
                .Subscribe(Rotate);
        }

        void Rotate(Vector2 direction)
        {
            var direction3 = new Vector3(direction.x, 0, direction.y) * 30;
            var targetPosition = _inGameBody.position + direction3;
            Vector3 newDir = Vector3.RotateTowards(_inGameBody.forward, targetPosition, 3, 0.0f);
            Debug.DrawRay(_inGameBody.position, newDir, Color.red);
            _inGameBody.rotation = Quaternion.LookRotation(newDir);
        }

    }
}
