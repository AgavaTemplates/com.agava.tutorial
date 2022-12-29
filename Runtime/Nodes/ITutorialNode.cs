using System.Threading.Tasks;

namespace Agava.Tutorial
{
    public interface ITutorialNode
    {
        TutorialNodeStatus Status { get; }

        Task AsyncExecute();
        void Reset();
    }
}
