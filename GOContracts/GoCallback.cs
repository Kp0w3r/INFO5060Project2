﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GOContracts
{
    [DataContract]
    class GoCallback
    {
        [DataMember]
        public List<IPlayer> Players { get; set; }
        [DataMember]
        public int NumCards { get; private set; }
        [DataMember]
        public int NumDecks { get; private set; }
        [DataMember]
        public bool EmptyHand { get; private set; }

        public GoCallback(int c, int d, bool e)
        {
            NumCards = c;
            NumDecks = d;
            EmptyHand = e;
        }
    }
}