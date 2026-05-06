namespace SeleniumTests;

using System.Xml.Serialization;

[XmlRoot("TaskData")]
public class TaskData
{
    [XmlElement("Name")]
    public string Name { get; set; } = "";

    public TaskData() { }

    public TaskData(string name)
    {
        Name = name;
    }

    public override string ToString() => $"TaskData(Name={Name})";
}
