using System.Collections;
using UnityEngine;

namespace Agava.Tutorial.Samples
{
    internal class UpDownAnimation : MonoBehaviour
    {
        [SerializeField, Min(0.001f)] private float _duration;
        [SerializeField, Min(0.001f)] private float _offsetY;
        
        private Vector3 _downPosition;
        private Coroutine _animatingCoroutine;

        private void OnDisable()
        {
            if (_animatingCoroutine != null)
                StopCoroutine(_animatingCoroutine);
        }

        internal void Play(Vector3 downPosition)
        {
            _downPosition = downPosition;
            _animatingCoroutine = StartCoroutine(Animating());
        }

        private IEnumerator Animating()
        {
            transform.position = _downPosition;

            while (true)
            {
                yield return StartCoroutine(MoveTo(_downPosition + Vector3.up * _offsetY));
                yield return StartCoroutine(MoveTo(_downPosition));
            }
        }

        private IEnumerator MoveTo(Vector3 endPosition)
        {
            Vector3 startPosition = transform.position;
            float elapsedTime = 0f;

            while (elapsedTime < _duration)
            {
                transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / _duration);
                elapsedTime += Time.deltaTime;

                yield return null;
            }

            transform.position = endPosition;
        }
    }
}