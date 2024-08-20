using UnityEngine;
using Zenject;

namespace ServiceLocator.GameServices.StateMachine
{
    public class BindState: MonoInstaller
    {
        [SerializeField] private State state;

        public override void InstallBindings()
        {
            Container.Bind<IState>().FromInstance(state).AsSingle().NonLazy();
        }
    }
}