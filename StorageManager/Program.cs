//Kuchmambetov Artem 136 2024
//Програма призначена для зручного редагування інформації про продукт,
//а саме субмарини, що продаються в умовному інтернет магазині.
//Кожен товар має певний перелік даних, які можна переглядати і редагувати за бажанням.

namespace StorageManager
{
	internal static class Program
	{
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
		static void Main()
		{
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();
			Application.Run(new Form1());
        }
	}
}