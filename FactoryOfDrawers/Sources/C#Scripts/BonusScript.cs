using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class BonusScript : MonoBehaviour {
	public GameObject bonus1, bonus2, bonus3,bonus4,bonus5;
	float randTime;
	int randBonus;
    GameObject b1,b2,b3,b4,b5;
	public GameObject  shieldB;
    public GameObject jumpB;
    public GameObject doubleScore;
    public playerAndBonus bonusScript;
    playerAndBonus playerNbonus;
    public BoxSpawn box_spawn;
    void Start()
    {

        StartCoroutine(SpawnBonus());
        playerNbonus = FindObjectOfType<playerAndBonus>();
    }

	 void Update(){
         BonusUI();
	}
     
     void BonusUI() {

         if (bonusScript.bonus1) jumpB.SetActive(true);   
            else 
              jumpB.SetActive(false);  
         //
         if (playerNbonus.bonus3) shieldB.SetActive(true);
            else shieldB.SetActive(false);
         //
         if (playerNbonus.bonus5) doubleScore.SetActive(true);
         else doubleScore.SetActive(false);
     }
	 void Repeat(){
		StartCoroutine (SpawnBonus ());
	}
	 IEnumerator SpawnBonus(){
		yield return new WaitForSeconds (Random.Range (10, 30));
        if (!playerNbonus.bonus3)
            randBonus = Random.Range(0, 4);
         else if (box_spawn.bonus35Active)
             randBonus = Random.Range(1, 5);
        else if (!playerNbonus.bonus3 && box_spawn.bonus35Active)
            randBonus = Random.Range(0, 5);
        else randBonus = Random.Range(1, 4);
		switch (randBonus) {
		case 0:
                 b3 = Instantiate(bonus3, new Vector3(Random.Range(-6, 7), 8f, 0), Quaternion.identity);
            Destroy(b3, 7);
			
			break;
		case 1:
            b2 = Instantiate(bonus2, new Vector3(Random.Range(-6, 7), 8f, 0), Quaternion.identity);
			Destroy (b2, 7);
			break;
		case 2:
                 b1 =	Instantiate (bonus1, new Vector3 (Random.Range (-6,7 ), 8f, 0), Quaternion.identity);
			Destroy (b1, 7);
            
			break;
        

        case 3:
            b5 = Instantiate(bonus5, new Vector3(Random.Range(-6, 7), 8f, 0), Quaternion.identity);
            Destroy(b5, 7);
            break;
        case 4:
            b4 = Instantiate(bonus4, new Vector3(Random.Range(-6, 7), 8f, 0), Quaternion.identity);
            Destroy(b4, 7);
            break;

		}
		Repeat ();

	}
}
