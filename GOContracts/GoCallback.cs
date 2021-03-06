﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace GOContracts
{
    [ServiceContract]
    public interface ICallback
    {
        /// <summary>
        /// Updates data on client side with contents of DataContract
        /// </summary>
        /// <param name="callback"></param>
        [OperationContract(IsOneWay = true)]
        void UpdateGameState(GoCallback callback);
    }


    [DataContract]
    public class GoCallback
    {

        [DataMember]
        public List<PlayerState> Players { get; set; }
        [DataMember]
        public int CardsInDeck { get; private set; }

        [DataMember]
        public Guid Winner { get; set; }

        [DataMember]
        public bool IsGameOver { get; set; }

        public GoCallback(int cardsInDeck, List<PlayerState> players)
        {
            this.CardsInDeck = cardsInDeck;
            this.Players = players;
        }
    }
}