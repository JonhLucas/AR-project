using UnityEngine;

public class TooltipOrientationController : MonoBehaviour
{
    public Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    /*
    void Update()
    {
        transform.LookAt(target, Vector3.up);
    }
    */
    
    void LateUpdate()
    {
        if (target != null)
        {
            transform.LookAt(transform.position + target.rotation * Vector3.forward,
                             target.rotation * Vector3.up);
        }
    }
}
