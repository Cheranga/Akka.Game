namespace Game.ActorModel.ExternalSystems
{
    public interface IGameEventsPusher
    {
        void PlayerJoined(string playerName, int health);
        void UpdatePlayerHealth(string playerName, int playerHealth);
    }
}