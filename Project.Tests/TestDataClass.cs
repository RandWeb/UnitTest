using System.Collections;

namespace InlineDataAttribute.Tests;

public class TestDataClass:IEnumerable<object[]>
{
    public static IEnumerable<object[]> PropertyMemberData
    {
        get
        {
            yield return new object[]
            {
                TypeOfService.JobLicense,
                1000
            };
            
            yield return new object[]
            {
                TypeOfService.JobLicense,
                5000
            };

        }
    }


    private IEnumerable<object[]> _data = new List<object[]>()
    {
        new object[]
        {
            TypeOfService.SmartCard,
            1000
        },
        new object[]
        {
            TypeOfService.JobLicense,
            5000
        }
    };
    public IEnumerator<object[]> GetEnumerator()
    {
        return _data.GetEnumerator();
    }

    IEnumerator IEnumerable. GetEnumerator()
    {
        return GetEnumerator();
    }
}