using System;
using System.Threading.Tasks;

namespace Agava.Tutorial
{
    public class DelayNode : ITutorialNode
    {
        private readonly float _duration;

        public DelayNode(float duration)
        {
            _duration = duration;
        }

        public TutorialNodeStatus Status { get; private set; }

        public async Task AsyncExecute()
        {
            if (Status == TutorialNodeStatus.Running)
                throw new InvalidOperationException("Node running");

            Status = TutorialNodeStatus.Running;
            
            await Task.Delay(TimeSpan.FromSeconds(_duration));
            
            Status = TutorialNodeStatus.Success;
        }

        public void Reset()
        {
            Status = TutorialNodeStatus.Idle;
        }
    }
}
