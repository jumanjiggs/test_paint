using PaintIn3D;
using UnityEngine;

namespace Painting
{
    public class Brush : MonoBehaviour
    {
        [SerializeField] private CwPaintSphere paintSphere;
        public void ChangeRadius(float value)
        {
            paintSphere.Radius = value;
        }
        public void ChangeColor(Color color)
        {
            paintSphere.Color = color;
        }
    }
}