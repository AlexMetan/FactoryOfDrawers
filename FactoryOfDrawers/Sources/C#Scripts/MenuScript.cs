using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {


	[Header("CANVAS")]
	public Canvas play;
	public Canvas difficult;
	public Canvas settings;
	public Canvas scoreBCanv;
	
	public Canvas mainCanv;
	[Header("Other")]
	public Slider vibrS,musicS,soundsS;
	public Sprite onS, offS;
	public int vibrSet;
	public Text scoretx0,scoretx1,scoretx2,scoretx3;
	public int record0,record1,record2,record3;
	public int gameMode;
	public int recordTime;
	public bool music;
	public void Start(){
		Time.timeScale = 1;

		music = true;
		play.enabled = true;
		difficult.enabled = false;
		settings.enabled = false;
		
		scoreBCanv.enabled = false;
		record0 = PlayerPrefs.GetInt ("saverecord0");
		record1 = PlayerPrefs.GetInt ("saverecord1");
		record2 = PlayerPrefs.GetInt ("saverecord2");
		record3 = PlayerPrefs.GetInt ("saverecord3");
	}


	public void Loading(){
		gameMode = 0;
		PlayerPrefs.SetInt ("GameMode", gameMode);
		PlayerPrefs.Save ();

		play.enabled=false;
		difficult.enabled = true;
		settings.enabled = false;
		scoreBCanv.enabled = false;
		
	}

	public void TimeAttackMode(){
		gameMode = 1;
		PlayerPrefs.SetInt ("GameMode", gameMode);
		PlayerPrefs.Save (); 

		PlayerPrefs.SetInt ("difficult",3);
		PlayerPrefs.Save ();

		SceneManager.LoadScene (1);
	}
	public void Menu(){
		play.enabled = true;
		difficult.enabled = false;
		settings.enabled = false;
		scoreBCanv.enabled = false;
		
	}
	

	public void VibrButton(){
		if (vibrS.value == 0) {
			PlayerPrefs.SetInt ("vibrations", 0);
			PlayerPrefs.Save ();

		} else if (vibrS.value == 1) {
			PlayerPrefs.SetInt ("vibrations", 1);
			PlayerPrefs.Save ();

		}

	}

	public void Music(){
		if (musicS.value == 0) {
			PlayerPrefs.SetInt ("music", 0);
			PlayerPrefs.Save ();

		} else if (musicS.value == 1) {
			PlayerPrefs.SetInt ("music", 1);
			PlayerPrefs.Save ();

		}
	}
	public void Sounds(){
		if (soundsS.value == 0) {
			PlayerPrefs.SetInt ("sounds", 0);
			PlayerPrefs.Save ();

		} else if (soundsS.value == 1) {
			PlayerPrefs.SetInt ("sounds", 1);
			PlayerPrefs.Save ();

		}
	}

	public void SettingsButton(){
		soundsS.value = PlayerPrefs.GetInt ("sounds");
		vibrS.value = PlayerPrefs.GetInt ("vibrations");
		musicS.value = PlayerPrefs.GetInt ("music");
		play.enabled =false;
		difficult.enabled = false;
		settings.enabled = true;
		scoreBCanv.enabled = false;
		
	}

	public void ScoreBoard(){
		play.enabled =false;
		difficult.enabled = false;
		settings.enabled = false;
		scoreBCanv.enabled = true;
		
		scoretx0.text = ("Easy: " + record0);
		scoretx1.text = ("Medium: " + record1);
		scoretx2.text = ("Hard: " + record2);
		scoretx3.text = ("Time Attack: " + record3);

	}
  public  void ResetAll() {
        PlayerPrefs.DeleteAll();
    }

 public  void Difficulty(int index) {
      PlayerPrefs.SetInt("difficult", index);
      PlayerPrefs.Save();
      SceneManager.LoadScene(1);
  }
}
