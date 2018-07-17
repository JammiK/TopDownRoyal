using Assets.Scripts.Logic.Interfaces.Weapon;
using Zenject;

namespace Assets.Scripts.Logic.Weapon.Damages
{
    public class SimpleDamage : IDamage
    {
        public SimpleDamage(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public class Factory : PlaceholderFactory<int, SimpleDamage>
        {

        }
    }
}
