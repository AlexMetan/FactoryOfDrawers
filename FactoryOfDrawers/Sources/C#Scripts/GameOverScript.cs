using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class GameOverScript : MonoBehaviour
{
    [Header("Canvas")]
    public Canvas gameOverCanvas;
    public Canvas nomore;
    [Header("All Text")]
    public Text record;
    public Text endScore;
    public Text scorelast;
    public Text timeScore, timeRecord;
    [Header("Other")]
     public AudioSource music;
    public GameObject[] ui;
    public BoxSpawn scoreS;
    static int showads = 0;
    public GameObject loseSound;
   BoxScript bs;

    int vib;
    int difficulty;
    void Start()
    {

        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("2763017");
           
        }
        else Debug.Log("Platform is not supported");
        gameOverCanvas.enabled = false;
        vib = PlayerPrefs.GetInt("vibrations");
        difficulty = PlayerPrefs.GetInt("difficult");
    }


    void Update() { ToManyBoxes(); }
   
    public void GameOver()
    {
        

        Lose();
        switch (difficulty)
        {
            case 0:
                record.text = ("Record: " + scoreS.record0);
                break;
            case 1:
                record.text = ("Record: " + scoreS.record1);
                break;
            case 2:
                record.text = ("Record: " + scoreS.record2);
                break;
            case 3:
                record.text = ("Record: " + scoreS.record3);
                break;
        }
        gameOverCanvas.enabled = true;
        endScore.text = scorelast.text;
    }
    public void NomoreTime()
    {
        

                Lose();
        timeRecord.text = ("Record: " + scoreS.GetComponent<BoxSpawn>().record3);
        nomore.enabled = true;
        timeScore.text = scorelast.text;


    }
    public void Lose()
    {
        showads++;
        if (Advertisement.IsReady()&&showads%2==0)
        {
            Debug.Log("Ready");
            Advertisement.Show("rewardedVideo");
        }
        else Debug.Log("NotReady");
        foreach (GameObject gm in ui) {
            gm.SetActive(false);
        }
        Time.timeScale = 0;
        if (vib == 1) Handheld.Vibrate();
            if (PlayerPrefs.GetInt("sounds") == 1)
                {   music.Stop();
                loseSound.SetActive(true);
                    
                }
    }

    void ToManyBoxes() {
        if (PlayerPrefs.GetInt("LoseTomany") == 1)
        {
            PlayerPrefs.SetInt("LoseTomany",0);
            PlayerPrefs.Save();
            GameOver();
        }
    }

   
}