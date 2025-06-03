using GMAO.Domain.Enums;

namespace GMAO.Domain.Entities;

public class Asset
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Site { get; private set; }
    public string Location { get; private set; }
    public AssetStatus Status { get; private set; }

    private Asset() { }

    private Asset(Guid id, string name, string site, string location, AssetStatus status)
    {
        Id = id;
        Name = name;
        Site = site;
        Location = location;
        Status = status;
    }

    public static Asset Create(Guid id, string name, string site, string location, AssetStatus status)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Asset name is required", nameof(name));
        return new Asset(id, name, site, location, status);
    }

    public void Update(string name, string site, string location, AssetStatus status)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Asset name is required", nameof(name));

        if (!Enum.IsDefined(typeof(AssetStatus), status))
            throw new ArgumentException("Invalid asset status", nameof(status));

        Name = name;
        Site = site;
        Location = location;
        Status = status;
    }
}
