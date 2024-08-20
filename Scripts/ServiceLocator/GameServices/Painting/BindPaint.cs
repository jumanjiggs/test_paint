using UnityEngine;
using Zenject;

namespace ServiceLocator.GameServices.Painting
{
    public class BindPaint: MonoInstaller
    {
        [SerializeField] private Paint paint;
        public override void InstallBindings()
        {
            Container.Bind<IPaint>().FromInstance(paint).AsSingle().NonLazy();
        }
    }
}