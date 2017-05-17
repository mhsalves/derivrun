using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerScripts {

	[RequireComponent(typeof (PlayerBehaviour))]
	public class PlayerUserControlBehaviour : MonoBehaviour {

		private PlayerBehaviour m_PlayerBehavior;
		private PlayerBehaviour.Direcao m_AndarNaDirecao;

		void Awake () {
			this.m_PlayerBehavior = GetComponent<PlayerBehaviour> ();
		
		}

		void FixedUpdate() {

			this.m_PlayerBehavior.Mover (m_AndarNaDirecao);
			this.m_PlayerBehavior.MoverParaPosicaoCorreta ();

		}

		public void AcionarParaDireita() {
			this.m_AndarNaDirecao = PlayerBehaviour.Direcao.DIREITA;
		}

		public void AcionarParaEsquerda() {
			this.m_AndarNaDirecao = PlayerBehaviour.Direcao.ESQUERDA;
		}

		public void AcionarParaFrente() {
			this.m_AndarNaDirecao = PlayerBehaviour.Direcao.FRENTE;
		}


	}

}
