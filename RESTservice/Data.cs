using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTservice
{
    public class Data
    {

        public int ID { get; set; }
        public string Action { get; set; } // is it a post or a get?
        public string Type { get; set; } // firebase or using restservice
        public double Value { get; set; } // what was the time it took to do the action.
        public int Count { get; set; } // how many objects where retrieved
        public Data()
        {
        }
        public Data(int id, string action, string type, double value, int count)
        {
            ID = id;
            Action = action;
            Type = type;
            Value = value;
            Count = count;
        }
        
    }
}