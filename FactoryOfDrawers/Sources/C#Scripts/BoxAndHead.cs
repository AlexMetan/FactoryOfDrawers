using UnityEngine;

public class BoxAndHead : MonoBehaviour
{
   public  BoxScript bs;
   public bool boxGr;
   playerAndBonus pb;
   public Material shield;
   void Start() { pb = FindObjectOfType<playerAndBonus>(); }

        void OnTriggerStay2D(Collider2D cl) {
            if (cl.gameObject.layer == 9)
            boxGr = true;

    
    }


    void OnTriggerExit2D(Collider2D cl)
    {
        if (cl.gameObject.layer == 9 )
        {
            boxGr = false;
           
        }
    }




    void OnTriggerEnter2D(Collider2D col)
    {



        if (col.gameObject.tag == "Head")
        {
            if (pb.bonus3)
            {
                pb.BonusAcc(shield);
                Destroy(transform.parent.gameObject);
                pb.bonus3 = false;

            }


        }



    }

}