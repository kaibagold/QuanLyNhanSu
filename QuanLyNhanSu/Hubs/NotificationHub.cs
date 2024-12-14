using Microsoft.AspNet.SignalR;

public class NotificationHub : Hub
{
    public void SendNotificationCount(int count)
    {
        // Gửi số lượng thông báo của admin đến tất cả client
        Clients.All.updateNotificationCount(count);
    }
}
public class NotificationHubToUser : Hub
{
    public void SendNotificationCountUser(int count)
    {
        // Gửi số lượng thông báo đến tất cả client
        Clients.All.updateNotificationCountUser(count);
    }
}