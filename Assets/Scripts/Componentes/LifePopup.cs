using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Componentes {

	public class LifePopup : MonoBehaviour {

		public List<LifePopupItem> listHearts;
		private LifeController lifeController;

		public GameObject mainContent;

		void Start() {

			this.lifeController = GameObject.Find ("LifeController").GetComponent<LifeController> ();
			this.AtualizarDesenho ();

		}

		public void AplicarQuantidade (int quantidade) {

			this.lifeController.IniciarCom (quantidade);
			this.AtualizarDesenho ();

		}

		public void Show() {

			this.mainContent.SetActive (true);
			this.AtualizarDesenho ();
		}

		private void AtualizarDesenho(){
			
			for (int i = 0; i < this.lifeController.GetVidas(); i++) {
				this.listHearts[i].Acender();
			}

			for (int i = this.lifeController.GetVidas (); i < LifeController.maxVidas; i++) {
				this.listHearts[i].Apagar();
			}

		}

	}

}