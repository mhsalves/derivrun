using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Models;
using InformacoesEstaticas;

namespace Managers {
	
	public class StorageManager : MonoBehaviour {

		public readonly static string PATH_Equations = Application.persistentDataPath + "/equations/";

		public static void SaveDownloadedEquation(WWW objSERVER, Formula formula) 
		{
			if (!Directory.Exists(PATH_Equations)) 
				Directory.CreateDirectory(PATH_Equations);

			byte[] bytes = objSERVER.texture.EncodeToPNG();

			File.WriteAllBytes(PATH_Equations + formula.GetFileName(), bytes);

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

		public static Question ReadEquation (int number) {

			print (PATH_Equations + Formula.GetFileName (number));

			byte[] e = File.ReadAllBytes(PATH_Equations + Formula.GetFileName (number));
			byte[] r1 = File.ReadAllBytes(PATH_Equations + Formula.GetFileName (number, 1));
			byte[] r2 = File.ReadAllBytes(PATH_Equations + Formula.GetFileName (number, 2));
			byte[] r3 = File.ReadAllBytes(PATH_Equations + Formula.GetFileName (number, 3));
			byte[] r4 = File.ReadAllBytes(PATH_Equations + Formula.GetFileName (number, 4));

			string correta = File.ReadAllText (PATH_Equations + Formula.GetCorrectFileName (number));

			return new Question (e, r1, r2, r3, r4, correta);

		}

	}

}