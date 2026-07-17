using UnityEngine;

public class ButtonExpand : MonoBehaviour
{
    [SerializeField] private GameObject content;

    private bool expanded = false;

    private RectTransform arrow;

    private void Awake()
    {
        arrow = GetComponent<RectTransform>();
    }

    public void Toggle()
    {
        expanded = !expanded;
        content.SetActive(expanded);
        arrow.localRotation = Quaternion.Euler(
            0,
            0,
            expanded ? 0f : -90f);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        content.SetActive(expanded);
        arrow.localRotation = Quaternion.Euler(0, 0,
            expanded ? 0f : -90f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
