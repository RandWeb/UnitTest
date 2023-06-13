namespace TDDProject.Tests;

public class AssertContains
{
    [Fact]
    public void assert_contains_text()
    {

        Assert.Contains("mehrdad", "string has mehrdad");
        
        //Assert.DoesNotContain("mehrdad", "mehrdad is boy");
    }   
    
    [Fact]
    public void assert_contains_dictionary()
    {
        IDictionary<string, string> dic = new Dictionary<string, string>()
        {
            { "index1", "value1" },
            { "index2", "value2" },
        };
        Assert.Contains("index1", dic);
       // Assert.DoesNotContain("index0", dic);
    }  
    [Fact]
    public void assert_contains_ienumerable()
    {
        IDictionary<string, string> dic = new Dictionary<string, string>()
        {
            { "index1", "value1" },
            { "index2", "value2" },
        };
        Assert.Contains(dic, item=>item.Value.Equals("value1"));
       // Assert.DoesNotContain(dic, item=>item.Value.Equals("value1"));
    }  

}