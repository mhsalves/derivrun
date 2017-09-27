using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Models;
using InformacoesEstaticas;
using UnityEngine.Networking;

namespace Managers {
	
	public class StorageManager : MonoBehaviour {

		public readonly static string PATH_Equations = Application.persistentDataPath + "/equations/";
		public readonly static string PATH_Assets = Application.dataPath + "/";

		public static void SaveDownloadedEquation(DownloadHandlerTexture textD, Formula formula) 
		{
			if (!Directory.Exists(PATH_Equations)) 
				Directory.CreateDirectory(PATH_Equations);
			
			byte[] bytes = textD.data;

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

			//print (PATH_Equations + Formula.GetFileName (number));

			byte[] e = File.ReadAllBytes(PATH_Equations + Formula.GetFileName (number));
			byte[] r1 = File.ReadAllBytes(PATH_Equations + Formula.GetFileName (number, 1));
			byte[] r2 = File.ReadAllBytes(PATH_Equations + Formula.GetFileName (number, 2));
			byte[] r3 = File.ReadAllBytes(PATH_Equations + Formula.GetFileName (number, 3));
			byte[] r4 = File.ReadAllBytes(PATH_Equations + Formula.GetFileName (number, 4));

			string correta = File.ReadAllText (PATH_Equations + Formula.GetCorrectFileName (number));

			return new Question (e, r1, r2, r3, r4, correta);

		}


		public static List<Formula> LoadJSON () {
			string filename = "file.json";
			string filePath = PATH_Assets + filename;

			if (File.Exists (filePath)) {
				string[] lines = File.ReadAllLines (filePath);
				string text = string.Join ("", lines);

				FormulaJSON.List list = FormulaJSON.List.CreateFromJSON (text);
				return list.GetListFormula ();
			}

			return new List<Formula> ();
		}

	}

}