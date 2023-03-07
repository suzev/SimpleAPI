using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleAPI.Models
{
    public class Member
    {
        public Member()
        {
            this.Hobbies = new HashSet<Hobby>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [EmailAddress]
        [RegularExpression(@"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must provide 10 digit number")]
        [Phone]
        [RegularExpression(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$")]
        public string Phone { get; set; }
        public virtual ICollection<Hobby> Hobbies { get; set; }
    }
}
