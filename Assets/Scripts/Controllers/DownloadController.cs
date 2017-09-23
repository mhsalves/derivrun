using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DownloadManager {
	
	public class DownloadController : MonoBehaviour {
		
		[SerializeField] private DownloadFeedback m_DownloadFeedback;

		string[] formulas = { 
			@"\displaystyle\int_{-\infty}^{\infty}e^{-x^{2}}\;dx=\sqrt{\pi}",
			@"\displaystyle\int_{-\infty}^{\infty}e^{-x^{3}}\;dx=\sqrt{\pi}",
			@"\displaystyle\int_{-\infty}^{\infty}e^{-x^{4}}\;dx=\sqrt{\pi}",
			@"\displaystyle\int_{-\infty}^{\infty}e^{-x^{5}}\;dx=\sqrt{\pi}",
			@"\displaystyle\int_{-\infty}^{\infty}e^{-x^{6}}\;dx=\sqrt{\pi}"
		};

		public List<ChartModel> charts = new List<ChartModel>();
		public List<Texture> textures = new List<Texture>();

		private DownloadManager m_DownloadManager;

		void Start() {

			//TODO: Selecionar formulas aqui.

			this.m_DownloadFeedback.Init (formulas.Length);

			charts.Clear ();
			foreach (string formula in formulas) {
				charts.Add(new ChartModel(formula));
			}

			IniciarDownloads ();
		}

		private void IniciarDownloads() {

			string url = charts [this.m_DownloadFeedback.counter].GetUrl ();
			Debug.Log (url);
			DownloadManager.DownloadCallback callback = (www) => {
				textures.Add (www.texture);
				//TODO: Salvar texture aqui.

				if (!m_DownloadFeedback.Somar()) {
					IniciarDownloads ();
				} else {
					print ("Download completo");
				}
			};
			DownloadManager.Download (url, callback);

		}

	}

}