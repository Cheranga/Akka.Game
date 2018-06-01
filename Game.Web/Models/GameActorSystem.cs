using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Akka.Actor;
using Game.ActorModel.Actors;
using Game.ActorModel.ExternalSystems;

namespace Game.Web.Models
{
    public static class GameActorSystem
    {
        private static ActorSystem _actorSystem;
        private static IGameEventsPusher _gameEventsPusher;

        public static void Create()
        {
            _gameEventsPusher = new SignalRGameEventPusher();

            _actorSystem = ActorSystem.Create("GameSystem");
            ActorReferences.GameController = _actorSystem.ActorOf(Props.Create(() => new GameControllerActor()), "GameController");
            ActorReferences.SignalRBridge = _actorSystem.ActorOf(Props.Create(() => 
                new SignalRBridgeActor(_gameEventsPusher, ActorReferences.GameController)),"SignalRBridgeActor");
        }

        public static class ActorReferences
        {
            public static IActorRef GameController { get; set; }
            public static IActorRef SignalRBridge { get; set; }
        }
    }
}