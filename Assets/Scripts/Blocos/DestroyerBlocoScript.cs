using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerBlocoScript : MonoBehaviour {

	void OnTriggerEnter2D( Collider2D other ) {

		if (other.tag == "Player") {
			Debug.Break();
			return;
		} 

		if (other.tag == "LineMap") {
			var parent = other.transform.parent;
			Destroy (other.gameObject);

			//print (parent.childCount);

			if (parent.childCount == 2) { //Inclui o SpawnPoint + other ainda não eliminado
				Destroy (parent.gameObject);
			}

		}

		//print ("Triggered Destroyer");

	}

}
