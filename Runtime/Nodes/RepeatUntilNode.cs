using System.Threading.Tasks;

namespace Agava.Tutorial
{
    public class RepeatUntilNode : ITutorialNode
    {
        private readonly ITutorialNode _tutorialNode;
        private readonly ITutorialCondition _untilCondition;

        public RepeatUntilNode(ITutorialCondition untilCondition, ITutorialNode tutorialNode)
        {
            _tutorialNode = tutorialNode;
            _untilCondition = untilCondition;
        }

        public TutorialNodeStatus Status { get; private set; }

        public async Task AsyncExecute()
        {
            while (TryCompleteNode() == false)
            {
                _tutorialNode.Reset();
                
                await _tutorialNode.AsyncExecute();
            }
        }

        public void Reset()
        {
            Status = TutorialNodeStatus.Idle;
        }

        private bool TryCompleteNode()
        {
            Status = _untilCondition.Completed ? TutorialNodeStatus.Success : Status;
            return Status == TutorialNodeStatus.Success;
        }
    }
}