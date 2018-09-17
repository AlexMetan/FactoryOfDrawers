using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class TimerScript : MonoBehaviour {
	public Text timerTime;
    public float timerFloat;
	public int gameType;
	public GameObject timerObj;
    public GameOverScript over;
    public Color t1, t2;


	bool istime;
	float i;
	bool noTime=false;
   
    Text txtColor;
	// Use this for initialization
	void Start () {
        noTime = false;
		gameType = PlayerPrefs.GetInt ("GameMode");
		if (gameType == 1) {
			StartCoroutine (SpawnTimer ());
			
            txtColor = timerTime.GetComponent<Text>();
          
		}
	}
	 void Repeat(){
		StartCoroutine (SpawnTimer ());
	}
	 IEnumerator SpawnTimer(){
		
			yield return new WaitForSeconds (Random.Range (5, 20));
			GameObject t = Instantiate (timerObj, new Vector3 (Random.Range (-6, 7), 9, 0), Quaternion.identity) as GameObject;
			Destroy (t, 5);
			Repeat ();

	}
	// Update is called once per frame
    void Update()
    {
        if (gameType == 1)
        {
           
            if (gameType == 1)
            {
                timerTime.text = (timerFloat.ToString("f0") + " s");
                CalcTime();

            }

            if (timerFloat > 10)
            {
                txtColor.color = t1;
                i = 0;
            }
            if (timerFloat <= 10)
            {
                txtColor.color = t2;

                i += Time.deltaTime;
                if (i > 1f)
                {
                    i = 0;

                }
                if (i >= 0.6f)
                    timerTime.text = (timerFloat.ToString("f0") + " s");

                else if (i <= 0.3f)
                    timerTime.text = "";

                if (timerFloat < 0 && !noTime)
                {
                    noTime = true;
                    over.NomoreTime();
                }

            }
            if (timerFloat >= 59)
            {
                timerFloat = 59;
              
            }
        }
    }


	void CalcTime(){
		
		if (timerFloat > 0) {
			istime = true;
		} else if (timerFloat < 0) {
			istime = false;
			

		}
		if (istime) {
			istime = true;
			timerFloat -= Time.deltaTime;
			
		} else if (!istime&&noTime) {
			istime = true;
			
       

		}
	}


}
