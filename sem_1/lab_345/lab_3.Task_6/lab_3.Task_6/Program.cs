using lab_3.Task_6.Data;
using lab_3.Task_6.Data.ChainOfResponsibility;


CheckingPlatform checkingPlatform = new CheckingPlatform();

checkingPlatform.AddPapers(
    new Paper("Mark"),
    new Paper("Olia", "2", "as", "sdsds"),
    new Paper("Sasha"),
    new Paper("Alex", "one", "two", "three"),
    new Paper("Oksana"),
    new Paper("Matvii"),
    new Paper("Varia", "math is interesting", "wow")
);


Teacher teacherStacy = new Teacher("Stacy");
Teacher teacherMike = new Teacher("Mike");
teacherStacy
    .SetNext(new Teacher("Anton"))
    .SetNext(teacherMike)
    .SetNext(new Teacher("George"))
    .SetNext(new Teacher("Jane"));

teacherStacy.DisplayChain();

await checkingPlatform.CheckStudentPaper(teacherStacy);
Console.WriteLine();
checkingPlatform.DisplayResults();


Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("\nStarting from teacher Mike\n");
Console.ForegroundColor = ConsoleColor.White;

teacherMike.DisplayChain();
await checkingPlatform.CheckStudentPaper(teacherMike);
Console.WriteLine();
checkingPlatform.DisplayResults();

Console.ReadKey();