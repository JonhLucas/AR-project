using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class MaterialColorTester : MonoBehaviour
{
    [Header("Settings")]

    [Tooltip("Quanto a cor será aproximada do cinza.")]
    [Range(0f, 1f)]
    [SerializeField] private float fadeAmount = 0.5f;

    private Renderer objectRenderer;
    private Material materialInstance;

    private void Awake()
    {
        objectRenderer = GetComponent<Renderer>();

        materialInstance = Application.isPlaying
            ? objectRenderer.material
            : objectRenderer.sharedMaterial;
    }

    /// <summary>
    /// Restaura a aparência original da textura.
    /// </summary>
    [ContextMenu("Restore")]
    public void Restore()
    {
        materialInstance.SetColor("_BaseColor", Color.white);
    }

    /// <summary>
    /// Escurece o objeto.
    /// </summary>
    [ContextMenu("Darken")]
    public void Darken()
    {
        materialInstance.SetColor(
            "_BaseColor",
            new Color(0.5f, 0.5f, 0.5f, 1f));
    }

    /// <summary>
    /// Clareia o objeto.
    /// </summary>
    [ContextMenu("Brighten")]
    public void Brighten()
    {
        materialInstance.SetColor(
            "_BaseColor",
            new Color(1.5f, 1.5f, 1.5f, 1f));
    }

    /// <summary>
    /// Aplica uma tonalidade cinza ao material.
    /// </summary>
    [ContextMenu("Gray")]
    public void Gray()
    {
        materialInstance.SetColor("_BaseColor", Color.gray);
    }

    /// <summary>
    /// Simula visualmente um objeto desabilitado.
    /// </summary>
    [ContextMenu("Disabled")]
    public void Disabled()
    {
        materialInstance.SetColor(
            "_BaseColor",
            new Color(0.6f, 0.6f, 0.6f, 1f));
    }

    /// <summary>
    /// Aproxima gradualmente a cor do cinza.
    /// </summary>
    [ContextMenu("Apply Fade")]
    public void ApplyFade()
    {
        Color fadedColor = Color.Lerp(
            Color.white,
            Color.gray,
            fadeAmount);

        materialInstance.SetColor(
            "_BaseColor",
            fadedColor);
    }

    /// <summary>
    /// Atualiza o nível de esmaecimento.
    /// </summary>
    public void SetFade(float value)
    {
        fadeAmount = Mathf.Clamp01(value);
        ApplyFade();
    }
}