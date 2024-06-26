//using System.Reflection;
//using System.Security.Cryptography;
//using System.Text.Json;

//namespace SharedClassLib.Data
//{
//	public class DataController
//	{
//		public Func<string> ShowDialogFolderRef;
//		public Func<string> ShowDialogFileRef;
//		private List<User> users = new() { new("Artem", "@email", "pswd", 0) };
//		private List<Submarine> submarines = new();

//		public List<User> Users
//		{
//			get { return users; }
//			set { users = value; }
//		}

//		public List<Submarine> Submarines
//		{
//			get { return submarines; }
//			set { submarines = value; }
//		}

//		public void AddSubmarine(Submarine submarine)
//		{
//			submarines.Add(submarine);
//			UpdateSubmarinesId();
//		}

//		public void DeleteSubmarine(int Id)
//		{
//			var itemToRemove = submarines.Single(e => e.Id == Id);
//			submarines.Remove(itemToRemove);
//			UpdateSubmarinesId();
//		}

//		private void UpdateSubmarinesId()
//		{
//			for (int i = 0; i < submarines.Count; i++)
//			{
//				submarines[i].Id = i;
//			}
//		}

//		public bool ImportDataFromJson(string jsonString)
//		{
//			if (jsonString == null || jsonString=="") return false;

//			DataController temp = JsonSerializer.Deserialize<DataController>(jsonString);

//			if(temp == null) return false;

//			this.submarines = temp.Submarines;
//			this.users = temp.Users;
//			return true;
//		}

//		public string ExportDataToJson()
//		{
//			return JsonSerializer.Serialize(this); ;
//		}
		
//		public string SelectFolder()
//		{
//			return ShowDialogFolderRef();
//		}
//		public string SelectFile()
//		{
//			return ShowDialogFileRef();
//		}
//	}

//	public class User
//	{
//		private string userName;
//		private string email;
//		private string passwordHash;
//		private int accessLevel;

//		public User(string userName, string email, string password, int accessLevel)
//		{
//			this.userName = userName;
//			this.email = email;
//			this.passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
//			this.accessLevel = accessLevel;
//		}

//		public string UserName
//		{
//			get { return userName; }
//			set { userName = value; }
//		}
//		public string Email
//		{
//			get { return email; }
//			set { email = value; }
//		}
//		public string Password
//		{
//			get { return passwordHash; }
//			set { passwordHash = BCrypt.Net.BCrypt.HashPassword(value); }
//		}
//		public int AccessLevel
//		{
//			get { return accessLevel; }
//			set { accessLevel = value; }
//		}

//		public bool CheckPassword(string password)
//		{
//			return BCrypt.Net.BCrypt.Verify(password, passwordHash);
//		}
//	}

//	public abstract class Product
//	{
//		protected int id;
//		protected float price;
//		protected string name;

//		public Product(float price, string name)
//		{
//			this.price = price;
//			this.name = name;
//		}

//		public int Id
//		{
//			get { return id; }
//			set { id = value; }
//		}

//		public float Price
//		{
//			get { return price; }
//			set { price = value; }
//		}

//		public string Name
//		{
//			get { return name; }
//			set { name = value; }
//		}
//	}

//	public class Submarine : Product
//	{
//		private float width;
//		private float height;
//		private float length;
//		private float maxWaterPressure;
//		private string engineType;

//		public Submarine(float width, float height, float length, float maxWaterPressure, string engineType, float price, string name) : base(price, name)
//		{
//			this.width = width;
//			this.height = height;
//			this.length = length;
//			this.maxWaterPressure = maxWaterPressure;
//			this.engineType = engineType;
//		}

//		public float Width
//		{
//			get { return width; }
//			set { width = value; }
//		}

//		public float Height
//		{
//			get { return height; }
//			set { height = value; }
//		}

//		public float Length
//		{
//			get { return length; }
//			set { length = value; }
//		}

//		public float MaxWaterPressure
//		{
//			get { return maxWaterPressure; }
//			set { maxWaterPressure = value; }
//		}

//		public string EngineType
//		{
//			get { return engineType; }
//			set { engineType = value; }
//		}
//	}
//}
