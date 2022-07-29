using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRaycast : MonoBehaviour
{
    [SerializeField] 
    private LayerMask _layerMask;

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction* 150f, Color.white);
        
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, 150f, _layerMask);

        if(hit.collider != null)
        {
            Debug.Log("touché");
            Debug.DrawRay(ray.origin, ray.direction* 150f, Color.red);

        }
    }
}
