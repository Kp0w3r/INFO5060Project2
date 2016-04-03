﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GOContracts
{
    public interface IPlayer
    {
        /// <summary>
        /// Gets the player's display name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the Guid identity of the player.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Determines whether a player has a specified card.
        /// </summary>
        /// <param name="card">The card to look for.</param>
        /// <returns>True if the card exists and false if it does not.</returns>
        bool HasCard(ICard card);
    }

    public class PlayerState : IPlayer
    {

        public PlayerState(string name)
        {
            Name = Name;
            Id = Guid.NewGuid();

            Hand = new List<ICard>();
        }

        public string Name { get; }

        public Guid Id { get; }

        public List<ICard> Hand { get; }

        public bool HasCard(ICard card)
        {
            return Hand.Any(c => c.Equals(card));
        }
    }
}
