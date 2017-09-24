using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Models;

namespace Managers {
	
	public class StorageManager : MonoBehaviour {

		public readonly static string PATH_Equations = Application.persistentDataPath + "/equations/";

		public static void SaveDownloadedEquation(WWW objSERVER, Formula formula) 
		{
			if (!Directory.Exists(PATH_Equations)) 
				Directory.CreateDirectory(PATH_Equations);

			byte[] bytes = objSERVER.bytes;

			File.WriteAllBytes(PATH_Equations + formula.GetFileName() , bytes);

			if (formula.IsCorreta()) {
				SaveFileEquationData (formula);
			}
		}

		public static void SaveFileEquationData(Formula formula) {
			if (!Directory.Exists(PATH_Equations)) 
				Directory.CreateDirectory(PATH_Equations);

			string text = string.Format("{0}", formula.GetNumeroResposta());

			File.WriteAllText (PATH_Equations + formula.GetCorrectFileName (), text);
		}

		public static void ReadEquations(int number) {
			
		}

	}

}