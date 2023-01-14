namespace DigitalAssetService.Core.AggregateModel.DigitalAssetAggregate;

public class DigitalAsset {
    public Guid DigitalAssetId { get; private set; }
    public string Name { get; private set; }
    public byte[] Bytes { get; private set; }
    public string ContentType { get; private set; }
}
