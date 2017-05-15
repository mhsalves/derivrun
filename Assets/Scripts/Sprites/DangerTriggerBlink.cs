using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Componentes;

namespace PlayerExtras {

	public class DangerTriggerBlink : MonoBehaviour {

		[SerializeField] private DangerScreenBehaviour m_DangerScreenBehvaiour;

		void OnTriggerEnter2D ( Collider2D other ) {

			if ( other.tag == "Player" ) {
				m_DangerScreenBehvaiour.Acionar (true);
			}

		}

		void OnTriggerExit2D ( Collider2D other ) {

			if ( other.tag == "Player" ) {
				m_DangerScreenBehvaiour.Acionar (false);
			}

		}


	}
	 
}