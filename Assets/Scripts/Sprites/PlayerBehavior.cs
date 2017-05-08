using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

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
	private Animator mAnimator;

	private void Awake() {

		this.mSideLeft = transform.Find ("SideLeft");
		this.mSideRight = transform.Find ("SideRight");

		this.mAnimator = m_Corpo.GetComponent<Animator> ();
	
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

	public void ValidarPosicaoCorreta() {

		if (this.transform.localPosition.y != m_AlturaNatural) {
			Vector3 p = this.transform.localPosition;
			p.y = m_AlturaNatural;
			this.transform.localPosition = p;
		}

	}

	public void LancarPoder() {

		//TODO Aplicar logica de poder

		this.mAnimator.SetTrigger (animPower);

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

			this.mAnimator.SetBool (animWalk, true);

		} else {

			this.mAnimator.SetBool (animWalk, false);

		}
			


	}

}
