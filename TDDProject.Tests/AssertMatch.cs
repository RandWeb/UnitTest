namespace TDDProject.Tests;

public class AssertMatch
{
    [Fact]
    public void assert_match_with_regx()
    {
        string regEX = @"[a-zA-Z0-9.-]+@[a-z-]+.[a-z]{2,3}";

        
        Assert.Matches("", "mehrdadit12@gmail.com");
    }
}