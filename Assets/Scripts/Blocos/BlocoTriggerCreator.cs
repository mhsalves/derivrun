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

				gameController.numBlocos++;
				var ss = other.GetComponent<BlocoSpawnBehaviour> ();

				if (gameController.numBlocos == contadorResposta) {
					ss.InvocarResposta ();
				} else if (gameController.numBlocos == contadorResposta+1){
					ss.InvocarLimpo ();
					gameController.numBlocos = 0;
				} else {
					ss.InvocarNormal ();
				}

			}


		}

	}

}
