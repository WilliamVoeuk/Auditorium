using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour
{
   #region SerializeFields

   [SerializeField] float _volumeRaisePerParticle;
   [SerializeField] float _volumeDecayPerSecond;
   [SerializeField] float _volumeDecayDelay;
    
    #endregion

    private float _volume;
    private float _StartDecayTime;
    private AudioSource _audioSource;


    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Time.time >= _StartDecayTime)
        {
            _volume = Mathf.Clamp01(_volume - _volumeDecayPerSecond * Time.deltaTime);
        }
        _audioSource.volume = _volume; 
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        _volume = Mathf.Clamp01(_volume + _volumeRaisePerParticle);

        _StartDecayTime = Time.time + _volumeDecayDelay;
        // _volume = Math.Clamp(_volume + _volumeRaisePerParticle, 0, 1);
        // _volume += _volumeRaisePerParticle;
        // if(_volume > 1)
        // {
        //     _volume = 1;
        // }
    }


}
