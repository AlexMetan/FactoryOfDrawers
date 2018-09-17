using UnityEngine;


public class boxColiders : MonoBehaviour {
    
     public playerAndBonus bonuses;
     public GameOverScript gameOv;
      
         

      void	OnTriggerEnter2D (Collider2D cl)
     {	if (cl.gameObject.tag == "Box"&& !bonuses.bonus3) {

         gameOv.GameOver();
         }
     }
    

}