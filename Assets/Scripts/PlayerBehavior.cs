using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {
	
	private float passo = 1f;

	public MovementDirection movementDir = MovementDirection.FRENTE;
	public bool podeMoverPraDireita = true;
	public bool podeMoverPraEsquerda = true;
	public bool podeDarPasso = true;

	private static string animWalk = "Correr";
	private static string animPower = "Poder";
	private static string animJump = "Jump";

	[System.Serializable]
	public enum MovementDirection
	{
		DIREITA, ESQUERDA, FRENTE
	}

	private Animator animator;

	// Use this for initialization
	void Start () {
		this.animator = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void LancarPoder() {

		//TODO lancar objeto "Poder"

		this.animator.SetTrigger (PlayerBehavior.animPower);

	}

	public void PassoDir() {
		if (podeDarPasso) {
			podeDarPasso = false;
			this.movementDir = MovementDirection.DIREITA;
			this.podeMoverPraEsquerda = true;
			this.animator.SetTrigger (PlayerBehavior.animJump);
		}
	}

	public void PassoEsq() {
		if (podeDarPasso) {
			podeDarPasso = false;
			this.movementDir = MovementDirection.ESQUERDA;
			this.podeMoverPraDireita = true;
			this.animator.SetTrigger (PlayerBehavior.animJump);
		}
	}

	public void LiberarPasso() {
		podeDarPasso = true;
	}

	public void PularProLado( int fracao ) {

		if (movementDir != MovementDirection.FRENTE) {
			
			var dir = (movementDir == MovementDirection.DIREITA) ? 1f : -1f;
			var newSX = Mathf.Abs (this.transform.localScale.x) * dir;
			var toScale = new Vector3 (newSX, this.transform.localScale.y);

			print (movementDir);

			if (
				(movementDir == MovementDirection.DIREITA && podeMoverPraDireita) ||
				(movementDir == MovementDirection.ESQUERDA && podeMoverPraEsquerda)) {

				this.transform.Translate (passo / fracao * dir, 0f, 0f);
				this.transform.localScale = toScale;
			}

		}
	}

	public void Andar() {
		this.animator.SetBool (PlayerBehavior.animWalk, true);
	}

	public void Parar() {
		this.animator.SetBool (PlayerBehavior.animWalk, false);
	}



	void OnTriggerEnter2D(Collider2D other){
		
		if (other.tag == "LimitSide") {
			
			var lsb = other.GetComponent<LimitSideBehavior> ();

			if (!lsb.toDireita) {
				podeMoverPraDireita = false;
			} else {
				podeMoverPraEsquerda = false;
			}

		}

	}

}
