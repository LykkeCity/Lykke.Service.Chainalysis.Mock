namespace Lykke.Service.ChainalysisMock.Core.Domain
{
    public interface IWindrowAddressInfo : IAddressInfo
    {
        string Name { get; set; }

        string Category { get; set; }

        string Score { get; set; }

    }
}
