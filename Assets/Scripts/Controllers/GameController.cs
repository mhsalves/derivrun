using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public EquationsResources equationsResources;
	public EquationsArea equationsArea;

	// Use this for initialization
	void Start () {

		var data = equationsResources.SelecionarDataAleatoria ();
		equationsArea.Carregar (data);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PauseGame() {
		Time.timeScale = 0.0f;
	}

	public void ResumeGame() {
		Time.timeScale = 1.0f;
	}

}
