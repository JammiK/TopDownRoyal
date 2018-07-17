using UnityEngine;

namespace Assets.Scripts.Logic.Interfaces.Weapon
{
    public interface IShotPoint
    {
        Vector3 Position { get; }
        Vector3 Forward { get; }
    }
}
