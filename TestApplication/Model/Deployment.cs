using Newtonsoft.Json;
using System;

namespace TestApplication.Model
{
    //C# object class encaplucation using properties
    // which does not requires getter and setters method implementations. 
    public class Deployment
    {
        private Guid id;
        private string name;
        private string description;
        private string categories;

        // it is used to ignore the id field in JSON object
        [JsonIgnore]
        public Guid Id {
            get { return id; }
            set { id = value; }
        }
        public string Name {
            get {return name; }
            set {name = value; }
        }
        public string Description {
            get { return description; }
            set { description = value; }
        }
        public string Categories {
            get { return categories; }
            set { categories = value; }
        }
    }
}

