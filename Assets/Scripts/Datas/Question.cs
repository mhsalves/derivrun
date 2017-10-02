using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

public class Question {

	public static readonly int MULTIPLY_COUNT = 5;

	public int id;
	public string enunciado;
	public string resposta_1;
	public string resposta_2;
	public string resposta_3;
	public string resposta_4;

	public int respostaCorreta;

	public Question (QuestionJSON questionJSON) {
		this.id = questionJSON.id;
		this.enunciado = questionJSON.enunciado;
		this.resposta_1 = questionJSON.resposta_1;
		this.resposta_2 = questionJSON.resposta_2;
		this.resposta_3 = questionJSON.resposta_3;
		this.resposta_4 = questionJSON.resposta_4;
		this.respostaCorreta = (int) questionJSON.respostaCorreta;
	}

	private static readonly string ExtensionImage = ".png";

	public string GetEnunciadoFileName() {
		return string.Format("enun_{0}{1}", this.id, ExtensionImage);
	}

	public string GetRespostaFileName(int numero) {
		return string.Format("resp_{0}_{1}{2}", this.id, numero, ExtensionImage);
	}

	public string GetCorretaFileName() {
		return string.Format("correta_{0}", this.id);
	}

	public static string GetEnunciadoFileName(int id) {
		return string.Format("enun_{0}{1}", id, ExtensionImage);
	}

	public static string GetRespostaFileName(int id, int numero) {
		return string.Format("resp_{0}_{1}{2}", id, numero, ExtensionImage);
	}

	public static string GetCorretaFileName(int id) {
		return string.Format("correta_{0}", id);
	}

	private ChartModel GetChartEnunciado () {
		return new ChartModel (this.enunciado);
	}

	private ChartModel GetChartResposta1 () {
		return new ChartModel (this.resposta_1);
	}

	private ChartModel GetChartResposta2 () {
		return new ChartModel (this.resposta_2);
	}

	private ChartModel GetChartResposta3 () {
		return new ChartModel (this.resposta_3);
	}

	private ChartModel GetChartResposta4 () {
		return new ChartModel (this.resposta_4);
	}

	public List<DownloadItem> GetDownloadItemList() {
		List<DownloadItem> list = new List<DownloadItem> ();
		list.Add(new DownloadItem(this.enunciado, true, this.GetEnunciadoFileName(), this.GetChartEnunciado()));
		list.Add(new DownloadItem(this.resposta_1, false, this.GetRespostaFileName(0), this.GetChartResposta1(), 0, (this.respostaCorreta == 0), this.GetCorretaFileName()));
		list.Add(new DownloadItem(this.resposta_2, false, this.GetRespostaFileName(1), this.GetChartResposta2(), 1, (this.respostaCorreta == 1), this.GetCorretaFileName()));
		list.Add(new DownloadItem(this.resposta_3, false, this.GetRespostaFileName(2), this.GetChartResposta3(), 2, (this.respostaCorreta == 2), this.GetCorretaFileName()));
		list.Add(new DownloadItem(this.resposta_4, false, this.GetRespostaFileName(3), this.GetChartResposta4(), 3, (this.respostaCorreta == 3), this.GetCorretaFileName()));

		return list;
	}

	public struct DownloadItem {
		public string formula;
		public bool enunciado;
		public string filename;
		public ChartModel chartModel;

		public int numero_resposta;
		public bool correta;
		public string filenameCorreta;

		public DownloadItem( string formula, bool enunciado, string filename, ChartModel chartModel) {
			this.formula = formula;
			this.enunciado = enunciado;
			this.filename = filename;
			this.chartModel = chartModel;
			this.numero_resposta = 0;
			this.correta = false;
			this.filenameCorreta = "";
		}

		public DownloadItem( string formula, bool enunciado, string filename, ChartModel chartModel, int numero_resposta, bool correta, string filenameCorreta ) {
			this.formula = formula;
			this.enunciado = enunciado;
			this.filename = filename;
			this.chartModel = chartModel;
			this.numero_resposta = numero_resposta;
			this.correta = correta;
			this.filenameCorreta = filenameCorreta;
		}
	}

}
