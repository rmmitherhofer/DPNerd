namespace DPNerd.Notifications;

public class NotificationHandler : INotificationHandler
{
    private readonly List<Notification> _notifications;

    public NotificationHandler()
        => _notifications = new List<Notification>();

    public void Notify(Notification notificacao)
        => _notifications.Add(notificacao);

    public void Notify(ICollection<Notification> notificacoes)
        => _notifications.AddRange(notificacoes);

    public ICollection<Notification> GetNotifications()
        => _notifications;

    public bool HasNotifications()
        => _notifications.Count > 0;

    public void ClearNotifications()
        => _notifications.Clear();
}
