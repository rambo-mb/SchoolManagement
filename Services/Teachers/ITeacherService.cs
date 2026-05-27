using SchoolManagement.Models.Teachers;

namespace SchoolManagement.Services.Teachers;

public interface ITeacherService
{
	Teacher[] GetAllTeachers();

	void CreateTeacher(Teacher teacher);

	void PrintInfo(Teacher teacher);
}