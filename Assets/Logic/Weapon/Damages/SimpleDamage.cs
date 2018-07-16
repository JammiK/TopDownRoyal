using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Interfaces.Weapon;
using UniRx.Examples;
using Zenject;

namespace Assets.Logic.Weapon.Damages
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
