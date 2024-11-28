namespace Core
{
    public interface IStatemachine
    {
        bool ChangeState<T>() where T : GameState;
        public void Update();
    }
}