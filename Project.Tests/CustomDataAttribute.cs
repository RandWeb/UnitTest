namespace InlineDataAttribute.Tests;

public class CustomDataAttribute
{
    [Theory]
    [CsvData(@"",',')]
    public void CreateInvoice_UsingCustomDataAttribute_ShouldNotNullAndInvoiceNotEqualZero(TypeOfService typeOfService, decimal amount)
    {
        InvoiceService invoiceService = new();

        Invoice invoice = invoiceService.CreateInvoice(typeOfService, amount);
        Assert.NotNull(invoice);
        Assert.True(invoice.Id > 0);
    }
    [Theory]
    [CsvData(@"",',')]
    public void CreateInvoice_UsingJsonDataAttribute_ShouldNotNullAndInvoiceNotEqualZero(TypeOfService typeOfService, decimal amount)
    {
        InvoiceService invoiceService = new();

        Invoice invoice = invoiceService.CreateInvoice(typeOfService, amount);
        Assert.NotNull(invoice);
        Assert.True(invoice.Id > 0);
    }
}