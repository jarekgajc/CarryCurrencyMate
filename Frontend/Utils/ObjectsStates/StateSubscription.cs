namespace Frontend.Utils.ObjectsStates
{
    public class StateSubscription<T>
    {
        public event Action? OnUpdate;

        public void InvokeUpdate()
        {
            OnUpdate?.Invoke();
        }
    }
}
