namespace SharedLib.Data
{
	//Settings for the application
	public static class AppState
	{
		public static int RemberPage { get; set; } = 1;

		public static List<string> CountryList { get; } = new() { "Ukraine", "USA", "Russia", "India" , "Brazil", "Japan", "Sweden", "Spain", "Germany", "UK", "China", "France" };

		public static int MinSize { get; } = 1;
		public static int MaxSize { get; } = 10_000;

		public static int MinDisplacement { get; } = 1;
		public static int MaxDisplacement { get; } = 100_000;

		public static int MinDepth { get; } = 1;
		public static int MaxDepth { get; } = 1_000;		

		public static List<string> EngineTypeList { get; } = new() { "Nuclear reactor", "Diesel-electric", "Air-Independent Propulsion Systems", "Diesel-electric with air-independent propulsion", "Turbine Engines", "Electric Motors", "Hybrid Propulsion Systems" };

		public static int MinUnderwaterTime { get; } = 1;
		public static int MaxUnderwaterTime { get; } = 365;

		public static double MinPrice { get; } = 1;
		public static double MaxPrice { get; } = 20_000_000_000;
	}
}
