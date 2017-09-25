using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MyClass {

	public bool correta;
	public bool enunciado;
	public string formula;
	public int numero_questao;
	public int numero_resposta;

	public static MyClass CreateFromJSON (string jsonString) {
		return JsonUtility.FromJson<MyClass> (jsonString);
	}

}

[System.Serializable]
public class MyClassList {

	public List<MyClass> items;

	public static MyClassList CreateFromJSON (string jsonString) {
		return JsonUtility.FromJson<MyClassList> (jsonString);
	}

	public MyClassList() {
		items = new List<MyClass> ();
	}

}
