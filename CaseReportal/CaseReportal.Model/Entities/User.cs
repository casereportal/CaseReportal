using System;

namespace CaseReportal.Model.Entities
{
    public class User
    {
        public virtual Int32 Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual string Nonce { get; set; }
        public virtual Role Role { get; set; }
    }
}