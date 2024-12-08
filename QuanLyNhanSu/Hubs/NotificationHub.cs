using Microsoft.AspNet.SignalR;

public class NotificationHub : Hub
{
    public void SendNotificationCount(int count)
    {
        // Gửi số lượng thông báo đến tất cả client
        Clients.All.updateNotificationCount(count);
    }
}