using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (PlayerBehavior))]
public class PlayerUserControlBehavior : MonoBehaviour {

	private PlayerBehavior mPlayerBehavior;

	private PlayerBehavior.Direcao mAndarNaDirecao;

	void Awake () {
		this.mPlayerBehavior = GetComponent<PlayerBehavior> ();
	
	}

	public void AcionarParaDireita() {
		this.mAndarNaDirecao = PlayerBehavior.Direcao.DIREITA;
	}

	public void AcionarParaEsquerda() {
		this.mAndarNaDirecao = PlayerBehavior.Direcao.ESQUERDA;
	}

	public void AcionarParaFrente() {
		this.mAndarNaDirecao = PlayerBehavior.Direcao.FRENTE;
	}

	void FixedUpdate() {

		mPlayerBehavior.Mover (mAndarNaDirecao);

	}

}
