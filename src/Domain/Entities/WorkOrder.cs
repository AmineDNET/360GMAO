using GMAO.Domain.Enums;

namespace GMAO.Domain.Entities;

public class WorkOrder
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public WorkOrderType Type { get; private set; }
    public WorkOrderStatus Status { get; private set; }
    public Guid? AssignedToId { get; private set; }
    public Guid AssetId { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private WorkOrder() { }

    private WorkOrder(Guid id, string title, string description, WorkOrderType type, Guid assetId)
    {
        Id = id;
        Title = title;
        Description = description;
        Type = type;
        Status = WorkOrderStatus.Open;
        AssetId = assetId;
        CreatedAt = DateTime.UtcNow;
    }

    public static WorkOrder Create(Guid id, string title, string description, WorkOrderType type, Guid assetId)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title is required", nameof(title));
        return new WorkOrder(id, title, description, type, assetId);
    }

    public void Assign(Guid userId)
    {
        AssignedToId = userId;
        Status = WorkOrderStatus.InProgress;
    }

    public void Complete()
    {
        Status = WorkOrderStatus.Completed;
    }
}
