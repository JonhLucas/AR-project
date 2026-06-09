using UnityEngine;
using UnityEngine.UI;

public class SliderRotationController : MonoBehaviour
{
    [Header("References")]

    [Tooltip("Slider responsavel por controlar a rotação do objeto.")]
    [SerializeField] private Slider rotationSlider;

    private Quaternion initialRotation;

    // [Tooltip("Objeto que terá sua rotação alterada no eixo Y.")]
    // [SerializeField] private Transform targetObject;

    private void Start(){
        if (rotationSlider == null || transform == null){
            Debug.LogError("Uma das referecias não foi atribuida.");
            enabled = false;
            return;
        }

        initialRotation = transform.localRotation;

        rotationSlider.onValueChanged.AddListener(UpdateRotation);
        UpdateRotation(rotationSlider.value);
    }

    private void UpdateRotation(float angle_y){
        Vector3 rotation = transform.localEulerAngles;
        rotation.y = angle_y;
        transform.localEulerAngles = rotation;
    }

    public void ResetRotation(){
        transform.localRotation = initialRotation;

        rotationSlider.SetValueWithoutNotify(initialRotation.eulerAngles.y);
    }

    private void OnDestroy(){
        if (rotationSlider != null){
            rotationSlider.onValueChanged.RemoveListener(UpdateRotation);
        }
    }
}
