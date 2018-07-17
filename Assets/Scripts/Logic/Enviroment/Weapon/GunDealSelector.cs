using Assets.Scripts.Logic.Interfaces.Enviroment.Weapon;
using Assets.Scripts.Logic.Interfaces.Weapon;
using Assets.Scripts.Logic.Weapon;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Logic.Enviroment.Weapon
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
