namespace SharedClassLib.Data
{
	public class FileManager
	{
		private static string programFolderPath = AppDomain.CurrentDomain.BaseDirectory;
		private static string fileName = "AppData";


		public static void SaveData(string dataJson)
		{
			string filePath = System.IO.Path.Combine(programFolderPath, $"{fileName}.json");

			SaveData(filePath, dataJson);
		}
		public static void SaveData(string filePath, string dataJson)
		{
			// write the serialized data to the file
			using FileStream stream = new(filePath, FileMode.Create);
			using StreamWriter writer = new(stream);
			writer.Write(dataJson);
		}

		public static string LoadData()
		{
			string filePath = System.IO.Path.Combine(programFolderPath, $"{fileName}.json");

			return LoadData(filePath);
		}
		public static string LoadData(string filePath)
		{
			if (File.Exists(filePath))
			{
				// load the serialized data from the file
				string dataToLoad = "";
				using (FileStream stream = new(filePath, FileMode.Open))
				{
					using StreamReader reader = new(stream);
					dataToLoad = reader.ReadToEnd();
				}

				return dataToLoad;
			}
			return "";
		}
	}
}
