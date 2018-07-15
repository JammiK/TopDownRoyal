using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Interfaces.Weapon
{
    interface IWeaponData
    {
        IShotPoint ShotPoint { get; }
        IWeapon CurrentWeapon { get; set; }

        Transform Transform { get; }
    }
}
