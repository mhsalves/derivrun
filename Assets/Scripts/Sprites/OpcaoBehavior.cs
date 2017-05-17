using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controladores;

namespace ObjetoScripts {

	public class OpcaoBehavior : MonoBehaviour {

		private GameController m_GameController;

		[System.Serializable]
		public enum Tipo : int {
			A = 0, B = 1, C = 2, D = 3
		}

		public Tipo m_Tipo = Tipo.A;

		// Use this for initialization
		void Awake () {
			this.m_GameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();

		}

		public void Validar() {
			this.m_GameController.ValidarResposta ((int) m_Tipo);
		}

	}

}