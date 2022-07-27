using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSwpaner : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab;

    private void Update() 
    {
        GameObject.Instantiate(_bulletPrefab, transform.position, transform.rotation);
    }
}
