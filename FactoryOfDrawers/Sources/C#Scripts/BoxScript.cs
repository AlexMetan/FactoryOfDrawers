using UnityEngine;

public class BoxScript : MonoBehaviour {
	private float x,y;
    Rigidbody2D rb;
	public bool isCollis;
    Vector3 startPoss, endPoss,newVector;
	public bool box2;
    PlayerMoves pm;
    public BoxAndHead boxNhand;
    Transform tr;
    BoxBlockSide sideBlock;
    GameOverScript go;
	
        
    Vector3 oldVX, newVX,oldVY, newVY;
  	public void Start(){
        pm = FindObjectOfType<PlayerMoves>();
        go = FindObjectOfType<GameOverScript>();
        sideBlock = GetComponentInChildren<BoxBlockSide>();
        rb = gameObject.GetComponent<Rigidbody2D>();
		 tr = gameObject.GetComponent<Transform>();
         FreezeXandRot();
      

	}
	public void FixedUpdate(){
        LoseToManyBoxes();
        if (boxNhand.boxGr)
        {
            if (isCollis && !box2 && !sideBlock.blockSide)
            {
                rb.mass = 50;
                rb.gravityScale = 0;
                FreezeOnlyRot();
            }
            else if (box2 && sideBlock.blockSide)
            {
                rb.mass = 5000;
                rb.gravityScale = 1;
                FreezeAll();

            }
            else {
                rb.mass =5000;
                rb.gravityScale = 1;
                FreezeAll();
            }
                
          
        }
        else {
            rb.mass = 5000;
            rb.gravityScale = 1f;
            FreezeXandRot();
        }
        if (boxNhand.boxGr && !isCollis)
            RoundBoxY();
        else rb.WakeUp();
        if (!pm.isMoved| !boxNhand.boxGr || sideBlock.blockSide) { RoundBoxX(); }

        


       
	}
  
    
	void OnTriggerStay2D(Collider2D col){
      
		if (col.gameObject.tag == "BoxBlock") {
			box2 = true;
		}
		if (col.gameObject.tag == "Hands") {
            isCollis = true;
          

		}
	}
	void OnTriggerExit2D(Collider2D col){

		if (col.gameObject.tag == "BoxBlock") {
			box2 = false;
		}
       
		
		if (col.gameObject.tag == "Hands" ) {
            RoundBoxX();
            isCollis = false;
            
		}
	}
	public void RoundBoxX(){
        y = tr.position.y;
        oldVX = new Vector3(tr.position.x, y, 0);
        x = Mathf.Round(tr.position.x);
        newVX = new Vector3(x, y, 0);

        tr.position =  Vector3.MoveTowards (oldVX,newVX,1.1f*Time.fixedDeltaTime );
     
		
	}
    public void RoundBoxY()
    {
        y = tr.localPosition.y;
        oldVY = new Vector3(x, tr.localPosition.y, 0);
        y = Mathf.Round(tr.localPosition.y);
        newVY = new Vector3(x, y, 0);

        tr.localPosition = Vector3.MoveTowards(oldVY, newVY, Time.deltaTime*3);
        
        

    }
  public  void FreezeXandRot() {
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation; 

    }
  public void FreezeAll() { rb.constraints = RigidbodyConstraints2D.FreezeAll;
  
  }
   public void FreezeOnlyRot() {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
   public void FreezeYandRot()
   {
       rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

   }
 
    void LoseToManyBoxes() {
        if (box2 && transform.localPosition.y > 8.5f)
        {
            go.GameOver();
            gameObject.SetActive(false);

        }
    }

}
