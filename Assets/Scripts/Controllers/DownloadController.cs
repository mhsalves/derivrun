using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Managers;
using Models;

namespace DownloadManager {
	
	public class DownloadController : MonoBehaviour {
		
		[SerializeField] private DownloadFeedback m_DownloadFeedback;

		public List<Formula> formulas = new List<Formula>();
		public List<Texture> textures = new List<Texture>();

		private DownloadManager m_DownloadManager;

		void Start() {

			//TODO: Selecionar formulas aqui.
			this.formulas = GetBaseList();

			this.m_DownloadFeedback.Init (formulas.Count);

			IniciarDownloads ();
		}

		private void IniciarDownloads() {
			
			Formula formula = this.formulas [this.m_DownloadFeedback.counter];
			Debug.Log (formula.GetUrl());

			DownloadManager.DownloadCallback callback = (www) => {
				textures.Add (www.texture);
				StorageManager.SaveDownloadedEquation(www, formula);

				if (!m_DownloadFeedback.Somar()) {
					IniciarDownloads ();
				} else {
					print ("Download completo");
				}
			};
			DownloadManager.Download (formula.GetUrl(), callback);

		}

		public static List<Formula> GetBaseList() {
			
			List<Formula> list = new List<Formula> ();

			list.Add (new Formula (1, @"\displaystyle\int_{-\infty}^{\infty}e^{-x^{2}}\;dx=\sqrt{\pi}"));
			list.Add (new Formula (1, @"\displaystyle\int_{-\infty}^{\infty}e^{-x^{2}}\;dx=\sqrt{\pi}", 1));
			list.Add (new Formula (1, @"\displaystyle\int_{-\infty}^{\infty}e^{-x^{2}}\;dx=\sqrt{\pi}", 2, true));
			list.Add (new Formula (1, @"\displaystyle\int_{-\infty}^{\infty}e^{-x^{2}}\;dx=\sqrt{\pi}", 3));
			list.Add (new Formula (1, @"\displaystyle\int_{-\infty}^{\infty}e^{-x^{2}}\;dx=\sqrt{\pi}", 4));

			return list;
		}

	}
		
}