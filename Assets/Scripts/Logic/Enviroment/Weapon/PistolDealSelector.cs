using Assets.Scripts.Logic.Interfaces.Enviroment.Weapon;
using Assets.Scripts.Logic.Interfaces.Weapon;
using Assets.Scripts.Logic.Weapon;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Logic.Enviroment.Weapon
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