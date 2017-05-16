using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controladores;

namespace Componentes {

	public class LifePopup : MonoBehaviour {

		private LifeController c_LifeController;
		[SerializeField] private List<LifePopupItem> listHearts;

		[SerializeField] public GameObject mainContent;

		void Awake () {

			if (this.c_LifeController == null) 
				this.c_LifeController = GameObject.FindGameObjectWithTag ("LifeController").GetComponent<LifeController> ();
			
		}

		void Start() {

			this.AplicarQuantidade (1);

		}

		public void AplicarQuantidade (int quantidade) {

			this.c_LifeController.IniciarCom (quantidade);
			this.AtualizarDesenho ();

		}

		public void Show() {

			this.mainContent.SetActive (true);
			this.AtualizarDesenho ();
		}

		private void AtualizarDesenho(){
			
			for (int i = 0; i < this.c_LifeController.GetVidas(); i++) {
				this.listHearts[i].Acender();
			}

			for (int i = this.c_LifeController.GetVidas (); i < LifeController.maxVidas; i++) {
				this.listHearts[i].Apagar();
			}

		}

	}

}