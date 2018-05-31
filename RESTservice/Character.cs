using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTservice
{
    public class Character
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Natur { get; set; }
        public string Tradition { get; set; }
        public string Player { get; set; }
        public string Essence { get; set; }
        public string Concept { get; set; }
        public string Chronicle { get; set; }
        public string Demeanor { get; set; }
        public string Cabal { get; set; }
        public byte Strenght { get; set; }
        public byte Dexterity { get; set; }
        public byte Stamina { get; set; }

        public Character()
        {
        }

        public Character(int id, string name, string natur, string tradition, string player, string essence, string concept, string chronicle, string demeanor, string cabal, byte strenght, byte dexterity, byte stamina)
        {
            ID = id;
            Name = name;
            Natur = natur;
            Tradition = tradition;
            Player = player;
            Essence = essence;
            Concept = concept;
            Chronicle = chronicle;
            Demeanor = demeanor;
            Cabal = cabal;
            Strenght = strenght;
            Dexterity = dexterity;
            Stamina = stamina;
        }

    }
}