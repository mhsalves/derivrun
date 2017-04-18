using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlocoScript : MonoBehaviour {

	void OnTriggerEnter2D( Collider2D other ) {
		
		if (other.tag == "PointSpawnBlock") {

			var ss = other.GetComponent<SpawnBlocoScript> ();
			ss.IniciarInvocacao ();

			//print ("Triggered Create");

		}


	}

}
