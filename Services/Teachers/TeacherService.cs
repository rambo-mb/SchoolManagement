using SchoolManagement.Models.Teachers;

namespace SchoolManagement.Services.Teachers;

public class TeacherService : ITeacherService
{

	public static int count = 0;

	Teacher[] teachers = new Teacher[10];

	public void CreateTeacher(Teacher teacher)
	{
		teachers[TeacherService.count] = teacher;
		TeacherService.count++;
	}

	public Teacher[] GetAllTeachers()
	{
		return this.teachers;
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