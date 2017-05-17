using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLaunchBehaviour : MonoBehaviour {

	[SerializeField] private ArrowLaunchBehaviour m_Twin;
	[SerializeField] private float m_Forca;

	private Collider2D m_OwnCollider;

	void Awake () {
		this.m_OwnCollider = GetComponent<Collider2D> ();

	}

	void OnTriggerEnter2D ( Collider2D other ) {

		if (other.tag == "Player") {
			this.AplicarEmpurrao ( other.gameObject );
			this.m_Twin.Desabilitar ();
			this.Desabilitar ();
		}

	}

	private void AplicarEmpurrao( GameObject player ) {
		var rgd2d = player.GetComponent<Rigidbody2D> ();
		rgd2d.AddForce(new Vector2 (m_Forca, 0f));
	}

	public void Desabilitar() {
		this.m_OwnCollider.enabled = false;
	}

}
