namespace Game.Controller
{
    public interface ICommand
    {
        public delegate void CompleteHandler();
        public event CompleteHandler Complete;

        public void Execute();
    }
}
