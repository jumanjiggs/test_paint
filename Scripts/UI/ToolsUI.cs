using ServiceLocator.GameServices.Painting;
using ServiceLocator.GameServices.StateMachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class ToolsUI : MonoBehaviour
    {
        [Header("BUTTONS")]
        [SerializeField] private Button saveButton;
        [SerializeField] private Button loadButton;
        [SerializeField] private Button clearButton;
        
        [SerializeField] private Slider brushSlider; 

        private IPaint _paint;
        private IState _state;
        
        private const float MIN_VALUE_SLIDER = 0.1f;
        private const float MAX_VALUE_SLIDER = 0.3f;
        

        [Inject]
        private void Construct(IPaint paint, IState state)
        {
            _paint = paint;
            _state = state;
        }
        
        private void Start()
        {
            SetupValueSlider();
            AddListeners();
        }

        private void OnDestroy()
        {
            RemoveListeners();
        }

        private void UpdateBrushSize(float value)
        {
           _paint.ChangeBrushRadius(value);
        }

        private void SetupValueSlider()
        {
            brushSlider.minValue = MIN_VALUE_SLIDER;
            brushSlider.maxValue = MAX_VALUE_SLIDER;
        }

        private void AddListeners()
        {
            saveButton.onClick.AddListener(_state.SaveTexture);
            loadButton.onClick.AddListener(_state.LoadTexture);
            clearButton.onClick.AddListener(_state.ClearTexture);
            
            brushSlider.onValueChanged.AddListener(UpdateBrushSize);
        }

        private void RemoveListeners()
        {
            saveButton.onClick.RemoveListener(_state.SaveTexture);
            loadButton.onClick.RemoveListener(_state.LoadTexture);
            clearButton.onClick.RemoveListener(_state.ClearTexture);
            
            brushSlider.onValueChanged.RemoveListener(UpdateBrushSize);
        }
    }
}