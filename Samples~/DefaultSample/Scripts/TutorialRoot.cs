using UnityEngine;

namespace Agava.Tutorial.Samples
{
    public class TutorialRoot : MonoBehaviour
    {
        private const string SaveKey = "TutorialSaveKey";

        [SerializeField] private TutorialArrow _arrow;
        [SerializeField] private TutorialButton _firstButton;
        [SerializeField] private TutorialButton _secondButton;

        internal bool IsCompleted => PlayerPrefs.HasKey(SaveKey);

        private void Start()
        {
            _arrow.Disable();
            
            if (IsCompleted)
                return;
            
            ITutorialNode sequenceNode = new SequenceNode
            (
                new CallbackNode(() => _secondButton.gameObject.SetActive(false)),
                new CallbackNode(() => _arrow.Render(_firstButton.transform.position)),
                new WaitConditionNode(_firstButton.PressCondition),

                new CallbackNode(() => _secondButton.gameObject.SetActive(true)),
                new CallbackNode(() => _arrow.Render(_secondButton.transform.position)),
                new WaitConditionNode(_secondButton.PressCondition),

                new CallbackNode(() => _arrow.Disable()),

                new CallbackNode(() => PlayerPrefs.SetInt(SaveKey, 1))
            );

            sequenceNode.AsyncExecute();
        }
    }
}
