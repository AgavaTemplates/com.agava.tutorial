using System;
using UnityEngine;
using UnityEngine.UI;

namespace Agava.Tutorial.Samples
{
    [RequireComponent(typeof(Button))]
    internal class TutorialButton : MonoBehaviour
    {
        private readonly DefaultTutorialCondition _pressCondition = new();
        private Button _button;
        
        internal ITutorialCondition PressCondition => _pressCondition;
        
        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        public void Release()
        {
            if (_pressCondition.Completed == false)
                throw new InvalidOperationException();

            _pressCondition.Reset();
        }

        private void OnClick()
        {
            _pressCondition.Complete();
        }
    }
}