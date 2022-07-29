using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRaycast : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [Header("Cursor Texture")]
    [SerializeField] private Texture2D _mouseMoveTexture;
    [SerializeField] private Texture2D _mouseResizeTexture;
    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, 150f, _layerMask);

        if(hit.collider != null)
        {
            Debug.Log("touché");
            Debug.DrawRay(ray.origin, ray.direction* 150f, Color.red);
            if(hit.collider.CompareTag("Resize"))
            {
                Cursor.SetCursor(_mouseResizeTexture, new Vector2(16f, 16f), CursorMode.Auto );
            }
            else if(hit.collider.CompareTag("Move"))
            {
                Cursor.SetCursor(_mouseMoveTexture, new Vector2(16f, 16f), CursorMode.Auto );
            }
            else
            {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto );
            }
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction* 150f, Color.white);
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto );  
        }
    }
}
