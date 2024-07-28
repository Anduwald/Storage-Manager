namespace SharedLib.Data
{
	public static class FileManager
	{
		private static string programFolderPath = AppDomain.CurrentDomain.BaseDirectory;
		private static string fileName = "AppData";

		public static void SaveData(string dataJson)
		{
			string filePath = Path.Combine(programFolderPath, $"{fileName}.json");

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
			string filePath = Path.Combine(programFolderPath, $"{fileName}.json");

			return LoadData(filePath);
		}
		public static string LoadData(string filePath)
		{
			if (File.Exists(filePath))
			{
				string dataToLoad = "";

				try
				{
					// load the serialized data from the file
					using (FileStream stream = new(filePath, FileMode.Open))
					{
						using StreamReader reader = new(stream);
						dataToLoad = reader.ReadToEnd();
					}

				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					return "Error - " + ex.Message;
				}

				return dataToLoad;
			}
			return "File not found";
		}

		public static bool CopyImage(string filePath, int imageId)
		{
			string sourcePath = filePath;
			string destinationPath = Path.Combine(programFolderPath, "images");

			if (!Directory.Exists(destinationPath))
			{
				try
				{
					DirectoryInfo di = Directory.CreateDirectory(destinationPath);
				}
				catch (Exception e)
				{
					Console.WriteLine("The process failed: {0}", e.ToString());
					return false;
				}
			}

			if (File.Exists(filePath))
			{
				try
				{
					File.Copy(sourcePath, Path.Combine(destinationPath, $"{imageId}.png"), true);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					return false;
				}

				return true;
			}

			//Return false if "images" folder exist, but selected image wasn't found
			return false;
		}

		public static bool DeleteImage(int imageId)
		{
			string imagePath = Path.Combine(programFolderPath, $"images\\{imageId}.png");
			
			if (File.Exists(imagePath))
			{
				try
				{
					File.Delete(imagePath);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					return false;
				}

				return true;
			}

			return false;
		}
	}
}
