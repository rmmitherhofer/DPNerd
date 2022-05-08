namespace DPNerd.Notifications;

public class Notification
{
    public Guid Id { get; private set; }
    public DateTime Timestamp { get; private set; }
    public string Type { get; set; }
    public string Key { get; private set; }
    public string Value { get; private set; }

    public Notification(string type, string key, string value)
    {
        Id = Guid.NewGuid();
        Timestamp = DateTime.Now;
        Type = type;
        Key = key;
        Value = value;
    }

    public Notification(string key, string value)
    {
        Id = Guid.NewGuid();
        Timestamp = DateTime.Now;
        Key = key;
        Value = value;
    }

    public Notification(string value)
    {
        Id = Guid.NewGuid();
        Timestamp = DateTime.Now;
        Value = value;
    }
}
