using System.Reflection;
using Newtonsoft.Json;
using Xunit.Sdk;

namespace InlineDataAttribute.Tests;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class JsonDataAttribute : DataAttribute
{
    private string _filePath;
    private List<object[]> _jsonData = new();

    public JsonDataAttribute(string filePath)
    {
        _filePath = filePath;
    }

    private void ReadFile(MethodInfo methodInfo)
    {
        if (File.Exists(_filePath))
        {
            throw new ArgumentException("Json File Not found");
        }

        var all = File.ReadAllText(_filePath);
        var data = JsonConvert.DeserializeObject<List<object>>(all);
        _jsonData.Add(data.ToArray());
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        if (testMethod == null)
        {
            throw new ArgumentNullException();
        }

        return _jsonData;
    }
}