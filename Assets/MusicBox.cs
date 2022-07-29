using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour
{
   #region SerializeFields

   [SerializeField] float _volumeRaisePerParticle;
   [SerializeField] float _volumeDecayPerSecond;
   [SerializeField] float _volumeDecayDelay;
   [SerializeField] SpriteRenderer[] _volumeBars;
   [SerializeField] Color _emptyColor;
   [SerializeField] Color _fullColor;
    
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
        UpdateRenderer();

    }

    void UpdateRenderer() {
        int barsToActivate = Mathf.FloorToInt (_volumeBars.Length * _volume);
        
        for (int i = 0; i< _volumeBars.Length; i++ )
        {
            if( i < barsToActivate )
            {
                _volumeBars[i].color = _fullColor;
            }
            else
            {
                _volumeBars[i].color = _emptyColor;
            }
            

        } 
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        _volume = Mathf.Clamp01(_volume + _volumeRaisePerParticle);

        _StartDecayTime = Time.time + _volumeDecayDelay;

    }


}
