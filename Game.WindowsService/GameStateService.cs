using System;
using Akka.Actor;
using Game.ActorModel.Actors;

namespace Game.WindowsService
{
    public class GameStateService
    {
        private ActorSystem _actorSystemInstance;

        public void Start()
        {
            _actorSystemInstance = ActorSystem.Create("GameSystem");
            _actorSystemInstance.ActorOf(Props.Create(() => new GameControllerActor()), "GameController");
        }

        public void Stop()
        {
            _actorSystemInstance.Terminate().Wait(TimeSpan.FromSeconds(2));
        }
    }
}