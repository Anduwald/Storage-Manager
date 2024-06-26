using System.Text.Json;

namespace SharedClassLib.Data
{
	public class DataController
	{
		public Func<string> ShowDialogFolderRef = () => { return ""; };
		public Func<string> ShowDialogFileRef = () => { return ""; };
		private List<Submarine> submarines = new();

		public List<Submarine> Submarines
		{
			get { return submarines; }
			set { submarines = value; }
		}

		public void AddSubmarine(Submarine submarine)
		{
			submarines.Add(submarine);
			UpdateSubmarinesId();
		}

		public void DeleteSubmarine(int Id)
		{
			var itemToRemove = submarines.Single(e => e.Id == Id);
			submarines.Remove(itemToRemove);
			UpdateSubmarinesId();
		}

		public void UpdateSubmarine(int Id, Submarine submarine)
		{
			int index = submarines.FindIndex(e => e.Id == Id);

			if (index != -1)
				submarines[index] = new(submarine);
		}

		private void UpdateSubmarinesId()
		{
			for (int i = 0; i < submarines.Count; i++)
			{
				submarines[i].Id = i;
			}
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
			return true;
		}

		public string ExportDataToJson()
		{
			return JsonSerializer.Serialize(this); ;
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
		private float width;
		private float height;
		private float length;
		private float maxWaterPressure;
		private string engineType;

		public Submarine() : base()
		{
			this.width = 0;
			this.height = 0;
			this.length = 0;
			this.maxWaterPressure = 0;
			this.engineType = "";
		}

		public Submarine(float width, float height, float length, float maxWaterPressure, string engineType, double price, string name) : base(price, name)
		{
			this.width = width;
			this.height = height;
			this.length = length;
			this.maxWaterPressure = maxWaterPressure;
			this.engineType = engineType;
		}

		public Submarine(Submarine submarine) : base(submarine)
		{
			this.width = submarine.width;
			this.height = submarine.height;
			this.length = submarine.length;
			this.maxWaterPressure = submarine.maxWaterPressure;
			this.engineType = submarine.engineType;
			this.price = submarine.price;
			this.name = submarine.name;
			this.id = submarine.id;
		}
		
		public float Width
		{
			get { return width; }
			set { width = value; }
		}

		public float Height
		{
			get { return height; }
			set { height = value; }
		}

		public float Length
		{
			get { return length; }
			set { length = value; }
		}

		public float MaxWaterPressure
		{
			get { return maxWaterPressure; }
			set { maxWaterPressure = value; }
		}

		public string EngineType
		{
			get { return engineType; }
			set { engineType = value; }
		}

		public string GetDataStr()
		{
			string n = "N";
			return $"Width - {width} m\nHeight - {height} m\nLength - {length} m\nMax water pressure - {maxWaterPressure} Pa\nEngine type - {engineType}\nPrice - {price.ToString(n)} $";
		}
	}
}
