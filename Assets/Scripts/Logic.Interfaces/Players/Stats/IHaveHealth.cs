using UniRx;

namespace Assets.Scripts.Logic.Interfaces.Players.Stats
{
    public interface IHaveHealth
    {
        IntReactiveProperty Health { get; }
        IntReactiveProperty MaxHealth { get; }
    }
}
