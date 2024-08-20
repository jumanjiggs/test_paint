using Painting;
using UnityEngine;

namespace ServiceLocator.GameServices.Painting
{
    public class Paint : MonoBehaviour, IPaint
    {
        [SerializeField] private Brush brush;
        public void ChangeBrushRadius(float value)
        {
            brush.ChangeRadius(value);
        }
        public void ChangeBrushColor(Color color)
        {
            brush.ChangeColor(color);
        }
    }
}