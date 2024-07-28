using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
using SharedLib.Data;
using SharedLib;

namespace StorageManager
{
	public partial class Form1 : Form
	{
		private IServiceProvider serviceProvider;
		public Form1()
		{
			InitializeComponent();

			var services = new ServiceCollection();
			services.AddWindowsFormsBlazorWebView();

			string jsonString = FileManager.LoadData();
			DataController dataController = new DataController();

			dataController.ImportDataFromJson(jsonString);
			dataController.ShowDialogFolderRef = SelectFolderWindow;
			dataController.ShowDialogFileRef = SelectFileWindow;

			services.AddSingleton(dataController);

			blazorWebView1.HostPage = "wwwroot\\index.html";
			blazorWebView1.Services = services.BuildServiceProvider();
			blazorWebView1.RootComponents.Add<App>("#app");

			serviceProvider = blazorWebView1.Services;
		}
		public string SelectFolderWindow()
		{
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				return saveFileDialog1.FileName;
			}
			return "";
		}

		public string SelectFileWindow()
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				return openFileDialog1.FileName;
			}
			return "";
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			DataController _dataController = serviceProvider.GetService<DataController>();
			string jsonString = _dataController.ExportDataToJson();
			FileManager.SaveData(jsonString);
		}
	}
}
