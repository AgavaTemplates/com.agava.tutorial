namespace Agava.Tutorial
{
    public class ConstTutorialCondition : ITutorialCondition
    {
        public ConstTutorialCondition(bool completed)
        {
            Completed = completed;
        }
        
        public bool Completed { get;}
    }
}