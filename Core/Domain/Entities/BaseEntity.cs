namespace Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; private set; }
    public bool IsEnabled { get; private set; } = true;

    public void SetIsEnabled(bool isEnabled) => IsEnabled = isEnabled;
    public void SetUpdatedAt() => UpdatedAt = DateTime.Now;
}