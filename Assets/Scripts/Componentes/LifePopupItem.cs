using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Componentes {

	[RequireComponent(typeof (Animator))]
	public class LifePopupItem : MonoBehaviour {
		
		private Animator animator;
		private bool aceso = false;

		void Start() {
			this.animator = GetComponent<Animator> ();

		}

		public void Acender() {
			this.aceso = true;
			this.atualizar ();
		}

		public void Apagar(){
			this.aceso = false;
			this.atualizar ();
		}

		private void atualizar(){
			this.animator.SetBool ("Aceso", this.aceso);
		}

	}

}