﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Managers;
using Controladores;

namespace DownloadManager {
	
	public class DownloadController : MonoBehaviour {
		
		[SerializeField] private DownloadFeedback m_DownloadFeedback;
		[SerializeField] private InitialController m_InitialController;

		public List<Question> questions = new List<Question>();
		public List<Question.DownloadItem> downloadItems = new List<Question.DownloadItem>();

		private DownloadManager m_DownloadManager;

		void Start() {
			this.questions = StorageManager.LoadJSON ();
			StorageManager.SaveFileQuantity (this.questions.Count);

			foreach (Question question in this.questions) {
				this.downloadItems.AddRange (question.GetDownloadItemList ());
			}
				
			this.m_DownloadFeedback.Init (this.downloadItems.Count);

			IniciarDownloads ();
		}

		private void IniciarDownloads() {

			Question.DownloadItem downloadItemAtual = this.downloadItems [this.m_DownloadFeedback.counter];

			if (StorageManager.CheckFileEquation (downloadItemAtual.filename) 
				&& !StorageManager.ReadConfigData()) {
				if (!m_DownloadFeedback.Pular ()) {
					IniciarDownloads ();
				} else {
					m_InitialController.Ativar ();
					StorageManager.ChangeConfigData ();
				}
			} else {
				DownloadManager.DownloadCallback callback = (www) => {
					StorageManager.SaveDownloadedEquation (www, downloadItemAtual.filename);
					if (downloadItemAtual.correta) {
						StorageManager.SaveFileEquationData (downloadItemAtual);
					}

					if (!m_DownloadFeedback.Somar ()) {
						IniciarDownloads ();
					} else {
						m_InitialController.Ativar ();
						StorageManager.ChangeConfigData ();
					}
				};
				DownloadManager.Download (downloadItemAtual.chartModel.GetUrl (), callback);
			}
		}

	}
		
}