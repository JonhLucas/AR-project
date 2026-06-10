using UnityEngine;
using UnityEngine.UI;


public class SliderScaleController : MonoBehaviour
{
    [Header("References")]

    [Tooltip("Slider responsavel por controlar a escala do objeto.")]
    [SerializeField] private Slider scaleSlider;

    [SerializeField] private float min = 1;
    [SerializeField] private float max = 4;

    private Vector3 initialScale;

    [Header("Test")]
    [SerializeField] private float testScale = 0.5f;
    
    [ContextMenu("Test scale")]
    private void TestScale(){
        Debug.Log($"Scale factor {testScale} - {Vector3.one * testScale}");
        transform.localScale = Vector3.one * testScale;
    }
    

    private void Start(){
        if (scaleSlider == null){
            Debug.LogError("Uma das referecias não foi atribuida.");
            enabled = false;
            return;
        }

        initialScale = transform.localScale;

        scaleSlider.onValueChanged.AddListener(UpdateScale);
        UpdateScale(scaleSlider.value);

    }

    private void UpdateScale(float factor){
        float clamp_factor = Mathf.Clamp(factor, 0, 1);
        float scaleFactor = Mathf.Lerp(min, max, clamp_factor);
        transform.localScale = initialScale * scaleFactor;
    }

    public void ResetScale(){
        transform.localScale = initialScale;

        scaleSlider.SetValueWithoutNotify(0.0f);
    }
}
