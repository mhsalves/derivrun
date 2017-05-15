using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Controladores;

namespace PlayerExtras {

	public class GameTriggerEnding : MonoBehaviour {

		void Start() {
			
		}


		[SerializeField] private GameController m_GameController;

		void OnTriggerEnter2D ( Collider2D other ) {

			if (other.tag == "Player") {
				m_GameController.EndGame ();
			}

		}




	}

}