using System.Collections.Generic;
using Akka.Actor;
using Game.ActorModel.Messages;

namespace Game.ActorModel.Actors
{
    public class GameControllerActor : ReceiveActor
    {
        private IDictionary<string, IActorRef> _players;

        public GameControllerActor()
        {
            _players = new Dictionary<string, IActorRef>();

            Receive<JoinGameMessage>(message =>
            {
                if (!_players.ContainsKey(message.PlayerName))
                {
                    var actorProps = Props.Create(() => new PlayerActor(message.PlayerName));
                    var newActorRef = Context.ActorOf(actorProps, message.PlayerName);
                    _players.Add(message.PlayerName, newActorRef);
                }

                foreach (var player in _players.Values)
                {
                    player.Tell(new RefreshPlayerStatusMessage(), Sender);
                }
            });

            Receive<AttackPlayerMessage>(message =>
            {
                if (_players.ContainsKey(message.PlayerName))
                {
                    _players[message.PlayerName].Forward(message);
                }
            });
        }
    }
}