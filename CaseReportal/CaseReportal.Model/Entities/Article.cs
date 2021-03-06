﻿using System;
using System.Data.SqlTypes;
using Iesi.Collections.Generic;

namespace CaseReportal.Model.Entities
{
    public class Article
    {
        public Article()
        {
            this.Reviews = new HashedSet<Review>();
            Published = null;
        }
        public virtual Int32 Id { get; set; }
        public virtual User User { get; set; }
        public virtual string Title { get; set; }
        public virtual string Case { get; set; }
        public virtual DateTime Creation { get; set; }
        public virtual DateTime? Published { get; set; }
        public virtual ISet<Review> Reviews { get; protected set; }
    }
}