using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Componentes {

	[RequireComponent(typeof (Animator))]
	public class LifePopupItem : MonoBehaviour {
		
		private Animator m_Animator;
		[SerializeField] private bool m_Aceso = false;

		void Awake () {
			this.m_Animator = GetComponent<Animator> ();

		}

		void Start () {
			this.AtualizarAnims ();

		}

		public void Acender () {
			this.m_Aceso = true;
			this.AtualizarAnims ();
		}

		public void Apagar (){
			this.m_Aceso = false;
			this.AtualizarAnims ();
		}

		private void AtualizarAnims (){
			this.m_Animator.SetBool ("Aceso", this.m_Aceso);

		}

	}

}