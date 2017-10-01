using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using InformacoesEstaticas;
using UnityEngine.Networking;

namespace Managers {
	
	public class StorageManager : MonoBehaviour {

		public readonly static string PATH_Equations = Application.persistentDataPath + "/equations/";
		public readonly static string PATH_Resources = Application.dataPath +  "/Resources/";
		public readonly static string FILENAME_Quantity = "quantity";

		public static void SaveDownloadedEquation(DownloadHandlerTexture textD, string filename) 
		{
			if (!Directory.Exists(PATH_Equations)) 
				Directory.CreateDirectory(PATH_Equations);

			byte[] bytes = textD.data;

			File.WriteAllBytes(PATH_Equations + filename, bytes);

		}

		public static void SaveFileEquationData(Question.DownloadItem dItem) {
			if (!Directory.Exists(PATH_Equations)) 
				Directory.CreateDirectory(PATH_Equations);

			string text = string.Format("{0}", dItem.numero_resposta);

			File.WriteAllText (PATH_Equations + dItem.filenameCorreta, text);
		}

		public static void SaveFileQuantity(int quantity) {
			if (!Directory.Exists(PATH_Equations)) 
				Directory.CreateDirectory(PATH_Equations);
			
			string text = string.Format("{0}", quantity);

			File.WriteAllText (PATH_Equations + FILENAME_Quantity, text);
		}

		public static int ReadQuantity () {
			string quantity_string = File.ReadAllText (PATH_Equations + FILENAME_Quantity);
			int quantity = int.Parse(quantity_string);

			return quantity;
		}

		public static QuestionInterface ReadEquation (int id) {
			
			byte[] e = File.ReadAllBytes(PATH_Equations + Question.GetEnunciadoFileName(id));
			byte[] r1 = File.ReadAllBytes(PATH_Equations + Question.GetRespostaFileName(id, 0));
			byte[] r2 = File.ReadAllBytes(PATH_Equations + Question.GetRespostaFileName(id, 1));
			byte[] r3 = File.ReadAllBytes(PATH_Equations + Question.GetRespostaFileName(id, 2));
			byte[] r4 = File.ReadAllBytes(PATH_Equations + Question.GetRespostaFileName(id, 3));

			string correta = File.ReadAllText (PATH_Equations + Question.GetCorretaFileName(id));

			return new QuestionInterface (e, r1, r2, r3, r4, correta);

		}

		public static bool ReadConfigData() {
			string filename = "configdata";
			string text = LoadResourceTextfile (filename);
			int flag = int.Parse (text);
			return (flag == 1);
		}

		public static void ChangeConfigData () {
			string filename = "configdata.json";
			File.WriteAllText(PATH_Resources + filename, "0");
			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();
		}

		public static bool CheckFileEquation(string filename) {
			return File.Exists (PATH_Equations + filename);
		}

		public static List<Question> LoadJSON () {
			string filename = "questoes";

			string text = LoadResourceTextfile (filename);

			QuestionJSON.List list = QuestionJSON.List.CreateFromJSON (text);
			return list.GetListQuestion ();
		}

		public static string LoadResourceTextfile(string path)
		{
			TextAsset targetFile = Resources.Load<TextAsset>(path);
			return targetFile.text;
		}

	}

}