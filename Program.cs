using SchoolManagement.Services.Teachers;
using SchoolManagement;

ITeacherService teacherService = new TeacherService();
App app = new App(teacherService);
app.Run();