using PaintIn3D;
using UnityEngine;

namespace ServiceLocator.GameServices.Painting
{
    public interface IPaint
    {
        void ChangeBrushRadius(float value);
        void ChangeBrushColor(Color color);
    }
}