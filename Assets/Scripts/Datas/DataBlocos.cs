using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBlocos : MonoBehaviour {

	[System.Serializable]
	public struct Fase {
		public GameObject blockCleaned;
		public List<GameObject> blocks;
	}

	public Fase faseFloresta;
	public Fase faseDeserto;

	public Fase GetFaseAtual() {

		//TODO logica para determinar fase

		return faseFloresta;

	}

}
