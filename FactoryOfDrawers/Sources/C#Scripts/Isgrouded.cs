using UnityEngine;

public class Isgrouded : MonoBehaviour
{
    public bool isGroundedJump;
    public LayerMask boxes;
    public boxMoved bm;

    void FixedUpdate() {
        CheckColWithBox();
        if (!isGroundedJump)
            bm.moved = false;
    }

  
    void OnTriggerStay2D(Collider2D cl)
    {
        if (cl.gameObject.tag == "Ground")
            isGroundedJump = true;

    }


    void OnTriggerExit2D(Collider2D cl)
    {


        if (cl.gameObject.tag == "Ground")
        {
            isGroundedJump = false;
        }
    }

    void CheckColWithBox()
    {
       isGroundedJump =Physics2D.OverlapCircle(transform.position, 0.15f,boxes);
       
        
    }
}