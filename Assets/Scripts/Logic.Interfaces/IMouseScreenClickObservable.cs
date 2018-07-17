using System;
using UnityEngine;

namespace Assets.Scripts.Logic.Interfaces
{
    public interface IMouseScreenClickObservable
    {
        IObservable<Vector2> OnMouseScreenClick();
        IObservable<Vector2> OnMouseTwitch();
        IObservable<Vector2> OnMouseTwitchUp();
    }
}
