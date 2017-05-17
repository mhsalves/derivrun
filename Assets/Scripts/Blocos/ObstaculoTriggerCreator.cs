using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlocoScripts {

	public class ObstaculoTriggerCreator : MonoBehaviour {

		void OnTriggerEnter2D( Collider2D other ) {

			if (other.tag == "ObstaculoSlot") {

				var osb = other.GetComponent<ObstaculoSlotBehaviour> ();
				osb.Spawn ();

			}


		}

	}

}