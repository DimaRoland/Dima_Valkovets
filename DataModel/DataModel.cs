using System;

namespace DataModel
{
    public class DataModel : Entity<int>
    {
        public DataModel()
            : base(0)
        {
            
        }
        public DataModel(string title, string description, DateTime posted)
            : base(0)
        {
            Title = title;
            Description = description;
            Posted = posted;
        }

        public virtual int id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime Posted { get; set; }
    }
}
