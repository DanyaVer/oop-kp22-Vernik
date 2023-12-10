using lab_3.Task_1.Data;

StudentGroup MainStudentGroup = new StudentGroup("КП-22");
StudentGroup SubStudentGroup1 = new StudentGroup("КП-22-1");
StudentGroup SubStudentGroup2 = new StudentGroup("КП-22-2");
StudentGroup SubStudentGroup3 = new StudentGroup("КП-22-3");
StudentGroup SubStudentGroup4 = new StudentGroup("КП-22-4");

Student student = new Student("Danylo");
student.DisplayInfo();
student.TakeExam();
student.TakeExam();
SubStudentGroup1.Add(student);
SubStudentGroup1.Add(new Student("Stacy"));
SubStudentGroup2.Add(new Student("Yehor"));
SubStudentGroup2.Add(new Student("Matvii"));
SubStudentGroup2.Add(new Student("Varia"));
SubStudentGroup3.Add(new Student("Olia"));

MainStudentGroup.Add(SubStudentGroup1);
MainStudentGroup.Add(SubStudentGroup2);
MainStudentGroup.Add(SubStudentGroup3);
MainStudentGroup.Add(SubStudentGroup4);

MainStudentGroup.DisplayInfo();
SubStudentGroup1.TakeExam();
SubStudentGroup1.TakeExam();
SubStudentGroup2.TakeExam();
SubStudentGroup2.TakeExam();
SubStudentGroup4.TakeExam();

SubStudentGroup1.DisplayInfo();
MainStudentGroup.DisplayInfo();

MainStudentGroup.TakeExam();
MainStudentGroup.DisplayInfo();
