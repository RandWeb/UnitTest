namespace InlineDataAttribute.Tests;

public class TestDataClass
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
}