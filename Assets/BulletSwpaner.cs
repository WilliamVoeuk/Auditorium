using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSwpaner : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] float _fireColdown;
    [SerializeField] float _radiusFactor;
   
    float lastBullet;
    private void Update() 
    {   
        float rx = Random.Range(-1f, 1f);
        float ry = Random.Range(-1f, 1f);
        Vector3 randomDirection= new Vector3(rx, ry) * _radiusFactor;

        if(Time.time >= _fireColdown + lastBullet)
    {
        lastBullet = Time.time;
        GameObject.Instantiate(_bulletPrefab, transform.position + randomDirection, transform.rotation);
    }
    }
}
