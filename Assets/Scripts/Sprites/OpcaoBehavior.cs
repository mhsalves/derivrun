using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controladores;

namespace ObjetoScript {

	public class OpcaoBehavior : MonoBehaviour {

		private GameController gameController;

		[System.Serializable]
		public enum Tipo : int {
			A = 0, B = 1, C = 2, D = 3
		}

		public Tipo tipo = Tipo.A;

		// Use this for initialization
		void Start () {
			this.gameController = GameObject.Find ("GameController").GetComponent<GameController> ();

		}

		public void Validar() {
			this.gameController.ValidarResposta ((int) tipo);
		}

	}

}