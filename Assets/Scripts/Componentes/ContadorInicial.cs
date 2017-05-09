using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Componentes {

	public class ContadorInicial : MonoBehaviour {

		public GameObject parent;
		public Animator animator;
		public Text text;

		public GameController gameController;

		public void Comecar() {
			this.parent.SetActive (true);
		}

		public void Fechar(){
			this.parent.gameObject.SetActive (false);
		}

		public void IniciarGame() {
			this.parent.SetActive (false);
			this.gameController.Iniciar ();

		}

		public void MudarValor( int valor ) {
			this.text.text = "" + valor;
		}

	}

}