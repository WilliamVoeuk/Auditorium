using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSwpaner : MonoBehaviour
{
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] float _fireColdown;
   
    float lastBullet;
    private void Update() 
    {   
        float rx = Random.Range(-0.25f, 0.25f);
        float ry = Random.Range(-0.25f, 0.25f);
        Vector3 randomDirection= new Vector3(rx, ry);

        if(Time.time >= _fireColdown + lastBullet)
    {
        lastBullet = Time.time;
        GameObject.Instantiate(_bulletPrefab, transform.position + randomDirection, transform.rotation);
    }
    }
}
