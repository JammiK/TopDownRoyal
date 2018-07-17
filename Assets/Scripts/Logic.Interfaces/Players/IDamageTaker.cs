using Assets.Scripts.Logic.Interfaces.Weapon;

namespace Assets.Scripts.Logic.Interfaces.Players
{
    public interface IDamageTaker
    {
        void TakeDamage(IDamage damage);
    }
}
