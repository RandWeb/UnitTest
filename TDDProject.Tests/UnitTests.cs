namespace TDDProject.Tests;

public class UnitTests
{
    [Fact]
    public void if_3_is_odd_should_return_true()
    { 
        var numberHelper = new NumberHelper();
        bool isOdd = numberHelper.IsOdd(3);

        Assert.True(isOdd);
    } 
    
    [Theory]
    [InlineData("mehrdad",7)]
    [InlineData("ali",3)]
    public void string_compare_lenght_should_equal_Lenght_parameter(string value,int lenght)
    {
        Assert.Equal(lenght,value.Length);
    }
}