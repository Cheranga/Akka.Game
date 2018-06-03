using System;
using Akka.Actor;
using Game.ActorModel.Actors;

namespace Game.State
{
    internal class Program
    {
        private static ActorSystem ActorSystemInstance;

        private static void Main(string[] args)
        {
            ActorSystemInstance = ActorSystem.Create("GameSystem");
            ActorSystemInstance.ActorOf(Props.Create(() => new GameControllerActor()), "GameController");

            Console.ReadLine();
        }
    }
}