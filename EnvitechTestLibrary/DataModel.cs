using System;
using System.Collections.Generic;
using System.Text;

namespace EnvitechTestLibrary
{
    public class DataModel
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
