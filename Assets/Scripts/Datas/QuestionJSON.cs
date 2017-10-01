using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ComponentModels;

[System.Serializable]
public class QuestionJSON {

	public int id;
	public string enunciado;
	public string resposta_1;
	public string resposta_2;
	public string resposta_3;
	public string resposta_4;

	public enum RespostaCorreta : int {
		A = 0, B = 1, C = 2, D = 3
	}

	public RespostaCorreta respostaCorreta;

	public static QuestionJSON CreateFromJSON (string jsonString) {
		return JsonUtility.FromJson<QuestionJSON> (jsonString);
	}

	public class List {

		public List<QuestionJSON> items;

		public static List CreateFromJSON (string jsonString) {
			return JsonUtility.FromJson<List> (jsonString);
		}

		public List () {
			items = new List<QuestionJSON>();
		}

		public List<Question> GetListQuestion () {
			List<Question> list = new List<Question> ();

			foreach (QuestionJSON qJSON in this.items) {
				list.Add (new Question(qJSON));
			}

			return list;
		}

	}



}
