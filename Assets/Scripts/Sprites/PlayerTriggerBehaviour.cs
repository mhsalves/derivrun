using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjetoScripts;

namespace PlayerScripts {
	
	public class PlayerTriggerBehaviour : MonoBehaviour {

		private PlayerBehaviour m_PlayerBehavior;

		void Awake () {

			if (m_PlayerBehavior == null)
				m_PlayerBehavior = this.GetComponentInParent<PlayerBehaviour> ();

		}

		void OnTriggerEnter2D(Collider2D other){

			if ( other.tag == "OpcaoObstaculo") {

				if (m_PlayerBehavior.GetPlayerAnswerBehaviour ().GetPermissao ()) {
					m_PlayerBehavior.GetPlayerAnswerBehaviour ().PegarOpcao ();

					var ob = other.GetComponent<OpcaoBehaviour> ();
					ob.Validar ();

				}


			}

			if ( other.tag == "AjusteDePosicionamento" ) {
				m_PlayerBehavior.AcionarPosicionamento ();
//				print ("Posicao ajustada");
			}

			if (other.tag == "LiberacaoOpcao") {
				m_PlayerBehavior.GetPlayerAnswerBehaviour ().LargarOpcao ();
//				print ("Liberação Opção");
			}

		}

	}

}