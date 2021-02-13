using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace HelloWorldService
{
    [DataContract]
    public class UserModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public bool PreferredCustomer { get; set; }

        [DataMember]
        public float Income { get; set; }

        [DataMember]
        public List<int> HighScores { get; set; }

        public UserModel(int id, string name, bool prefferedCustomer, float income, List<int> highScores)
        {
            this.Id = id;
            this.Name = name;
            this.PreferredCustomer = prefferedCustomer;
            this.Income = income;
            this.HighScores = highScores;
        }
    }
}