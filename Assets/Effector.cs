using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effector : MonoBehaviour
{
    [SerializeField] private Texture2D _mouseMoveTexture;
    [SerializeField] private Texture2D _mouseResizeTexture;
    float effectorRadius = 1;
    private void OnMouseDrag() 
    {
        Cursor.SetCursor(_mouseMoveTexture, new Vector2(16f, 16f), CursorMode.Auto );
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);

        if (Input.GetAxis("Mouse ScrollWheel") > 0f & effectorRadius < 3) 
        {
            Cursor.SetCursor(_mouseResizeTexture, new Vector2(16f, 16f), CursorMode.Auto );
            // Debug.Log("Sroll up");
            effectorRadius += 0.1f;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f & effectorRadius > 1 )
        {
            Cursor.SetCursor(_mouseResizeTexture, new Vector2(16f, 16f), CursorMode.Auto );
            // Debug.Log("Scroll down");
            effectorRadius -= 0.1f;
 
        }
        transform.GetComponent<CircleShape>().Radius = effectorRadius;
        Debug.Log(effectorRadius);
    }
    
}

