using UnityEngine;
using Zenject;

namespace Assets.Logic.Weapon
{
    public class ShotParticle : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<ShotParticle> { }
    }
}
