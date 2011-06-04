using System;

namespace CaseReportal.Model.Entities
{
    public class Review
    {
        public virtual Int32 Id { get; set; }
        public virtual Article Article { get; set; }
        public virtual User Reviewer { get; set; }
        public virtual string Comment { get; set; }
        public virtual bool Approved { get; set; }
        public virtual DateTime Created { get; set; }
    }
}