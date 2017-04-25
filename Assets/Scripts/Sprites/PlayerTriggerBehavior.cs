using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerBehavior : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){

		if ( other.tag == "OpcaoObstaculo") {
			var oo = other.GetComponent<OpcaoBehavior> ();
			oo.Validar ();
			print ("Validar");
		}

	}

}
