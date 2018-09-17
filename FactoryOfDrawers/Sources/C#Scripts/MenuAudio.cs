using UnityEngine;

public class MenuAudio : MonoBehaviour {
  
	AudioSource music;
    void Start() {
        music = GetComponent<AudioSource>();
        music.enabled = false;
       
    }
	
	// Update is called once per frame
	void Update () {
		 if (PlayerPrefs.GetInt("music") == 1)
         {
             music.enabled = true;
             
            if (!music.isPlaying)
                music.Play();
        }
        else music.Stop() ;
    }
	}

