using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndController : MonoBehaviour {

	private ResultsController resultsController;

	public Text tAproveitamento;
	public Text tVidas;
	public Text tAcertos;

	// Use this for initialization
	void Start () {
		this.resultsController = GameObject.Find ("ResultsController").GetComponent<ResultsController> ();
		this.AtualizarDados ();
	}

	private void AtualizarDados() {
		
		var v = resultsController.GetVidasLabel ();
		var a = resultsController.GetAcertosLabel ();
		var ap = resultsController.GetAproveitamento ();

		this.tAproveitamento.text = ap;
		this.tVidas.text = v;
		this.tAcertos.text = a;


	}

	public void KillLifeController() {
		var g = GameObject.Find ("LifeController");
		Destroy (g);
	}

	public void KillResultsController() {
		var g = GameObject.Find ("ResultsController");
		Destroy (g);
	}

	public void ResetarLifeController() {
		var lf = GameObject.Find ("LifeController").GetComponent<LifeController> ();
		lf.IniciarCom (lf.GetVidas ());
	}
}
