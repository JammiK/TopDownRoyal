using UniRx;
using UnityEngine;

namespace Assets.Scripts.Logic.Enviroment
{
    class RotatorSystem : MonoBehaviour
    {
        [SerializeField]
        float _rotationSpeed = 5f;

        void Start()
        {
            Observable.EveryUpdate()
                .Subscribe(_ => transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime));
        }

    }
}
