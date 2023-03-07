using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SimpleAPI.Models
{
    public class Hobby
    {
        public Hobby()
        {
            this.Members = new HashSet<Member>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        //public ICollection<Member> Member { get; set; }
        [JsonIgnore]
        public virtual ICollection<Member> Members { get; private set; }
    }
}
