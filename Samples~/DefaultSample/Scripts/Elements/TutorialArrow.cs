using UnityEngine;

namespace Agava.Tutorial.Samples
{
    internal class TutorialArrow : MonoBehaviour
    {
        [SerializeField] private UpDownAnimation _animation;

        public void Render(Vector3 targetPosition)
        {
            if (gameObject.activeSelf == false)
                gameObject.SetActive(true);
            
            _animation.Play(targetPosition);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}