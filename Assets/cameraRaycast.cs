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
            Debug.DrawRay(ray.origin, ray.direction* 150f, Color.red);
            if(hit.collider.CompareTag("Resize"))
            {
                Cursor.SetCursor(_mouseResizeTexture, new Vector2(16f, 16f), CursorMode.Auto );
                if(Input.GetMouseButtonDown(2))
                {
                    _activeEffector = hit.collider.transform.parent;
                }
                if(_activeEffector != null)
                {
                    float radius = Vector2.Distance(_activeEffector.position, hit.point);
                    _activeEffector.GetComponent<CircleShape>().Radius = radius; 


                }
            }
            else if(hit.collider.CompareTag("Move"))
            {
                Cursor.SetCursor(_mouseMoveTexture, new Vector2(16f, 16f), CursorMode.Auto );
                if(Input.GetMouseButtonDown(0))
                {
                    _activeEffector = hit.collider.transform.parent;
                }
                if(_activeEffector != null)
                {
                    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    _activeEffector.transform.position = new Vector3(mousePosition.x, mousePosition.y, _activeEffector.transform.position.z);
                }
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
        //Relâche du click
        if(Input.GetMouseButtonUp(0))
        {
            _activeEffector = null;
        }
    }
    private Transform _activeEffector;

}
