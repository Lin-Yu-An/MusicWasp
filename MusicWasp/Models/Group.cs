using System;
using System.Collections.Generic;
using System.Text;

namespace MusicWasp.Models
{
    public class Group
    {
        public int GroupID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateOnly CreatedDate { get; set; }
        public User CreatedBy { get; set; }
        public List<User> Members { get; set; }

        public Group()
        {
            
        }

        public void HostEvent()
        {

        }
        public void CancelEvent()
        {

        }

        public override string ToString()
        {
            return "This is a group";
        }
    }
}
