using System.Text.Json;

namespace SharedLib.Data
{
	public class DataController
	{
		private List<Submarine> submarines = new();

		//Delegate for opening Winform Modal windows from Blazor
		public Func<string> ShowDialogFolderRef = () => { return ""; };
		public Func<string> ShowDialogFileRef = () => { return ""; };

		public List<Submarine> Submarines
		{
			get { return submarines; }
			set { submarines = value; }
		}

		public int ImageIdCount { get; set; } = 0;

		public void IncreaseImageIdCount()
		{
			ImageIdCount++;
		}

		private void UpdateSubmarinesId()
		{
			for (int i = 0; i < submarines.Count; i++)
			{
				submarines[i].Id = i;
			}
		}

		public void AddSubmarine(Submarine submarine)
		{
			submarines.Add(submarine);
			UpdateSubmarinesId();
		}

		public void DeleteSubmarine(int Id)
		{
			int index = submarines.FindIndex(e => e.Id == Id);

			if (index == -1) return;

			FileManager.DeleteImage(submarines[index].ImageId);
			submarines.RemoveAt(index);
			UpdateSubmarinesId();
		}

		public void UpdateSubmarine(int Id, Submarine submarine)
		{
			int index = submarines.FindIndex(e => e.Id == Id);

			if (index == -1) return;

			submarines[index] = new(submarine);
		}

		public bool ImportDataFromJson(string jsonString)
		{
			if (jsonString == null || jsonString == "") return false;

			DataController temp;

			try
			{
				temp = JsonSerializer.Deserialize<DataController>(jsonString);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}

			if (temp == null) return false;

			this.submarines = temp.Submarines;
			this.ImageIdCount = temp.ImageIdCount;
			return true;
		}

		public string ExportDataToJson()
		{
			return JsonSerializer.Serialize(this);
		}

		public string SelectFolder()
		{
			return ShowDialogFolderRef();
		}

		public string SelectFile()
		{
			return ShowDialogFileRef();
		}
	}

	public abstract class Product
	{
		protected int id;
		protected double price;
		protected string name;

		protected Product()
		{
			this.price = 0;
			this.name = "";
			this.id = -1;
		}

		public Product(double price, string name)
		{
			this.price = price;
			this.name = name;
		}

		protected Product(Product product)
		{
			this.price = product.price;
			this.name = product.name;
			this.id = product.id;
		}

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		public double Price
		{
			get { return price; }
			set { price = value; }
		}

		public string Name
		{
			get { return name; }
			set { name = value; }
		}
	}

	public class Submarine : Product
	{
		private int imageid;
		private string country;
		private float length;
		private float width;
		private float displacement;
		private float depth;
		private string engineType;
		private string armament;
		private float underwaterTime;

		public Submarine() : base()
		{
			imageid = -1;
			this.country = "";
			this.length = 0;
			this.width = 0;
			this.displacement = 0;
			this.depth = 0;
			this.engineType = "";
			this.armament = "";
			this.underwaterTime = 0;
		}

		public Submarine(string country, float length, float width, float displacement, float depth, string engineType, string armament, float underwaterTime, double price, string name) : base(price, name)
		{
			imageid = -1;
			this.country = country;
			this.length = length;
			this.width = width;
			this.displacement = displacement;
			this.depth = depth;
			this.engineType = engineType;
			this.armament = armament;
			this.underwaterTime = underwaterTime;
		}

		public Submarine(Submarine submarine) : base(submarine)
		{
			this.imageid = submarine.imageid;
			this.country = submarine.country;
			this.length = submarine.length;
			this.width = submarine.width;
			this.displacement = submarine.displacement;
			this.depth = submarine.depth;
			this.engineType = submarine.engineType;
			this.armament = submarine.armament;
			this.underwaterTime = submarine.underwaterTime;
			this.price = submarine.price;
			this.name = submarine.name;
			this.id = submarine.id;
		}

		public string Country
		{
			get { return this.country; }
			set { country = value; }
		}

		public float Length
		{
			get { return length; }
			set { length = value; }
		}

		public float Width
		{
			get { return width; }
			set { width = value; }
		}

		public float Displacement
		{
			get { return displacement; }
			set { displacement = value; }
		}

		public float Depth
		{
			get { return depth; }
			set { depth = value; }
		}

		public string EngineType
		{
			get { return engineType; }
			set { engineType = value; }
		}

		public string Armament
		{
			get { return armament; }
			set { armament = value; }
		}
		public float UnderwaterTime
		{
			get { return underwaterTime; }
			set { underwaterTime = value; }
		}

		public int ImageId
		{
			get { return imageid; }
			set { imageid = value; }
		}

		public string GetDataStr()
		{
			string n = "N";
			return $"Contry - {country}\n" +
				$"Length - {length} m\n" +
				$"Width - {width} m\n" +
				$"Displacment - {displacement} Tons\n" +
				$"Diving depth - {depth} m\n" +
				$"Engine type - {engineType}\n" +
				$"Armament - {armament}\n" +
				$"Underwater time - {underwaterTime}\n" +
				$"Price - {price.ToString(n)} $";
		}
	}
}
