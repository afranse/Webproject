using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WEBProject.Models
{
    public class Subscriber
    {
        [Key]
        public int SubscriberID { get; set; }
        [Required]
        public string Email { get; set; }

        public Subscriber()
        {

        }

        public Subscriber(int subscriberID, string email)
        {
            SubscriberID = subscriberID;
            Email = email;
        }
    }
}
