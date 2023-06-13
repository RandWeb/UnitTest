using System.Reflection;
using Xunit.Sdk;

namespace InlineDataAttribute.Tests;

[AttributeUsage(AttributeTargets.Method,AllowMultiple = false,Inherited = false)]
public class CsvDataAttribute:DataAttribute
{
    private string _filePath;
    private char _separator;
    private List<object[]> _csvData= new();

    public CsvDataAttribute(string filePath, char separator)
    {
        _filePath = filePath;
        _separator = separator;
    }

    private void readFile(MethodInfo methodInfo)
    {
        Type[] parameterTypes =
            methodInfo.GetParameters().OrderBy(p => p.Position).Select(t => t.ParameterType).ToArray();
        using (var reader = new StreamReader(_filePath))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (line!=null)
                {
                    var values = line.Split(_separator).Cast<object>().ToArray();
                    var convertedValues = new List<object>();

                    for (int i = 0; i < values.Length; i++)
                    {
                        var type = parameterTypes[i];
                        var val = values[i];
                        if (type.IsEnum)
                        {
                            var value = Convert.ToInt32(val);
                            var convertableValue = Enum.ToObject(type, value);
                            var enumObj = Convert.ChangeType(convertableValue, type);
                            
                            convertedValues.Add(enumObj);
                        }
                        else
                        {
                         convertedValues.Add(Convert.ChangeType(val,type));   
                        }
                    }
                    _csvData.Add(convertedValues.ToArray());
                }
            }
        }
    }
    
    public override IEnumerable<object[]> GetData(MethodInfo methodInfo)
    {
        if (methodInfo == null)
        {
            throw new ArgumentNullException();
        }
        readFile(methodInfo);
        return _csvData;
    }
}