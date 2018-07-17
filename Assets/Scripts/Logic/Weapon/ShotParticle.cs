using UnityEngine;
using Zenject;

namespace Assets.Scripts.Logic.Weapon
{
    public class ShotParticle : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<ShotParticle> { }
    }
}
