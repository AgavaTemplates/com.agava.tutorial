using System.Threading.Tasks;

namespace Agava.Tutorial
{
    public class WaitConditionNode : ITutorialNode
    {
        private readonly ITutorialCondition _condition;

        public WaitConditionNode(ITutorialCondition condition)
        {
            _condition = condition;
        }

        public TutorialNodeStatus Status { get; private set; }

        public async Task AsyncExecute()
        {
            Status = TutorialNodeStatus.Running;
            
            while (_condition.Completed == false)
                await Task.Yield();
            
            Status = TutorialNodeStatus.Success;
        }

        public void Reset()
        {
            Status = TutorialNodeStatus.Idle;
        }
    }
}
