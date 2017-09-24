using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Models {

	public class Formula {
		
		bool is_enunciado;
		int numero_questao;
		string formula;
		int numero_resposta = 0;

		bool is_correta = false;

		private ChartModel chartModel;

		public Formula (int numero_questao, string formula) {
			this.is_enunciado = true;
			this.numero_questao = numero_questao;
			this.formula = formula;
			this.chartModel = new ChartModel (this.formula);
		}

		public Formula (int numero_questao, string formula, int numero_resposta) {
			this.is_enunciado = false;
			this.numero_questao = numero_questao;
			this.formula = formula;
			this.numero_resposta = numero_resposta;
			this.chartModel = new ChartModel (this.formula);
		}

		public Formula (int numero_questao, string formula, int numero_resposta, bool is_correta) {
			this.is_enunciado = false;
			this.numero_questao = numero_questao;
			this.formula = formula;
			this.numero_resposta = numero_resposta;
			this.chartModel = new ChartModel (this.formula);
			this.is_correta = is_correta;
		}

		public bool IsCorreta() {
			return this.is_correta;
		}

		public int GetNumeroQuestao() {
			return this.numero_questao;
		}

		public int GetNumeroResposta() {
			return this.numero_resposta;
		}

		public string GetUrl() {
			return this.chartModel.GetUrl ();
		}

		public string GetFileName() {
			if (is_enunciado) {
				return Formula.GetFileName (numero_questao);
			} else {
				return Formula.GetFileName (numero_questao, numero_resposta);
			}
		}

		public string GetCorrectFileName() {
			return Formula.GetCorrectFileName (numero_questao);
		}

		public static string GetFileName(int numero_questao) {
			return string.Format("enum_{0}", numero_questao);
		}

		public static string GetCorrectFileName(int numero_questao) {
			return string.Format("correct_{0}", numero_questao);
		}

		public static string GetFileName(int numero_questao, int numero_resposta) {
			return string.Format("resp_{0}_{1}", numero_questao, numero_resposta);
		}

	}

}