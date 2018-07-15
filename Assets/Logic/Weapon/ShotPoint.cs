using Assets.Interfaces.Weapon;
using UnityEngine;

namespace Assets.Logic.Weapon
{
    class ShotPoint : MonoBehaviour, IShotPoint
    {
        public Vector3 Position => transform.position;

        public Vector3 Forward => transform.forward;
    }
}
