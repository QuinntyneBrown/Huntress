namespace Huntress.Domain.Entities;

public class DigitalAsset
{
    public Guid DigitalAssetId { get; set; }
    public string Name { get; set; } = "";
    public byte[] Bytes { get; set; } = null!;
    public string ContentType { get; set; } = "";
}
