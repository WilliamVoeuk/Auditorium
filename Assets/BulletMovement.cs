using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
   [SerializeField] Rigidbody2D _rb;
   [SerializeField] Vector2 _direction;
   [SerializeField] float _speed;
   [SerializeField] int _lifeTime;
   
    private void Start() {
        _rb.velocity = _direction * _speed;    
    }
    private void Update()
    {
        if(Time.time >= _lifeTime)
        {
            GameObject.Destroy(gameObject);
        }
    }
    
}
