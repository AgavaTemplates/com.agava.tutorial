namespace Agava.Tutorial
{
    public class DefaultTutorialCondition : ITutorialCondition
    {
        public bool Completed { get; private set; }

        public void Complete() => Completed = true;
        public void Reset() => Completed = false;
    }
}