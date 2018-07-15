using UnityEngine;
using Zenject;

namespace Assets.Logic.Weapon
{
    class ShotParticle : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<ShotParticle> { }
    }
}
