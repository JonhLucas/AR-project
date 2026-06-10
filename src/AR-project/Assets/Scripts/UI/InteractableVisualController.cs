using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Renderer))]
public class InteractableVisualController : MonoBehaviour
{
    [Header("References")]

    [Tooltip("Toggle que controla o estado visual do objeto.")]
    [SerializeField] private Toggle stateToggle;

    [Header("Disabled Appearance")]

    [SerializeField]
    private Color disabledColor = new(0.6f, 0.6f, 0.6f, 1f);

    [SerializeField]
    [Range(0f, 1f)]
    private float disabledSmoothness = 0.1f;

    private Material materialInstance;

    private Color originalColor;
    private float originalSmoothness;

    private void Awake()
    {
        materialInstance = GetComponent<Renderer>().material;

        originalColor = materialInstance.GetColor("_BaseColor");
        originalSmoothness = materialInstance.GetFloat("_Smoothness");
    }

    private void Start()
    {
        if (stateToggle == null)
        {
            Debug.LogWarning("State Toggle não foi atribuído.");
            return;
        }

        UpdateVisualState(stateToggle.isOn);

        stateToggle.onValueChanged.AddListener(UpdateVisualState);
    }

    private void OnDestroy()
    {
        if (stateToggle != null)
        {
            stateToggle.onValueChanged.RemoveListener(UpdateVisualState);
        }
    }

    
    private void UpdateVisualState(bool isEnabled)
    {
        if (isEnabled)
        {
            RestoreVisual();
        }
        else
        {
            DisableVisual();
        }
    }

    
    private void DisableVisual()
    {
        materialInstance.SetColor("_BaseColor", disabledColor);
        materialInstance.SetFloat("_Smoothness", disabledSmoothness);
    }

    
    private void RestoreVisual()
    {
        materialInstance.SetColor("_BaseColor", originalColor);
        materialInstance.SetFloat("_Smoothness", originalSmoothness);
    }
}