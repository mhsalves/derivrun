using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObstaculoTrigger : MonoBehaviour {

	void OnTriggerEnter2D( Collider2D other ) {

		if (other.tag == "ObstaculoSlot") {

			var osb = other.GetComponent<ObstaculoSlotBehavior> ();
			osb.Spawn ();

		}


	}

}
