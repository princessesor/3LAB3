using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace _3LAB3.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            // create new goods object
            goods chocolate = new goods("chocolate", 19043, "2/3/18");

            // to serialize object to data
            Stream stream = File.Open("goodsdata.goods ", FileMode.Create);

            //to store our data in binary format
            BinaryFormatter bf = new BinaryFormatter();

            // send obj data to file
            bf.Serialize(stream, chocolate);
            stream.Close();

            // to make sure its saved..delete data
            chocolate = null;

            //read obj data
            stream = File.Open("goodsdata.goods", FileMode.Open);

            bf = new BinaryFormatter();

            //get data
            chocolate= (goods)bf.Deserialize(stream);
            stream.Close();
            Console.WriteLine(chocolate.ToString());

            //json serialize

            var goodsjson = JsonConvert.SerializeObject(chocolate);

            //change date 4 fun
            chocolate.Expdate = "4/5/20";


            // xml serialization
            XmlSerializer serializer = new XmlSerializer(typeof(goods));

            using(TextWriter tw =  new StreamWriter(@"C:\Users\Ntomo Princess\Documents\codingfile.xml"))
            {
                serializer.Serialize(tw, chocolate);
            }

            chocolate = null;

            XmlSerializer deserializer = new XmlSerializer(typeof(goods));
            TextReader reader = new StreamReader(@"C:\Users\Ntomo Princess\Documents\codingfile.xml");
            object obj = deserializer.Deserialize(reader);
            chocolate = (goods)obj;
            reader.Close();

            Console.WriteLine(chocolate.ToString());

            List<goods> thegoods = new List<goods>
            {
                new goods("bread", 40098, "6/6/19"),
                 new goods("sweet", 400560, "6/6/19"),
                  new goods("bread", 401348, "6/6/19"),
            };

            using(Stream fs = new FileStream(@"C:\Users\Ntomo Princess\Documents\goods.xml", FileMode.Create,
                FileAccess.Write, FileShare.None))
            {
                XmlSerializer ser2 = new XmlSerializer(typeof
                    (List<goods>));
                ser2.Serialize(fs, thegoods);

            }
            thegoods = null;
            XmlSerializer ser3 = new XmlSerializer(typeof
                (List<goods>));

            using(FileStream fs2 = File.OpenRead(@"C:\Users\Ntomo Princess\Documents\goods.xml"))
            {
                thegoods = (List<goods>)ser3.Deserialize(fs2);
            }
            foreach(goods g in thegoods)
            {
                Console.WriteLine(g.ToString());
            }

           



            Console.ReadLine();
        }
    }
}