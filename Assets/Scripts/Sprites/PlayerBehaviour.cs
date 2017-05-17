using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilitarios;
using ObjetoScripts;

namespace PlayerScripts {
	
	public class PlayerBehaviour : MonoBehaviour {

		public enum Direcao : int {
			DIREITA = 1, ESQUERDA = -1, FRENTE = 0, NENHUM = 2
		}
				
		private readonly static string animWalk = "Correr";
		private readonly static string animPower = "Poder";

		[SerializeField] private LayerMask m_Paredes;
		[SerializeField] private float m_Velocidade;

		private Direcao mDirecao;

		private Transform mSideRight;
		private Transform mSideLeft;

		public bool canMoveRight = true;
		public bool canMoveLeft = true;

		private const float kRadioDist = .01f; 

		[SerializeField] private Transform m_Corpo;
		[SerializeField] private float m_AlturaNatural = 0f;

		private bool m_MoverParaPosicao = false;
		private Animator m_Animator;

		private void Awake() {

			this.mSideLeft = transform.Find ("SideLeft");
			this.mSideRight = transform.Find ("SideRight");

			this.m_Animator = m_Corpo.GetComponent<Animator> ();
		
			this.ValidarPosicaoCorreta ();

		}



		private void FixedUpdate() {

			this.canMoveLeft = true;
			this.canMoveRight = true;

			//For Right
			Collider2D[] rightColliders = Physics2D.OverlapCircleAll(mSideRight.position, kRadioDist, m_Paredes);
			for (int i = 0; i < rightColliders.Length; i++)
			{
				if (rightColliders[i].gameObject != gameObject)
					this.canMoveRight = false;
			}

			//For Left
			Collider2D[] leftColliders = Physics2D.OverlapCircleAll(mSideLeft.position, kRadioDist, m_Paredes);
			for (int i = 0; i < leftColliders.Length; i++)
			{
				if (leftColliders[i].gameObject != gameObject)
					this.canMoveLeft = false;
			}

		}

		private void ValidarPosicaoCorreta() {

			if (this.transform.localPosition.y != m_AlturaNatural) {
				Vector3 p = this.transform.localPosition;
				p.y = m_AlturaNatural;
				this.transform.localPosition = p;
			}

		}

		public void AcionarPosicionamento () {
			this.m_MoverParaPosicao = true;
		}

		public void MoverParaPosicaoCorreta() {

			if (m_MoverParaPosicao) {
				var pAtual = this.transform.localPosition;
				var curve = Mathf.Abs(pAtual.y - m_AlturaNatural);
				var speed = (4.5f + curve) * Time.deltaTime;

				var curveAbroad = .011f;

				var pY = Mathf.Lerp (pAtual.y, m_AlturaNatural, speed);
				this.transform.localPosition = new Vector3 (pAtual.x, pY, pAtual.z);

				if (NumberUtils.IsWithin(pAtual.y, m_AlturaNatural - curveAbroad, m_AlturaNatural + curveAbroad)) {
					m_MoverParaPosicao = false;
				}

			}

		}


		public void LancarPoder() {

			//TODO Aplicar logica de poder

			this.m_Animator.SetTrigger (animPower);

		}

		public void Mover( Direcao direcao ) {

			if (direcao != Direcao.FRENTE && direcao != Direcao.NENHUM) {

				var dir = (int)direcao;
				var newSX = Mathf.Abs (this.transform.localScale.x) * dir;
				var toScale = new Vector3 (newSX, this.transform.localScale.y);

				if ((direcao == Direcao.DIREITA && canMoveRight) || (direcao == Direcao.ESQUERDA && canMoveLeft))
					this.transform.Translate (m_Velocidade * Time.deltaTime * dir, 0f, 0f);
				
				this.m_Corpo.localScale = toScale;

			} else if (direcao == Direcao.FRENTE) {

				this.m_Animator.SetBool (animWalk, true);

			} else {

				this.m_Animator.SetBool (animWalk, false);

			}
				
		}

	}

}