using UnityEngine;

namespace Assets.Interfaces.Weapon
{
    interface IShot
    {
        Vector3 Direction { get; set; }
        float Spread { get; set; }
    }
}
