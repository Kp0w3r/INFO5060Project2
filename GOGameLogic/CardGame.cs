using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GOContracts;

namespace GOGameLogic
{
    public abstract class CardGame : IGame
    {
        protected static Dictionary<Guid, ICallback> ClientCallbacks;

        protected CardGame()
        {
            GameId = Guid.NewGuid();
        }

        /// <summary>
        /// Gets a <see cref="Guid"/> uniquely identifying the game instance.
        /// </summary>
        public Guid GameId { get; }

        /// <summary>
        /// Gets an <see cref="IList{IDeck}"/> containing the card decks played in the game.
        /// </summary>
        public Deck Deck { get; protected set; }

        public abstract GoCallback CallBack { get; }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IPlayer}"/> containing player information for all players in the game.
        /// </summary>
        public List<PlayerState> PlayerStates
        {
            get
            {
                return Players.Select(player => new PlayerState(player.Name, player.Id, player.Hand.Count(), 0)).ToList();
            }
        }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IPlayer}"/> containing player information for all players in the game.
        /// </summary>
        public List<Player> Players { get; protected set; }

        /// <summary>
        /// Gets the minimum number of players supported by the game.
        /// </summary>
        public abstract int MinPlayers { get; }

        /// <summary>
        /// Gets the maximum number of players supported by the game.
        /// </summary>
        public abstract int MaxPlayers { get; }

        public bool IsGameOver { get; protected set; }

        /// <summary>
        /// Creates a new player and returns its instance.
        /// </summary>
        /// <param name="name">The display name of the player.</param>
        /// <returns>A reference to an <see cref="IPlayer"/> instance of the player created.</returns>
        public abstract PlayerState CreatePlayer(string name);

        /// <summary>
        /// Removes a specified player from the game.
        /// </summary>
        /// <param name="player">The guid identity of the player.</param>
        /// <returns>A bool value indicating whether the player was successfully removed.</returns>
        public abstract bool RemovePlayer(PlayerState player);

        public List<Card> GetHand(Guid playerId)
        {
            var player = Players.Find(p => p.Id.Equals(playerId)).Hand;
            return player;
        }

        public abstract bool AskPlayer(Guid self, Guid target, Card card);

        /// <summary>
        /// Deals cards to players in a manner aligned with the game type.
        /// </summary>
        protected abstract void DealCards();

    }
}
