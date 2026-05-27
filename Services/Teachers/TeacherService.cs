using SchoolManagement.Models.Teachers;

namespace SchoolManagement.Services.Teachers;

public class TeacherService : ITeacherService
{
	public static int teachersAmount = 10;

	public static int count = 0;

	Teacher[] teachers = new Teacher[teachersAmount];

	public void CreateTeacher(Teacher teacher)
	{
		teachers[count] = teacher;
		count++;
	}

	public Teacher[] GetAllTeachers()
	{
		return teachers;
	}

	public Teacher GetTeacherById(int id)
	{
		if(teachersAmount < id) return null;

		return teachers[id-1];
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