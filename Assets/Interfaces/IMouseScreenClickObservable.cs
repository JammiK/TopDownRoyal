using System;
using UnityEngine;

namespace Assets.Interfaces
{
    interface IMouseScreenClickObservable
    {
        IObservable<Vector2> OnMouseScreenClick();
        IObservable<Vector2> OnMouseTwitch();
        IObservable<Vector2> OnMouseTwitchUp();
    }
}
