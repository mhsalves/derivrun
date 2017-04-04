using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Componentes {

	public class LifePopup : MonoBehaviour {

		public List<LifePopupItem> listHearts;
		private int quantidade = 1;

		public int GetQuantidade() {
			return quantidade;
		}

		void Start() {
			AplicarQuantidade (1);

		}

		public ScreenController screenController;

		public void AplicarQuantidade (int quantidade) {

			this.quantidade = (quantidade < 1) ? 1 : (quantidade > 10) ? 10 : quantidade;

			foreach (LifePopupItem lpi in listHearts) {
				lpi.Apagar ();
			}

			for (int i = 0; i < this.quantidade; i++) {
				this.listHearts[i].Acender();
			}

		}

		public void ComeçarJogo() {
			//TODO: Mandar a quantidade de vidas para o scene de GAME
			screenController.AbrirGame ();
		}

	}

}