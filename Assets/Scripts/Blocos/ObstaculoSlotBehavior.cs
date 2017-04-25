using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoSlotBehavior : MonoBehaviour {

	public DataBlocos dataBlocos;
	public DataBlocos.MarkerType marker;

	public void Spawn() {
		var obj = dataBlocos.GetFaseByMarker (this.marker).SelecionarObstaculoAleatorio();
		var pos = transform.position;
		pos.z = 0f;

		GameObject go = (GameObject) Instantiate (obj, pos, Quaternion.identity);
		go.transform.SetParent (transform);
	}

}
