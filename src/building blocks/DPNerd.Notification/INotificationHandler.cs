namespace DPNerd.Notifications;

public interface INotificationHandler
{
    void Notify(Notification notificacao);
    ICollection<Notification> GetNotifications();
    bool HasNotifications();
    void ClearNotifications();
}
