namespace ServiceLocator.GameServices.StateMachine
{
    public interface IState
    {
        void SaveTexture();
        void LoadTexture();
        void ClearTexture();
    }
}