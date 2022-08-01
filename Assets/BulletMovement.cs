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
     void Awake() {
        GameObject.Destroy(gameObject, _lifeTime);    
    }
}
