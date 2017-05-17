using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjetoScripts;

namespace PlayerScripts {
	
	public class PlayerTriggerBehaviour : MonoBehaviour {

		private PlayerBehavior m_PlayerBehavior;

		void Awake () {

			if (m_PlayerBehavior == null)
				m_PlayerBehavior = this.GetComponentInParent<PlayerBehavior> ();

		}

		void OnTriggerEnter2D(Collider2D other){

			if ( other.tag == "OpcaoObstaculo") {

				var ob = other.GetComponent<OpcaoBehavior> ();
				ob.Validar ();

			}

			if ( other.tag == "AjusteDePosicionamento" ) {
				m_PlayerBehavior.AcionarPosicionamento ();
				print ("Posicao ajustada");
			}

		}

	}

}