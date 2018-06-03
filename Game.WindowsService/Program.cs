using Topshelf;

namespace Game.WindowsService
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            HostFactory.Run(gameService =>
            {
                gameService.Service<GameStateService>(s =>
                {
                    s.ConstructUsing(game => new GameStateService());
                    s.WhenStarted(game => game.Start());
                    s.WhenStopped(game => game.Stop());
                });

                gameService.RunAsLocalSystem();
                gameService.StartAutomatically();

                gameService.SetDescription("PS Demo Topshelf Service");
                gameService.SetDisplayName("PSDemoGame");
                gameService.SetServiceName("PSDemoGame");
            });
        }
    }
}