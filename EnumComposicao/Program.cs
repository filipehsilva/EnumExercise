using EnumComposicao.Entities;
using EnumComposicao.Entities.Enums;
using System.Globalization;


Console.Write("Enter department's name: ");
string departmentName = Console.ReadLine();

Department department = new Department(departmentName);

Console.WriteLine("Enter worker data: ");
Console.Write("Name: ");
string workerName = Console.ReadLine();
Console.Write("Level (Junior/MidLevel/Senior: ");
WorkerLevel workerLevel = Enum.Parse<WorkerLevel>(Console.ReadLine());
Console.Write("Base salary: ");
double workerSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

Worker worker = new Worker(workerName, workerLevel, workerSalary, department);

Console.Write("How many contracts to this worker? ");
int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    Console.WriteLine($"Enter #{i+1} contract data:");
    Console.Write("Date (DD/MM/YYYY): ");
    DateTime contractDate = DateTime.Parse(Console.ReadLine());
    Console.Write("Value per hour: ");
    double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
    Console.Write("Duration (Hours): ");
    int hours = int.Parse(Console.ReadLine());
    HourContract contract = new HourContract(contractDate, valuePerHour, hours);
    worker.AddContract(contract);
}

Console.WriteLine();
Console.Write("Enter month and year to calculate income (MM/YYYY): ");
string monthAndYear = Console.ReadLine();
int month = int.Parse(monthAndYear.Substring(0, 2));
int year = int.Parse(monthAndYear.Substring(3));
Console.WriteLine();
Console.WriteLine($"Name: {worker.Name}");
Console.WriteLine($"Department: {worker.Department.Name}");
Console.WriteLine($"Income for {monthAndYear}: {worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture)}");
