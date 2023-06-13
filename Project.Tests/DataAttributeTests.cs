namespace InlineDataAttribute.Tests;

public class DataAttributeTests
{
    [Theory]
    [ClassData(typeof(TestDataClass))]
    public void CreateInvoice_usingClassData_shouldInvoiceNotNullAndInvoiceIdNotEqualZero(TypeOfService typeOfService,
        decimal amount)
    {
        InvoiceService invoiceService = new();
        Invoice invoice = invoiceService.CreateInvoice(typeOfService, amount);
        Assert.NotNull(invoice);
        Assert.True(invoice.Id > 0);
    }
}
