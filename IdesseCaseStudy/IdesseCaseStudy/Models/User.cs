using System;

namespace IdesseCaseStudy.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public Guid CurrentUserId { get; set; }
        public int CardId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string EMail { get; set; }
        public string PositionDescription { get; set; }
        public string ApplicationRole { get; set; }

        public override string ToString()
        {
            return FullName;
        }
    }
}
