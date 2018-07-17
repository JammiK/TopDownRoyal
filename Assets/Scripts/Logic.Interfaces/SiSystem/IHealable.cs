using Assets.Scripts.Logic.Interfaces.Players.Stats;

namespace Assets.Scripts.Logic.Interfaces.SiSystem
{
    public interface IHealSystem
    {
        void Heal(IHaveHealth health, int value);
    }
}
