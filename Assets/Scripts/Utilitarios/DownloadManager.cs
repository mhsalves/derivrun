using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

namespace DownloadManager {

	public class DownloadManager : MonoBehaviour
	{
		private class Downloadable
		{
			public string url { get; set; }

			public DownloadCallback fn { get; set; }

			public Downloadable (string url, DownloadCallback fn)
			{
				this.url = url;
				this.fn = fn;
			}
		}

		private WWW wwwData;

		public delegate void DownloadCallback (WWW wwwData);

		private static DownloadManager instance = null;
		private static Queue<Downloadable> queue;

		// Use this for initialization
		void Start ()
		{
			if (DownloadManager.instance == null) {
				DownloadManager.instance = FindObjectOfType (typeof(DownloadManager)) as DownloadManager;
			}
			queue = new Queue<Downloadable> ();
		}

		void FixedUpdate ()
		{
			if (queue.Count == 0 || (wwwData != null && wwwData.isDone == false)) {
				return;
			}
			StartCoroutine ("StartDownload");
			//StartDownload();
		}

		void OnApplicationQuit ()
		{
			DownloadManager.instance = null;
		}

		private IEnumerator OnDownload (Downloadable toDownload)
		{
			wwwData = new WWW (toDownload.url);
			yield return wwwData;
		}

		private IEnumerator StartDownload ()
		{
			Downloadable toDownload = queue.Dequeue ();
			yield return StartCoroutine ("OnDownload", toDownload);
			Debug.Log ("downloaded: " + toDownload.url);
			toDownload.fn (wwwData);
		}

		public static void Download (string sURL, DownloadCallback fn)
		{
			queue.Enqueue (new Downloadable (sURL, fn));
		}
	}	

}