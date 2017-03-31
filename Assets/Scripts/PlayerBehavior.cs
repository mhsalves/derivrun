using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

	public float speed;
	private static string animWalk = "Walk";
	private static string animPower = "Power";
	private static string animJump = "Jump";

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

	public void PularProLado( bool toDir ) {

		//TODO Mudar Posição pra direira ou esquerda
		var newX = (toDir) ? Mathf.Abs (this.transform.localScale.x) : -Mathf.Abs (this.transform.localScale.x);
		var toScale = new Vector3 ( newX, this.transform.localScale.y);

		this.transform.localScale = toScale;
		this.animator.SetTrigger (PlayerBehavior.animJump);

	}

	public void Andar() {
		this.animator.SetBool (PlayerBehavior.animWalk, true);
	}

	public void Parar() {
		this.animator.SetBool (PlayerBehavior.animWalk, false);
	}
}
