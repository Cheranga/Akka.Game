using Game.ActorModel.ExternalSystems;
using Microsoft.AspNet.SignalR;

namespace Game.Web.Models
{
    public class SignalRGameEventPusher : IGameEventsPusher
    {
        private static readonly IHubContext GameHubContext;

        static SignalRGameEventPusher()
        {
            GameHubContext = GlobalHost.ConnectionManager.GetHubContext<GameHub>();
        }

        public void PlayerJoined(string playerName, int health)
        {
            GameHubContext.Clients.All.playerJoined(playerName, health);
        }

        public void UpdatePlayerHealth(string playerName, int playerHealth)
        {
            GameHubContext.Clients.All.updatePlayerHealth(playerName, playerHealth);
        }
    }
}