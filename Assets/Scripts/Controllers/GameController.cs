using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public EquationsResources equationsResources;
	public EquationsArea equationsArea;

	public ScreenController screenController;
	private LifeController lifeController;

	private static int maxQuestions = 10;
	private static int minQuestions = 1;

	public Text tQuestion;
	public int nQuestion = GameController.minQuestions;
	public Text tScore;
	public int nScore = 0;
	public Text tLifes;


	// Use this for initialization
	void Start () {

		this.lifeController = GameObject.Find ("LifeController").GetComponent<LifeController> ();

		var data = equationsResources.SelecionarDataAleatoria ();
		equationsArea.Carregar (data);

		tQuestion.text = "" + nQuestion;
		tScore.text = "" + nScore;
		tLifes.text = "" + this.lifeController.GetVidas ();

	}
	
	// Update is called once per frame
	void Update () {



	}

	private void Pontuar() {
		nScore++;
		tScore.text = "" + nScore;
	}

	private bool NextQuestion() {
	
		nQuestion++;
		if (nQuestion > maxQuestions) {
			return true; //Acabou !
		} else {
			tQuestion.text = "" + nQuestion;

			var data = equationsResources.SelecionarDataAleatoria ();
			equationsArea.Carregar (data);

			return false; //Ainda não acabou
		}
	}

	private void PerderVida(){

		var p = lifeController.PerderVida ();

		if (p) {
			this.EndGame ();

		} else {
			tLifes.text = "" + this.lifeController.GetVidas ();

		}

	}

	public void PauseGame() {
		Time.timeScale = 0.0f;
	}

	public void ResumeGame() {
		Time.timeScale = 1.0f;
	}

	public void EndGame() {
		screenController.AbrirEnd ();
	}

}
