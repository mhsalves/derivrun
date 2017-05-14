using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controladores;

namespace BlocoScripts {

	public class BlocoTriggerCreator : MonoBehaviour {

		public GameController gameController;
		private int contadorResposta = 8; //Quantidade de blocos para aparecer o Bloco de Respostas

		void OnTriggerEnter2D( Collider2D other ) {
			
			if (other.tag == "PointSpawnBlock") {

				gameController.contadorDeBlocos++;
				var ss = other.GetComponent<BlocoSpawnBehavior> ();

				if (gameController.contadorDeBlocos == contadorResposta) {
					ss.InvocarResposta ();
				} else if (gameController.contadorDeBlocos == contadorResposta+1){
					ss.InvocarLimpo ();
					gameController.contadorDeBlocos = 0;
				} else {
					ss.InvocarNormal ();
				}

			}


		}

	}

}
