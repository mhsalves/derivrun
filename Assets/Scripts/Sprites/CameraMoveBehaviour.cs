using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraScripts {

	public class CameraMoveBehaviour : MonoBehaviour {

		[SerializeField] private float m_Velocidade = 3f;
		[SerializeField] private bool m_Mover = false;

		public void Mover() {
			m_Mover = true;
		}

		public void Parar() {
			m_Mover = false;
		}

		void Update() {
			
			if (m_Mover) {
				transform.Translate (0f, m_Velocidade * Time.deltaTime, 0f);
			}

		}

	}

}