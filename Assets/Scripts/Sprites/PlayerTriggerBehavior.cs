using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (PlayerBehavior))]
public class PlayerTriggerBehavior : MonoBehaviour {

	public PlayerBehavior m_PlayerBehavior;

	void OnTriggerEnter2D(Collider2D other){

		if ( other.tag == "OpcaoObstaculo") {
			var oo = other.GetComponent<OpcaoBehavior> ();
			oo.Validar ();
			print ("Validar");
		}

		if ( other.tag == "AjusteDePosicionamento" ) {
			m_PlayerBehavior.ValidarPosicaoCorreta ();
			print ("Posicao ajustada");
		}

	}

}
