using ServiceLocator.GameServices.Painting;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ColorPickerS
{
    public class ColorPicker: MonoBehaviour
    {
        [Header("SLIDERS")]
        [SerializeField] private Slider redSlider;
        [SerializeField] private Slider greenSlider;
        [SerializeField] private Slider blueSlider;
        
        [Header("PREVIEW")]
        public Image colorPreview;

        [Header("VALUES COLOR")]
        public TextMeshProUGUI redValueText;
        public TextMeshProUGUI greenValueText;
        public TextMeshProUGUI blueValueText;
        
        private IPaint _paint;

        [Inject]
        private void Construct(IPaint paint)
        {
            _paint = paint;
        }
        private void Start()
        {
            redSlider.onValueChanged.AddListener(UpdateColor);
            greenSlider.onValueChanged.AddListener(UpdateColor);
            blueSlider.onValueChanged.AddListener(UpdateColor);
            
            UpdateColor(0);
        }

        private void OnDestroy()
        {
            redSlider.onValueChanged.RemoveListener(UpdateColor);
            greenSlider.onValueChanged.RemoveListener(UpdateColor);
            blueSlider.onValueChanged.RemoveListener(UpdateColor);
        }

        private void UpdateColor(float value)
        {
            float red = redSlider.value;
            float green = greenSlider.value;
            float blue = blueSlider.value;
            
            UpdateTextValues(red, green, blue);
            
            var newColor = CreateNewColor(red, green, blue);
            
            SetupNewColor(newColor);
            
            _paint.ChangeBrushColor(newColor);
        }

        private void UpdateTextValues(float red, float green, float blue)
        {
            redValueText.text = Mathf.RoundToInt(red * 255).ToString();
            greenValueText.text = Mathf.RoundToInt(green * 255).ToString();
            blueValueText.text = Mathf.RoundToInt(blue * 255).ToString();
        }

        private static Color CreateNewColor(float red, float green, float blue)
        {
            Color newColor = new Color(red, green, blue);
            return newColor;
        }

        private void SetupNewColor(Color newColor)
        {
            colorPreview.color = newColor;
        }
    }
}