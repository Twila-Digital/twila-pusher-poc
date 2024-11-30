using PusherServer;

namespace API.Services
{
    public interface IPusherService
    {
        Task TriggerEvent(string channel, string eventName, object data);
    }

    public class PusherService : IPusherService
    {
        private readonly Pusher _pusher;

        public PusherService()
        {
            _pusher = new Pusher(
                "app-id",
                "app-key",
                "app-secret",
                new PusherOptions
                {
                    Cluster = "app-cluster",
                    Encrypted = true
                });
        }

        public async Task TriggerEvent(string channel, string eventName, object data)
        {
            await _pusher.TriggerAsync(channel, eventName, data);
        }
    }
}
