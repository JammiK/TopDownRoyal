using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Interfaces.Weapon
{
    public interface IShotPoint
    {
        Vector3 Position { get; }
        Vector3 Forward { get; }
    }
}
