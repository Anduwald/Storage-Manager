namespace SharedClassLib.Data
{
	//Settings for the app
	public static class AppState
	{
		public static int RemberPage { get; set; } = 1;
			    
		public static int MinSize { get; } = 1;
		public static int MaxSize { get; } = 10_000;
			    
		public static int MinPressure { get; } = 1;
		public static int MaxPressure { get; } = 10_000;
			    
		public static double MinPrice { get; } = 1;
		public static double MaxPrice { get; } = 20_000_000_000;
	}
}
