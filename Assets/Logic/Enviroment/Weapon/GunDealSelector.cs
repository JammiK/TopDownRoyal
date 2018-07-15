using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Interfaces.Enviroment.Weapon;
using Assets.Interfaces.Weapon;
using Assets.Logic.Weapon;
using UnityEngine;
using Zenject;

namespace Assets.Logic.Enviroment.Weapon
{
    class GunDealSelector : MonoBehaviour, IWeaponDealSelector
    {
        [Inject]
        private Gun.Factory _gunFactory;

        public IWeapon GetWeapon()
        {
            return _gunFactory.Create();
        }
    }
}
