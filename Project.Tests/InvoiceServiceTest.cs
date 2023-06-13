namespace InlineDataAttribute.Tests;

using Xunit;

public class InvoiceServiceTest
{
    [Theory]
    [InlineData(TypeOfService.JobLicense, 1000)] // invalid data
    [InlineData(TypeOfService.SmartCard, 3000)] // valid data
    public void create_invoice_not_return_null_and_zero(TypeOfService typeOfService, decimal amount)
    {
        InvoiceService invoiceService = new();

        Invoice invoice = invoiceService.CreateInvoice(typeOfService, amount);

        Assert.NotNull(invoice);
        Assert.True(invoice.Id > 0);
    }
}