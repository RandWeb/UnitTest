namespace InlineDataAttribute.Tests;

using Xunit;

public class MemberDataTest
{
    public static IEnumerable<object[]> FieldMemberData = new List<object[]>()
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

    public static IEnumerable<object[]> MethodMemberData (int recordCount)
    {
        var result = new List<object[]>()
        {
            new object[]
            {
                TypeOfService.SmartCard,
                1000
            },
            new object[]
            {
                TypeOfService.SmartCard,
                5000
            },
        };
        return result.Take(recordCount);
    }

    [Theory]
    [InlineData(TypeOfService.JobLicense, 1000)]
    [InlineData(TypeOfService.JobLicense, 2000)]
    [MemberData(nameof(FieldMemberData))]
    public void CreateInvoice_UsingFieldMemberData_ShouldInvoice_NotNullAndInvoiceNotEqualZero(
        TypeOfService typeOfService, decimal amount)
    {
        InvoiceService invoiceService = new();

        Invoice invoice = invoiceService.CreateInvoice(typeOfService, amount);
        Assert.NotNull(invoice);
        Assert.True(invoice.Id > 0);
    }

    [Theory]
    [InlineData(TypeOfService.JobLicense, 1000)]
    [MemberData(nameof(PropertyMemberData))]
    public void CrateInvoice_UsingFieldMemberData_ShouldInvoiceNotNullAndInvoiceNotEqualZero(
        TypeOfService typeOfService, decimal amount)
    {
        InvoiceService invoiceService = new();

        Invoice invoice = invoiceService.CreateInvoice(typeOfService, amount);
        Assert.NotNull(invoice);
        Assert.True(invoice.Id > 0);
    }

    [Theory]
    [InlineData(TypeOfService.JobLicense, 1000)]
    [MemberData(nameof(MethodMemberData),parameters:2)]
    public void CreateInvoice_UsingMethodMemberData_ShouldNotNullAndInvoiceNotEqualZero(TypeOfService typeOfService,
        decimal amount)
    {
        InvoiceService invoiceService = new();

        Invoice invoice = invoiceService.CreateInvoice(typeOfService, amount);
        Assert.NotNull(invoice);
        Assert.True(invoice.Id > 0);
    }
}