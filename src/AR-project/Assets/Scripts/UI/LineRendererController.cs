using UnityEngine;

[ExecuteInEditMode]
public class LineRendererController : MonoBehaviour
{
    public Transform pontoA;
    public Transform pontoB;
    private LineRenderer lineRenderer;
    
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        lineRenderer.positionCount = 2;

        lineRenderer.SetPosition(0, pontoA.position);
        lineRenderer.SetPosition(1, pontoB.position);
    }

    public void setVisible() => gameObject.SetActive(true);

    public void setHide() => gameObject.SetActive(false);
}
