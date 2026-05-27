using SchoolManagement.Models.Teachers;
using SchoolManagement.Services.Teachers;

namespace SchoolManagement;

public class App
{
	private readonly ITeacherService _service;

	public App(ITeacherService service)
	{
		this._service = service;
	}

	public void Run()
	{
		while(true)
		{
			Console.Clear();
			Console.WriteLine("===== SCHOOL MANAGEMENT =====");
			Console.WriteLine("1. Show teachers");
			Console.WriteLine("2. Create teacher");
			Console.WriteLine("3. Show teacher by ID");
			Console.WriteLine("0. Exit");
			Console.Write("\nChoose an option: ");
			
			string userInput = Console.ReadLine();

			switch(userInput)
			{
				case "1":
					HandleReadAll();
					break;
				case "2":
					HandleCreate();
					break;
				case "3":
					HandleReadById();
					break;
				case "0": return;
				default:
					Console.WriteLine("Invalid option, try again");
					HandleContinue();
					break;
			}
		}
	}

	private void HandleReadById()
	{
		Console.Clear();

		int teacherId;
		bool isValid;
		do
		{
				Console.Write("Enter teacher ID: ");
				string input = Console.ReadLine();
				isValid = int.TryParse(input, out teacherId) && teacherId > 0;
				
				if (!isValid) Console.WriteLine("Invalid ID, try again");
		}
		while (!isValid);

		Teacher teacher = _service.GetTeacherById(teacherId);

		if (teacher is null)
		{
			Console.Clear();

			Console.WriteLine("Teacher with this ID not found");
			HandleContinue();
			return;
		}

		_service.PrintInfo(teacher);
		HandleContinue();

	}

	private void HandleReadAll()
	{
		Teacher[] teachers = _service.GetAllTeachers();

		if (teachers is null || teachers.Length == 0)
		{
			Console.Clear();

			Console.WriteLine("Teachers not found");
			HandleContinue();
			return;
		}

		Console.Clear();

		foreach(Teacher teacher in teachers)
		{
			_service.PrintInfo(teacher);
		}

		HandleContinue();
	}

	private void HandleCreate()
	{
		Console.Clear();

		Console.Write("Enter first name: ");
		string userFirstName = Console.ReadLine();
		Console.Write("Enter last name: ");
		string userLastName = Console.ReadLine();
		Console.Write("Enter address: ");
		string userAddress = Console.ReadLine();

		var newTeacher = new Teacher()
		{
			FirstName = userFirstName,
			LastName = userLastName,
			Address = userAddress
		};

		_service.CreateTeacher(newTeacher);

		Console.WriteLine("Teacher created successfully");  
		HandleContinue();
	}

	private void HandleContinue()
	{
		Console.Write("Press any key to continue...");
		Console.ReadKey();
	}
}