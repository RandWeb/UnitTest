namespace InlineDataAttribute;

public class InvoiceService
{
    public Invoice CreateInvoice(TypeOfService typeOfService, decimal amount)
    {
        if (typeOfService == TypeOfService.JobLicense && amount < 2000)
        {
            return null;
        }

        if (typeOfService == TypeOfService.SmartCard && amount < 1000)

            return new Invoice()
            {
                Id = 0,
            };

        return new Invoice()
        {
            Id = 10,
        };
    }
}