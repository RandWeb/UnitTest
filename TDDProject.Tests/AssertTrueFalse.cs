namespace TDDProject.Tests;

public class AssertTrueFalse
{
    [Fact]
    public void assert_true_should_return_true()
    {
        Assert.True(typeof(AssertTrueFalse) == (new AssertTrueFalse()).GetType());
    }

    [Fact]
    public void assert_true_failed_should_return_message()
    {
        Assert.True(false,"the result is false");
    }
}