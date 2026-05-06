using AutoFixture;
using System.Xml.Serialization;
using SeleniumTests;

Console.WriteLine("Введите количество тестфайлов");
var numTestsStr = Console.ReadLine();

if (!int.TryParse(numTestsStr, out int count) || count <= 0)
{
    Console.WriteLine("Error: <count> must be a positive integer.");
    return;
}

Console.WriteLine("Введите название файла с тестами");
var outputFile = Console.ReadLine();
if (string.IsNullOrEmpty(outputFile))
    outputFile = "tasks.xml";

var fixture = new Fixture();

fixture.Customize<TaskData>(c => c
    .With(t => t.Name, () => fixture.Create<string>()[..20])
);

var tasks = fixture.CreateMany<TaskData>(count).ToList();

var serializer = new XmlSerializer(typeof(List<TaskData>), new XmlRootAttribute("ArrayOfTaskData"));
using var writer = new StreamWriter(outputFile);
serializer.Serialize(writer, tasks);

Console.WriteLine($"Generated {count} task(s) → {outputFile}");