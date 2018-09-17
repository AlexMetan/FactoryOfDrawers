
using UnityEngine;

public class BonusPhysics : MonoBehaviour {
 
    Rigidbody2D rb;
	
	
    void Start() { rb = GetComponent<Rigidbody2D>();   }

    void OnCollisionEnter2D(Collision2D col) {
      if (col.gameObject.layer == 9)
            rb.mass = 200;

    }
   
}
