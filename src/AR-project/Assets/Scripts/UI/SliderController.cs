using UnityEngine;
using UnityEngine.UI;


public class SliderController : MonoBehaviour
{
    [Header("References")]

    [Tooltip("Toggle responsavel por controlar a edição dos slider.")]
    [SerializeField] private Toggle lockToggle;
    
    [Tooltip("Slider subordinado 1")]
    [SerializeField] private Slider scaleSlider;

    [Tooltip("Slider subordinado 2")]
    [SerializeField] private Slider rotationSlider;

    [Header("Test")]
    [SerializeField] private bool enabledSlider = false;
    
    [ContextMenu("Test")]
    private void TestControlSlides(){
        scaleSlider.interactable = enabledSlider;
        rotationSlider.interactable = enabledSlider;

        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // UpdateSliderState(lockToggle.isOn);
        // lockToggle.onValueChanged.AddListener(UpdateSliderState);
    }

    public void UpdateSliderState(bool isOn){
        scaleSlider.interactable = isOn;
        rotationSlider.interactable = isOn;
    }

    private void OnDestroy(){
        lockToggle.onValueChanged.RemoveListener(UpdateSliderState);
    }
}
