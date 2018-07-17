using UnityEngine;

namespace Assets.Scripts.Logic.Interfaces.Weapon
{
    public interface IShot
    {
        Vector3 Direction { get; set; }
        float Spread { get; set; }
    }
}
