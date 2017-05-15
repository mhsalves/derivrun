using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Componentes {

	public class DangerScreenBehaviour : MonoBehaviour {

		[SerializeField] private bool m_Piscar = false;
		private Animator m_Animator;

		// Use this for initialization
		void Awake () {
			this.m_Animator = GetComponent<Animator> ();

		}

		public void Acionar (bool piscar) {
			this.gameObject.SetActive (piscar);
			this.m_Piscar = piscar;
			this.m_Animator.SetBool ("Piscando", m_Piscar);
		} 

	}

}