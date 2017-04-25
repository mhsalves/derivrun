using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlocoScript : MonoBehaviour {
	
	public int childAhead = 0;
	private bool spawned = false;

	public DataBlocos dataBlocos;
	public bool cleaned = false;

	private void Spawn( bool resposta ) {

		if (!spawned) {
			var obj = (cleaned) ? dataBlocos.GetFaseAtual ().blockCleaned : (resposta) ? dataBlocos.GetFaseAtual().blockAnswer : dataBlocos.GetFaseAtual().SelecionarBlocoAleatorio();
			var pos = transform.position;
			pos.z = 0f;

			GameObject go = (GameObject) Instantiate (obj, pos, Quaternion.identity);
			var ss = go.transform.Find ("SpawnPoint").GetComponent<SpawnBlocoScript> ();

			if (childAhead > 0) {
				ss.childAhead = childAhead - 1;
				ss.IniciarInvocacao ();
			} 
		}

		spawned = true;

	}



	public void IniciarInvocacao() {
		Spawn (false);
	}

	public void InvocarResposta() {
		Spawn (true);	
	}

}
