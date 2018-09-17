using UnityEngine;

public class TimerColission : MonoBehaviour {
	public float timerF;
    public Material timerBonus;
    playerAndBonus pnBonus;
    TimerScript ts;

    void Start() {
        pnBonus = FindObjectOfType<playerAndBonus>();
        ts = FindObjectOfType<TimerScript>();
     
    }
	public void OnCollisionEnter2D(Collision2D col){

       
		if (col.gameObject.tag == "Player") {

            pnBonus.BonusAcc(timerBonus);
            ts.timerFloat += 15;
			Destroy (gameObject);
			
		}


	}
	public void OnTriggerEnter2D(Collider2D cl){
		if (cl.gameObject.tag == "BoxBlock") {

			Destroy (gameObject);
		}
		
	}
}
