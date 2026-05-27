using SchoolManagement.Models.Teachers;
using SchoolManagement.Services.Teachers;

namespace SchoolManagement;

public class App
{
	private ITeacherService Service { get; set; }

	public App(ITeacherService service)
	{
		this.Service = service;
	}

	public void Run()
	{
		while(true)
		{
			Console.Clear();
			Console.WriteLine("===== SCHOOL MANAGEMENT =====");
			Console.WriteLine("1. Show teachers");
			Console.WriteLine("2. Create teacher");
			Console.WriteLine("0. Exit");
			Console.Write("\nChoose an option: ");
			
			string userInput = Console.ReadLine();

			switch(userInput)
			{
				case "1":
					{
						HandleReadAll();
						break;
					}
				case "2":
					{
						HandleCreate();
						break;
					}
				case "0":
					{
						return;
					}
				default:
					{
						Console.WriteLine("Error");
						break;
					}
			}
		}
	}

	private void HandleReadAll()
	{
		Teacher[] teachers = Service.GetAllTeachers();

		if (teachers[0] is null)
		{
			Console.Clear();

			Console.WriteLine("Teachers not found");
			HandleContinue();
			return;
		}

		Console.Clear();

		foreach(Teacher teacher in teachers)
		{
			Service.PrintInfo(teacher);
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
			Id = TeacherService.count + 1,
			FirstName = userFirstName,
			LastName = userLastName,
			Address = userAddress
		};

		Service.CreateTeacher(newTeacher);

		HandleContinue();
	}

	private void HandleContinue()
	{
		Console.Write("Press any key to continue...");
		Console.ReadKey();
	}
}