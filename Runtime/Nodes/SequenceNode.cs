using System;
using System.Threading.Tasks;

namespace Agava.Tutorial
{
    public class SequenceNode : ITutorialNode
    {
        private readonly ITutorialNode[] _tutorialNodes;
        private readonly ITutorialCondition _skipCondition;

        public SequenceNode(ITutorialCondition skipCondition = null, params ITutorialNode[] tutorialNodes) : this(tutorialNodes, skipCondition) { }
        public SequenceNode(params ITutorialNode[] tutorialNodes) : this(tutorialNodes, null) { }
        
        public SequenceNode(ITutorialNode[] tutorialNodes, ITutorialCondition skipCondition = null)
        {
            _tutorialNodes = tutorialNodes;
            _skipCondition = skipCondition;
        }

        public TutorialNodeStatus Status { get; private set; }

        public async Task AsyncExecute()
        {
            if (Status == TutorialNodeStatus.Running)
                throw new InvalidOperationException("Node running");

            Status = TutorialNodeStatus.Running;

            if (_skipCondition is { Completed: true })
            {
                Status = TutorialNodeStatus.Success;
                return;
            }

            foreach (var node in _tutorialNodes)
            {
                await node.AsyncExecute();
            }

            Status = TutorialNodeStatus.Success;
        }

        public void Reset()
        {
            foreach (var node in _tutorialNodes)
                node.Reset();

            Status = TutorialNodeStatus.Idle;
        }
    }
}
