using Moq;
using Xunit;
using Range = Moq.Range;

namespace MoqFramework.Tests;

public class UnitTestWithMoq
{
    private Mock<IPersonRepository> _personRepository = new();


    public UnitTestWithMoq()
    {
        _personRepository.Setup(c => c.Count).Returns(10);
        _personRepository.Setup(c => c.Get(100))
            .Returns(() => { return new Person() { Id = 100 }; });

        _personRepository.Setup(c => c.Get(It.IsAny<int>()))
            .Returns((int id) => { return Data.Persons.FirstOrDefault(c => c.Id == id); });
        
        _personRepository.Setup(c => c.Get(It.Is<int>(c => c % 2 == 0))).Returns((int id) => { return null; });
        _personRepository.Setup(c => c.Get(It.IsInRange(101,500,Range.Inclusive))).Returns((int id) => { return null; });
        _personRepository.Setup(c => c.Get(It.IsInRange(101,500,Range.Exclusive))).Returns((int id) => { return new Person() { Id = id }; });
    }

    [Fact]
    public void Test1()
    {
    }
}