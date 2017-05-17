using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerScripts {

	[RequireComponent(typeof (PlayerBehavior))]
	public class PlayerUserControlBehavior : MonoBehaviour {

		private PlayerBehavior m_PlayerBehavior;
		private PlayerBehavior.Direcao m_AndarNaDirecao;

		void Awake () {
			this.m_PlayerBehavior = GetComponent<PlayerBehavior> ();
		
		}

		void FixedUpdate() {

			this.m_PlayerBehavior.Mover (m_AndarNaDirecao);
			this.m_PlayerBehavior.MoverParaPosicaoCorreta ();

		}

		public void AcionarParaDireita() {
			this.m_AndarNaDirecao = PlayerBehavior.Direcao.DIREITA;
		}

		public void AcionarParaEsquerda() {
			this.m_AndarNaDirecao = PlayerBehavior.Direcao.ESQUERDA;
		}

		public void AcionarParaFrente() {
			this.m_AndarNaDirecao = PlayerBehavior.Direcao.FRENTE;
		}


	}

}
