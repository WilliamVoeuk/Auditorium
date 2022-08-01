using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effector : MonoBehaviour
{
    [SerializeField] private Texture2D _mouseMoveTexture;
    // [SerializeField] private Texture2D _mouseResizeTexture;
    float effectorRadius = 1;
    private void OnMouseDrag() 
    {
        Cursor.SetCursor(_mouseMoveTexture, new Vector2(16f, 16f), CursorMode.Auto );
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);

        if (Input.GetAxis("Mouse ScrollWheel") > 0f & effectorRadius < 3) 
        {

            effectorRadius += 0.1f;
            transform.GetComponent<AreaEffector2D>().forceMagnitude += 50;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f & effectorRadius > 1 )
        {

            effectorRadius -= 0.1f;
             transform.GetComponent<AreaEffector2D>().forceMagnitude -= 50;

        }
        transform.GetComponent<CircleShape>().Radius = effectorRadius;
    }
    
}

