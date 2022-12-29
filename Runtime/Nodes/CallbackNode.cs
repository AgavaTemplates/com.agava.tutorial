using System;
using System.Threading.Tasks;

namespace Agava.Tutorial
{
    public class CallbackNode : ITutorialNode
    {
        private readonly Action _action;

        public CallbackNode(Action action)
        {
            _action = action;
        }

        public TutorialNodeStatus Status { get; private set; }

        public Task AsyncExecute()
        {
            _action?.Invoke();
            Status = TutorialNodeStatus.Success;
            
            return Task.CompletedTask;
        }

        public void Reset()
        {
            Status = TutorialNodeStatus.Idle;
        }
    }
}