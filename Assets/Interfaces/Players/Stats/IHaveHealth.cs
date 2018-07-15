using UniRx;

namespace Assets.Interfaces.Players.Stats
{
    interface IHaveHealth
    {
        IntReactiveProperty Health { get; }
        IntReactiveProperty MaxHealth { get; }
    }
}
