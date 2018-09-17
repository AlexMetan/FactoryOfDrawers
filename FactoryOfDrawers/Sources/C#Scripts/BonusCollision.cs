using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusCollision : MonoBehaviour {




    public void OnTriggerEnter2D(Collider2D  col)
	{
		
		if (col.gameObject.tag == "Player") {

			Destroy (gameObject);

		}

		if (col.gameObject.tag == "BoxBlock") {
			Destroy (gameObject);
		}
	}
}
