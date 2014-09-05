using System;

namespace Lucy.Core.CustomAttributes
{
    public class CommandAttribute : Attribute
    {
        public string Type { get; set; }
        public string Description { get; set; }
        
        public CommandAttribute()
        {

        }
        
        public CommandAttribute(string type,string description)
        {
            this.Type = type;
            this.Description = description;
        }

    }
}
