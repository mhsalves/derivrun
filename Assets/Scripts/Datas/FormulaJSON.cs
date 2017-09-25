using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;

[System.Serializable]
public class FormulaJSON {

	public bool correta;
	public bool enunciado;
	public string formula;
	public int numero_questao;
	public int numero_resposta;

	public static FormulaJSON CreateFromJSON (string jsonString) {
		return JsonUtility.FromJson<FormulaJSON> (jsonString);
	}

	public Formula GetFormulaModel () {

		Formula formula_obj = (this.enunciado) 
			? new Formula (numero_questao, formula)
			: new Formula (numero_questao, formula, numero_resposta, correta);
		
		return formula_obj;
	}

	public class List {

		public List<FormulaJSON> items;

		public static List CreateFromJSON (string jsonString) {
			return JsonUtility.FromJson<List> (jsonString);
		}

		public List() {
			items = new List<FormulaJSON> ();
		}

		public List<Formula> GetListFormula () {
			List<Formula> list = new List<Formula> ();
			foreach (FormulaJSON fj in this.items) {
				list.Add (fj.GetFormulaModel ());
			}
			return list;
		}

	}



}
