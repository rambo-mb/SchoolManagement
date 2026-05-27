using SchoolManagement.Models.Teachers;

namespace SchoolManagement.Services.Teachers;

public class TeacherService : ITeacherService
{
	private const int teachersAmount = 10;
	private int count = 0;

	private Teacher[] teachers = new Teacher[teachersAmount];

	public void CreateTeacher(Teacher teacher)
	{
		if(count >= teachersAmount)
		{
			Console.WriteLine("Teachers are full");
			return;
		}
		teacher.Id = count + 1;
		teachers[count] = teacher;
		count++;
	}

	public Teacher[] GetAllTeachers()
	{
		Teacher[] result = new Teacher[count];
		for (int i = 0; i < count; i++)
		{
				result[i] = teachers[i];
		}
		return result;
	}

	public Teacher GetTeacherById(int id)
	{
		foreach (Teacher teacher in teachers)
		{
			if (teacher is null) continue;
			if (teacher.Id == id) return teacher;
		}
		return null;
	}

	public void PrintInfo(Teacher teacher)
	{
		if (teacher is null) return;

		Console.WriteLine("=============");
		Console.WriteLine(
			$"""
			Teacher {teacher.Id} Info:
				First name: {teacher.FirstName}
				Last name: {teacher.LastName}
				Address: {teacher.Address}
			"""
		);
	}

	
}