using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controladores {

	public class InitialController : MonoBehaviour {

		[SerializeField] private ScreenController m_ScreenController;

		// Use this for initialization
		void Start () {
			m_ScreenController.AbrirMain ();

		}

		public void Ativar() {
			gameObject.SetActive (true);
		}


	}

}
