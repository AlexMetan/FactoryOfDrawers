using UnityEngine;
using UnityEngine.UI;
public class playerAndBonus : MonoBehaviour {
    public PlayerMoves jumph;
    public	bool bonus1,bonus2,bonus3,bonus4,bonus5;
	public float timeB1,timeB5;
	public ParticleSystem bonusPart;
    public ParticleSystem fireworks;
    public BoxSpawn box_spawn;
    public Material jumpBonus, invBonus, scoreBonus;
    ParticleSystemRenderer partRend;
    public Text doubleScore;
    public Animation doubleScoreA;
    
	public AudioSource bonusSound;
 
    public Image timeJumpBon,timeDoubleScore;

    void Start() {
        partRend = bonusPart.GetComponent<ParticleSystemRenderer>();
      
    }

	 void OnTriggerEnter2D(Collider2D col){
       
            
		if (col.gameObject.tag == "bonus1") {

          
				
			bonus1 = true;
            BonusAcc(jumpBonus);

		}
		if (col.gameObject.tag == "bonus2") {
          
            bonus2 = true;
            

		}
		if (col.gameObject.tag == "bonus3") {
            bonus3 = true;

            BonusAcc(invBonus);

			}
        if (col.gameObject.tag == "bonus4")
        {
          
            bonus4 = true;
            TextAnim_FireWorks("Amazing!");


        }

        if (col.gameObject.tag == "bonus5")
        {
            timeB5 = 25f;
           
            bonus5 = true;
             TextAnim_FireWorks("DOUBLE SCORE !");


        }

     
 

	}

     void DoubleScoreBonus() { 
     
     if (bonus5) {
			
			timeB5 -= Time.deltaTime;
            timeDoubleScore.fillAmount = timeB5 / 25;	
				if (timeB5 <= 0)
                   
					bonus5 = false;
                box_spawn.scoreFactor = 2;


		} else if (!bonus5) {
			
           
            box_spawn.scoreFactor = 1;
		
		}
	}

	 void JumpBonus(){
		if (bonus1) {
			
			timeB1 -= Time.deltaTime;
            jumph.jumpHeight = 7f;
            timeJumpBon.fillAmount = timeB1 / 7;	
				if (timeB1 <= 0)
                   
					bonus1 = false;
				


		} else if (!bonus1) {
			
            timeB1 = 7;
            jumph.jumpHeight = 5f;
		
		}
	}


  public  void BonusAcc(Material ps) {
        if (PlayerPrefs.GetInt("sounds") == 1)
        bonusSound.Play();
        partRend.material = ps;
        bonusPart.Play();
    }
	void Update(){
        JumpBonus();
        DoubleScoreBonus();
	}

    public void TextAnim_FireWorks(string txt)
    {

        fireworks.Play();
        doubleScore.text = txt;
        doubleScoreA.Play();



    }
}
