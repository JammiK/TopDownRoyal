using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Interfaces.Players.Stats
{
    interface IHealSystem
    {
        void Heal(IHaveHealth health, int value);
    }
}
