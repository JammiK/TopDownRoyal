using System;
using Assets.Scripts.Logic.Interfaces;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Logic.Players
{
    public class InputSystem : IMouseScreenClickObservable
    {
        readonly Vector2 _centerPosition = new Vector2(Screen.width / 8, Screen.height / 8);
        readonly float _range = (float)Screen.height / 3f;

        public IObservable<Vector2> OnMouseScreenClick()
        {
            var streamDown = Observable.EveryUpdate()
                   .Where(_ => Input.GetMouseButtonDown(0))
                   .Select(_ => (Vector2)Input.mousePosition);

            var streamClicked = Observable.EveryUpdate()
               .Where(_ => Input.GetMouseButton(0))
               .Select(_ => (Vector2)Input.mousePosition);

            return Observable.CombineLatest(streamDown, streamClicked)
                .Where(positions => Vector2.Distance(positions[0], _centerPosition) < _range)
                .Select(_ => ((Vector2)Input.mousePosition - _centerPosition).normalized);
        }

        public IObservable<Vector2> OnMouseTwitchUp()
        {
            var streamDown = Observable.EveryUpdate()
                .Where(_ => Input.GetMouseButtonDown(0))
                .Where(_ => Vector2.Distance(Input.mousePosition, _centerPosition) > _range)
                .Select(_ => (Vector2)Input.mousePosition);
            

            var streamUp = Observable.EveryUpdate()
                .Where(_ => Input.GetMouseButtonUp(0))
                .Where(_ => Vector2.Distance(Input.mousePosition, _centerPosition) > _range)
                .Select(_ => (Vector2)Input.mousePosition);

            //TODO: Fix this Input collision
            return streamDown.Zip(streamUp, Tuple.Create)
                .Where(tuplePosition => Vector2.Distance(tuplePosition.Item1, tuplePosition.Item2) > 50)
                .Select(tuplePosition => (Vector2)(tuplePosition.Item2 - tuplePosition.Item1));
        }

        public IObservable<Vector2> OnMouseTwitch()
        {
            var streamDown = Observable.EveryUpdate()
                .Where(_ => Input.GetMouseButtonDown(0))
                .Where(_ => Vector2.Distance(Input.mousePosition, _centerPosition) > _range)
                .Select(_ => (Vector2)Input.mousePosition);

            var streamUp = Observable.EveryUpdate()
                .Where(_ => Input.GetMouseButton(0))
                .Select(_ => (Vector2)Input.mousePosition);

            return Observable.CombineLatest(streamDown, streamUp)
                .Where(positions => Vector2.Distance(positions[0], positions[1]) > 50)
                .Select(positions => (positions[1] - positions[0]).normalized);

        }
    }
}