using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilitarios;

public class DataBlocos : MonoBehaviour {

	public enum MarkerType {
		FLORESTA, DESERTO
	}

	[System.Serializable]
	public struct Fase {
		public GameObject blockCleaned;
		public GameObject blockAnswer;
		public List<GameObject> blocks;
		public List<GameObject> obstaculos;

		public GameObject SelecionarBlocoAleatorio() {
			int i = RandomUtils.RandomInt (0, blocks.Count);
			return blocks [i];
		}

		public GameObject SelecionarObstaculoAleatorio() {
			int i = RandomUtils.RandomInt (0, obstaculos.Count);
			return obstaculos [i];
		}
	}

	public Fase faseFloresta;
	public Fase faseDeserto;

	public Fase GetFaseAtual() {

		//TODO logica para determinar fase

		return faseFloresta;

	}

	public Fase GetFaseByMarker( MarkerType marker ) {
		switch (marker) {
		case MarkerType.FLORESTA:
			return faseFloresta;
			break;
		case MarkerType.DESERTO:
			return faseDeserto;
			break;
		default:
			return faseFloresta;
			break;
		}
	}

}
