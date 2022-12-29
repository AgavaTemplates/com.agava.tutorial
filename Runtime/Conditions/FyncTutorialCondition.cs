using System;

namespace Agava.Tutorial
{
    public class FyncTutorialCondition : ITutorialCondition
    {
        private readonly Func<bool> _condition;

        public FyncTutorialCondition(Func<bool> condition)
        {
            _condition = condition;
        }

        public bool Completed => _condition();
    }
}