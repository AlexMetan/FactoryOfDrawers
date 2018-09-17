
using UnityEngine;

public class AudioScript : MonoBehaviour {
	public  AudioSource music;
    public GameObject mainMusic;
  public  GameObject [] sounds;
    void Start() {
       if(PlayerPrefs.GetInt("music") == 1)
           mainMusic.SetActive(true);

        if(PlayerPrefs.GetInt("sounds") == 1){

            foreach (GameObject s in sounds) {
                s.SetActive(true);
            }
        }
         if (PlayerPrefs.GetInt("music") == 1)
         {
             music.pitch = Random.Range(0.5f, 1.01f);
            if (!music.isPlaying)
                music.Play();
        }
        else music.Stop() ;
    }

 
}
