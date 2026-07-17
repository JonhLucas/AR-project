using UnityEngine;

[ExecuteInEditMode]
public class Billboard : MonoBehaviour
{
    public Transform mainCameraTransform;

    void Start()
    {
        /*if (transform.parent != null)
        {
            string nomeDoPai = transform.parent.name;
            Debug.Log($"{gameObject.name} tem um pai chamado: {nomeDoPai}");
            //Debug.Log("Posição inicial" + transform.position);
            //transform.position = Vector3.zero;
            //Debug.Log("Posição final" + transform.position);
        }
        else
        {
            Debug.Log($"{gameObject.name} não tem nenhum pai (está na raiz da cena).");
            Debug.Log("Posição inicial" + transform.position);
            //transform.position = Vector3.zero;
            Debug.Log("Posição final" + transform.localPosition);
        }*/

        
        
        if (Camera.main != null){
            mainCameraTransform = Camera.main.transform;
            Debug.Log("Camera encontrada");
        }
        else{
            Debug.LogError("Camera não encontrada");
        }


        
    }

    void LateUpdate()
    {
        if (mainCameraTransform != null)
        {
            // Faz o objeto olhar para a câmera
            transform.LookAt(transform.position + mainCameraTransform.rotation * Vector3.forward,
                             mainCameraTransform.rotation * Vector3.up);
        }
    }
}