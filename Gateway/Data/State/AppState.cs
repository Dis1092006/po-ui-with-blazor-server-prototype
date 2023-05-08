namespace Gateway.Data.State;

public class AppState
{
    public const string DefaultWarehouse = "North warehouse";
    public string CurrentWarehouse { get; private set; } = DefaultWarehouse;
    
    public event Action? OnChange;
    
    public void SetWarehouse(string warehouse)
    {
        CurrentWarehouse = warehouse;
        NotifyStateChanged();
    }
    
    private void NotifyStateChanged() => OnChange?.Invoke();
}