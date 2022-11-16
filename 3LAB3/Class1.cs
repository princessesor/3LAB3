using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace _3LAB3
{
    [Serializable()]
    public class goods : ISerializable
    {
        public string Name { get; set; }
        public string Expdate { get; set; }
        [JsonIgnore]
        public int Barcode { get; set; }
        [JsonRequired]
       // public string Mandate { get; set; }
        private readonly string Mandate;

        public goods(string mandate) 
        {
            Mandate = mandate;
        }

        public goods(string name = "chocolate",
            int barcode = 0,
            string expdate = " ")
        {
            Name = name;
            Barcode = barcode;
            Expdate = expdate;
        }

        public override string ToString()
        {
            return string.Format("{0} barcode is {1} and expires on {2} ",
                Name, Barcode, Expdate);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Barcode", Barcode);
            info.AddValue("Expdate", Expdate);
            info.AddValue("Mandate", Mandate);
        }
        public goods(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetValue("Name", typeof(string));
            Barcode = (int)info.GetValue("Barcode", typeof(int));
            Expdate = (string)info.GetValue("Expdate", typeof(string));
        }

    }

}

