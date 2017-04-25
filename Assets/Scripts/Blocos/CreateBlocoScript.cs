using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlocoScript : MonoBehaviour {

	public GameController gameController;
	private int contadorResposta = 5; //Quantidade de blocos para aparecer o Bloco de Respostas

	void OnTriggerEnter2D( Collider2D other ) {
		
		if (other.tag == "PointSpawnBlock") {

			gameController.contadorDeBlocos++;
			var ss = other.GetComponent<SpawnBlocoScript> ();

			if (gameController.contadorDeBlocos == contadorResposta) {
				ss.InvocarResposta ();
			} else if (gameController.contadorDeBlocos == contadorResposta+1){
				ss.cleaned = true;
				ss.IniciarInvocacao ();
				gameController.contadorDeBlocos = 0;
			} else {
				ss.IniciarInvocacao ();
			}

		}


	}

}
