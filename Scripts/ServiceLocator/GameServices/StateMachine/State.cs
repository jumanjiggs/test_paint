using PaintIn3D;
using UnityEngine;

namespace ServiceLocator.GameServices.StateMachine
{
    public class State: MonoBehaviour,IState
    {
        [SerializeField] private CwPaintableMeshTexture mesh;
        
        private const string SAVE_KEY = "SaveTexture";
        public void SaveTexture()
        {
           mesh.Save(SAVE_KEY);
        }
        public void LoadTexture()
        {
            mesh.Activate();
            mesh.Load(SAVE_KEY);
        }
        public void ClearTexture()
        {
            mesh.Clear();
            mesh.Save(SAVE_KEY);
        }
    }
}