using UnityEngine;

public class boxMoved : MonoBehaviour {
	public bool moved;
	public GameObject player;
    void Start() {
        moved = false;
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Box")
        {
            moved = true;


        }

    }

	void OnTriggerStay2D(Collider2D col){
        if (col.gameObject.tag == "Box")
        {
            moved = true;


        }
        
	}
	void  OnTriggerExit2D(Collider2D col){
		if(col.gameObject.tag == "Box") {
		
			moved = false;
           
		

		}
	}
}
