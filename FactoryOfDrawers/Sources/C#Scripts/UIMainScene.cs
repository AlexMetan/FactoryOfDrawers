using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMainScene : MonoBehaviour {
	
	public Button playPause;
	public Sprite playS, pauseS;
    public AudioSource mainMusic;

   
	bool isPaused;
    float posY;


	void Start(){
        
		isPaused = true;
        mainMusic.pitch = Random.Range(0.6f, 1f);
	}
            
	public void Restart(){
		SceneManager.LoadScene (2);

	}

	public void Pause(){

		if (isPaused) {
			Time.timeScale = 0;
			isPaused = false;
			playPause.GetComponent<Image> ().sprite = playS;
		}

		else if (!isPaused) {Time.timeScale = 1;
			isPaused = true;
			playPause.GetComponent<Image> ().sprite = pauseS;
		}

	}

	public void Gohome(){
		SceneManager.LoadScene (0);
	}
    
    
}
