using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerScripts {

	[RequireComponent(typeof (PlayerBehaviour))]
	public class PlayerAnswerBevaviour : MonoBehaviour {

		private bool m_PodePegarOpcao = true;



		public bool GetPermissao() {
			return m_PodePegarOpcao;
		}

		public void PegarOpcao() {
			m_PodePegarOpcao = false;
		}

		public void LargarOpcao() {
			m_PodePegarOpcao = true;
		}

	}

}