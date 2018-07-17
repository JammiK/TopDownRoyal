using Assets.Scripts.Logic.Interfaces;
using UniRx;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.Input
{
    class MovementJoystick : MonoBehaviour
    {
        [SerializeField]
        private Transform _joystick;

        [Inject]
        private IMouseScreenClickObservable _inputObservable;

        void Start()
        {
            _inputObservable.OnMouseScreenClick()
                .Subscribe(direction =>  _joystick.localPosition = (Vector3) direction * 100);
        }

    }
}
