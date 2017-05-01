using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilitarios;

public class BlocosInformations : MonoBehaviour {

	public enum MarkerType {
		SALADEAULA, DIRETORIA, LANCHONETE
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

	public Fase faseSalaDeAula;
	public Fase faseDiretoria;
	public Fase faseLanchonete;

	public Fase GetFaseAtual() {

		//TODO logica para determinar fase

		return faseSalaDeAula;

	}

	public Fase GetFaseByMarker( MarkerType marker ) {
		switch (marker) {
		case MarkerType.SALADEAULA:
			return faseSalaDeAula;
		case MarkerType.DIRETORIA:
			return faseDiretoria;
		case MarkerType.LANCHONETE:
			return faseLanchonete;
		default:
			return faseSalaDeAula;
		}
	}

}
