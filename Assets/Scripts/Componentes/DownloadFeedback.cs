using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DownloadManager {
	
	public class DownloadFeedback : MonoBehaviour {

		private static readonly string S_Downloading = "Downloading...";
		private static readonly string S_Downloaded = "Downloaded !";

		private int _counter = 0;
		public int counter {
			get { return _counter; }
		}
		public int max {
			get { 
				return (int) m_Slider.maxValue;
			}
		}

		[SerializeField] private Text m_Text;
		[SerializeField] private Slider m_Slider;

		public void Init(int max) {
			this._counter = 0;
			this.m_Slider.maxValue = max;
			this.UpdateView ();
		}

		public bool Somar() {
			_counter++;
			this.UpdateView ();
			return (_counter == max);
		}

		private void UpdateView () {
			m_Slider.value = _counter;
			m_Text.text = 
				(_counter == max) ? 
				DownloadFeedback.S_Downloaded : 
				DownloadFeedback.S_Downloading + string.Format("({0}/{1})", _counter, max);
		}

	}

}
