using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRaycast : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [Header("Cursor Texture")]
    [SerializeField] private Texture2D _mouseMoveTexture;
    [SerializeField] private Texture2D _mouseResizeTexture;
    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, 150f, _layerMask);

        if(hit.collider != null)
        {
            Debug.DrawRay(ray.origin, ray.direction* 150f, Color.red);
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction* 150f, Color.white);
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto );  
        }
    }
    private Transform _activeEffector;

}
