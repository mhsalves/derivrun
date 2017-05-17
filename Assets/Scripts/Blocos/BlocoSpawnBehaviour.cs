using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InformacoesEstaticas;

namespace BlocoScripts {

	public class BlocoSpawnBehaviour : MonoBehaviour {
		
		public int childAhead = 0;
		private bool spawned = false;

		public BlocosInformations dataBlocos;

		public enum TipoBloco {
			LIMPO, NORMAL, RESPOSTA
		}

		private void Spawn( TipoBloco tipo ) {

			if (!spawned) {
				var obj = (tipo == TipoBloco.LIMPO) ? dataBlocos.GetFaseAtual ().blockCleaned : (tipo == TipoBloco.RESPOSTA) ? dataBlocos.GetFaseAtual().blockAnswer : dataBlocos.GetFaseAtual().SelecionarBlocoAleatorio();
				var pos = transform.position;
				pos.z = 0f;

				GameObject go = (GameObject) Instantiate (obj, pos, Quaternion.identity);
				var ss = go.transform.Find ("SpawnPoint").GetComponent<BlocoSpawnBehaviour> ();

				if (childAhead > 0) {
					ss.childAhead = childAhead - 1;
					ss.InvocarNormal ();
				} 
			}

			spawned = true;

		}



		public void InvocarNormal() {
			Spawn (TipoBloco.NORMAL);
		}

		public void InvocarResposta() {
			Spawn (TipoBloco.RESPOSTA);	
		}

		public void InvocarLimpo() {
			Spawn (TipoBloco.LIMPO);
		}

	}

}