using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Interfaces.Weapon;

namespace Assets.Interfaces.Enviroment.Weapon
{
    interface IWeaponDealSelector
    {
        IWeapon GetWeapon();
    }
}
