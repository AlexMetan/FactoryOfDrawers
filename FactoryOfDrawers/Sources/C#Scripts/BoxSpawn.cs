using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class BoxSpawn : MonoBehaviour
{
	public GameObject objl;
	public Text scoreTe;
    public ParticleSystem fireWorks;
	public int randomSprite;
	public Sprite []boxSprites;
    public GameObject boxHelper;
    public playerAndBonus bonScript;
    public ParticleSystem ps;
    public AudioSource explode;
    public GameObject[] timerScores;
    public TimerScript timeScript;
	[SerializeField]
	List <GameObject> boxes;
	[SerializeField]
	 List <GameObject> deck;
	 List <int> randomXList;
     public Text newRecordTXT;
	public int record0, record1, record2,record3;
    public Animation newRecordAnim;
    public bool bonus35Active;
   public BoxScript bx;
	 int scoreI ;
     int difficulty;
	
	 bool rowed;
	 int gameMode;
     
	 float timerF;
   	
	
	 int spawnType;
	 int randomX;
     SpriteRenderer boxSprite;
    int randomXlast;
	AudioSource sounds;
	
    float helperPosY;
    bool newRecordPart;
    public int scoreFactor;
	void Start(){
        bx = FindObjectOfType<BoxScript>();
        scoreFactor = 1;
            newRecordPart = true;
            boxSprite = objl.GetComponent<SpriteRenderer>();
		sounds = GetComponent<AudioSource> ();
		randomXList = new List<int> ();
		SetRandomNumbersToList ();
		PlayerPrefs.SetInt ("gameOver", 0);
		PlayerPrefs.Save ();
		gameMode = PlayerPrefs.GetInt ("GameMode");
		if (gameMode == 0) {
			scoreTe.GetComponent<Transform>().localPosition=new Vector2(150,scoreTe.transform.localPosition.y);
            foreach (GameObject t in timerScores)
            {
                t.SetActive(false);
            }
		} else if (gameMode == 1) {
            foreach (GameObject t in timerScores) {
                t.SetActive(true);
            }

		}
		Time.timeScale = 1;
		

		scoreI = 0;
		deck = new List<GameObject>();
		StartCoroutine (SpawnB());
        difficulty = PlayerPrefs.GetInt("difficult");
		StartSpawn ();


	}
    void Update (){



        if (deck.Count > 25) bonus35Active = true;
        else bonus35Active = false;
		scoreTe.text="Score: "+scoreI;


        SwitchDif();
        DeleteNullFromList();
		SpawnB ();
		UpdatePossitions ();
        DestroyBoxes();
        DestroyBonus();
        BonusDestroy35();

	}
    void DeleteNullFromList()
    {
        for (int r = deck.Count - 1; r >= 0; r--)
        {
            if (deck[r] == null)
                deck.RemoveAt(r);
        }
    }
    void DestroyBonus(){
        
       
        
        if (bonScript.bonus2) {
			rowed = true;
		} else if (!bonScript.bonus2) {
			rowed = false;
		}
		
}
    void DestroyBoxes()
    {

        if (boxes.Count == 15 || rowed)
        {
            scoreI += 100*scoreFactor;
            if (difficulty == 3)
                timeScript.timerFloat += 15;
            bonScript.bonus2 = false;
                for (int k = 0; k < boxes.Count; k++)
            {
                boxes[k].SetActive(false);
                Destroy(boxes[k]);
                PartSystepPlay();
            }
        }
    }
    IEnumerator SpawnB(){
		
			
		randomX = Random.Range(0, randomXList.Count);
		randomXlast = randomXList [randomX];
		int x = Random.Range (0, 10);
		if (x>=3)
		randomXList.RemoveAt (randomX);
		if (randomXList.Count < 1)
			SetRandomNumbersToList ();
        boxHelper.transform.localPosition = new Vector3(randomXlast, 8f, -2);
		BoxType ();
        Debug.Log(difficulty);
		switch (difficulty) {
		case 0:
			yield return new WaitForSeconds (2f);
			break;
		case 1:
			yield return new WaitForSeconds (1f);
			break;
		case 2: 
			yield return new WaitForSeconds (0.1f);
			break;
		case 3 : 
			yield return new WaitForSeconds (1f);
			break;

		}

		deck.Add((GameObject) Instantiate(objl, new Vector3(randomXlast, 7, 0),Quaternion.identity,transform));
        
        yield return new WaitForSeconds(1.2f);
        scoreI += 5*scoreFactor;
        if (PlayerPrefs.GetInt("sounds") == 1)
            sounds.Play();
       
		Repeat ();
		
		
	}
	void Repeat(){
		StartCoroutine (SpawnB ());
	}
	void BoxType ()
	{
		randomSprite = Random.Range (0, boxSprites.Length);
        boxSprite.sprite = boxSprites[randomSprite];
	}
    void UpdatePossitions(){ 
		
		boxes = new List<GameObject> ();
		for (int i = 0; i<deck.Count; i++) { 
			for (int j=-7;j<8;j++)
                if ((Mathf.Round(deck[i].transform.localPosition.x) == j) && (Mathf.Round(deck[i].transform.localPosition.y) == 0))
                { 
				boxes.Add (deck [i]);  
				} 
            }
        }
	void  StartSpawn(){
		spawnType =	Random.Range (12, 16);
        for (int i = 0; i < spawnType; i++)
        {   int randomX=Random.Range(-7,8);
            BoxType();
            deck.Add((GameObject)Instantiate(objl, new Vector3(randomX, 2, 0), Quaternion.identity, transform));
        }
	}
	void PartSystepPlay(){
		
			ps .Play ();
        if (PlayerPrefs.GetInt("vibrations") == 1)
                {
                    Handheld.Vibrate();

                }
                if (PlayerPrefs.GetInt("sounds") == 1)
                    explode.Play();

            } 
    void SetRandomNumbersToList(){
		for (int r = -7; r < 8; r++) {
			randomXList.Add( r);
		}
	}
    void NewRecord()
    {
        if (newRecordPart)
        {
            newRecordTXT.text = "New Record !";
            TextAnim_FireWorks();
            newRecordPart = false;
        }
    }
    void SwitchDif(){
        switch (difficulty)
        {

            case 0:

                if (scoreI > record0)
                {
                    NewRecord();
                    PlayerPrefs.SetInt("saverecord0", scoreI);
                    PlayerPrefs.Save();
                }
                record0= PlayerPrefs.GetInt("saverecord0");
              break;
            case 1:
                if (scoreI > record1)
                {
                    NewRecord();
                    PlayerPrefs.SetInt("saverecord1", scoreI);
                    PlayerPrefs.Save();
                }
                record1 = PlayerPrefs.GetInt("saverecord1");
                break;
            case 2:
                if (scoreI > record2)
                {

                    NewRecord();
                    PlayerPrefs.SetInt("saverecord2", scoreI);
                    PlayerPrefs.Save();
                }
                record2 = PlayerPrefs.GetInt("saverecord2");
                break;

            case 3: if (scoreI > record3)
                {
                    NewRecord();
                    PlayerPrefs.SetInt("saverecord3", scoreI);
                    PlayerPrefs.Save();
                }
                record3 = PlayerPrefs.GetInt("saverecord3");
                break;
        }


    
    }
    void BonusDestroy35() {
        if (bonScript.bonus4)
        {
            for (int i = 0; i < deck.Count*0.5f; i++)
            {
                deck[i].SetActive(false);
                Destroy(deck[i]);

            }
            bonScript.bonus4 = false;
            scoreI += 5000*scoreFactor;
            PartSystepPlay();
            if (difficulty == 3)
                timeScript.timerFloat += 35;

            

          
        }
    }
    public void TextAnim_FireWorks()
    {

        fireWorks.Play();
     
        newRecordAnim.Play();
        

    }
    }

		

	

	







