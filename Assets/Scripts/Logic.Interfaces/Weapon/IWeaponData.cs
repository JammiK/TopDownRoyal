using UnityEngine;

namespace Assets.Scripts.Logic.Interfaces.Weapon
{
    public interface IWeaponData
    {
        IShotPoint ShotPoint { get; }
        IWeapon CurrentWeapon { get; set; }

        Transform Transform { get; }
    }
}
