using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject[] MusicBoxes;
    int count = 0;
    bool won = false;
    void Start() 
    {
        MusicBoxes = GameObject.FindGameObjectsWithTag("MusicBox"); 
        // OnMusicBoxes.Length = MusicBoxes.Length;        
    }
    void Update() 
    {
        // check
        won = true;
        foreach(GameObject MusicBox in MusicBoxes)   
        { 
            if(MusicBox.GetComponent<AudioSource>().volume < 1) 
            {
                won = false;
            }
        }
        
        // valider
        if (won == true) 
        {
            count += 1;  
        }
        else
        {
            count = 0;
        }
        if(count == 1000)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }
    }
}
