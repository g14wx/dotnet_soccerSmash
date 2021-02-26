using System.Collections.Generic;
using System.Runtime.Serialization;
using EFLib.Models;
using Newtonsoft.Json;

namespace SoccerSmash.ViewModel
{ 
    [JsonObject(IsReference = true)] 
    public class TeamEditViewModel
    {
        [JsonIgnore] 
        [IgnoreDataMember] 
        public Team team { get; set; }
        [JsonIgnore] 
        [IgnoreDataMember] 
        public List<Player> players { get; set; }
    }
}