using UnityEngine;

public class BoxBlockSide : MonoBehaviour {

   public  Transform tr;
   public bool blockSide;
	void Start () {
   
       
	}

    void OnTriggerStay2D(Collider2D col) {
        if (col.gameObject.tag == "sideCol")
        {
            blockSide = true;
        
        }

    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "sideCol")
        {
            blockSide = false;

        }
    }
}

