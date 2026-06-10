using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ObjectVisualState : MonoBehaviour
{
    [Header("Disabled Appearance")]

    [Tooltip("Cor aplicada quando o objeto estiver desabilitado.")]
    [SerializeField]
    private Color disabledColor = new(0.6f, 0.6f, 0.6f, 1f);

    [Tooltip("Smoothness aplicada quando o objeto estiver desabilitado.")]
    [Range(0f, 1f)]
    [SerializeField]
    private float disabledSmoothness = 0.1f;

    private Material materialInstance;

    private Color originalColor;
    private float originalSmoothness;

    private void Awake()
    {
        Renderer objectRenderer = GetComponent<Renderer>();

        materialInstance = objectRenderer.material;

        originalColor = materialInstance.GetColor("_BaseColor");
        originalSmoothness = materialInstance.GetFloat("_Smoothness");
    }

    /// <summary>
    /// Aplica o visual de objeto desabilitado.
    /// </summary>
    [ContextMenu("Disable Visual")]
    public void DisableVisual()
    {
        materialInstance.SetColor("_BaseColor", disabledColor);
        materialInstance.SetFloat("_Smoothness", disabledSmoothness);
    }

    /// <summary>
    /// Restaura o visual original do material.
    /// </summary>
    [ContextMenu("Restore Visual")]
    public void RestoreVisual()
    {
        materialInstance.SetColor("_BaseColor", originalColor);
        materialInstance.SetFloat("_Smoothness", originalSmoothness);
    }
}