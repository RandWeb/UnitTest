namespace TDDProject.Tests;

public class AssertMatch
{
    [Fact]
    public void assert_match_with_regx()
    {
        string regEx = @"[a-zA-Z0-9.-]+@[a-z-]+.[a-z]{2,3}";

        
        Assert.Matches(regEx, "mehrdadit12@gmail.com");
    }
}