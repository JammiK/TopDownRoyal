using System.Collections;
using System.Collections.Generic;
using Assets.Interfaces.Enviroment.Weapon;
using Assets.Interfaces.Weapon;
using Assets.Logic.Weapon;
using UnityEngine;
using Zenject;

namespace Assets.Logic.Enviroment.Weapon
{
    public class PistolDealSelector : MonoBehaviour, IWeaponDealSelector
    {
        [Inject] private Pistol.Factory _pistolFactory;

        public IWeapon GetWeapon()
        {
            return _pistolFactory.Create();
        }
    }
}