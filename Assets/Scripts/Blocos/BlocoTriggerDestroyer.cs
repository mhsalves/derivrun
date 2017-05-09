using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlocoScripts {

	public class BlocoTriggerDestroyer : MonoBehaviour {

		void OnTriggerEnter2D( Collider2D other ) {

			if (other.tag == "Player") {
				Debug.Break();
				return;
			} 

			if (other.tag == "LineMap" || other.tag == "PointSpawnBlock" ) {
				var parent = other.transform.parent;
				Destroy (other.gameObject);

				if (parent != null && parent.childCount == 1) {
					Destroy (parent.gameObject);
				}
			}
		
		}

	}

}