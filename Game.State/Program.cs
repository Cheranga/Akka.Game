using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Game.ActorModel.Actors;

namespace Game.State
{
    class Program
    {
        private static ActorSystem ActorSystemInstance;

        static void Main(string[] args)
        {
            ActorSystemInstance = ActorSystem.Create("GameSystem");
            ActorSystemInstance.ActorOf(Props.Create(() => new GameControllerActor()),"GameController");

            Console.ReadLine();
        }
    }
}
