namespace GMAO.Domain.Entities;

public class PreventiveMaintenance
{
    public Guid Id { get; private set; }
    public Guid AssetId { get; private set; }
    public string Description { get; private set; }
    public int FrequencyDays { get; private set; }
    public DateTime NextDueDate { get; private set; }

    private PreventiveMaintenance() {}

    private PreventiveMaintenance(Guid id, Guid assetId, string description, int frequencyDays, DateTime nextDue)
    {
        Id = id;
        AssetId = assetId;
        Description = description;
        FrequencyDays = frequencyDays;
        NextDueDate = nextDue;
    }

    public static PreventiveMaintenance Create(Guid id, Guid assetId, string description, int frequencyDays)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description is required", nameof(description));
        if (frequencyDays <= 0)
            throw new ArgumentException("Frequency must be positive", nameof(frequencyDays));
        return new PreventiveMaintenance(id, assetId, description, frequencyDays, DateTime.UtcNow.AddDays(frequencyDays));
    }
}
