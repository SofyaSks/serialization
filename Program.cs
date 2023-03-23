using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; // используется для бинарного форматирования
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Text.Json;

// серилизация - процесс сохранения состояния объекта

// бинарный формат - при форматировании сохраняет не только поля данных объекта, но и абсолютное имя каждого поля/типа (серилизоваться будут как открытые так и закрытые данные)


/*// БИНАРНЫЙ ФОРМАТ
namespace serelization
{ 
    
    [Serializable] // атрибут для класса объект которого мы собираемся серилизовать. ПИШЕМ ПЕРЕД К КЛАССОМ К КОТОРОМУ БУДЕТ ОТНОСИТЬСЯ
   public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        int ID { get; set; }

        [NonSerialized] // если какое-то поле не хочется сериализовать прописываем ему это (каждому полю) (обычно константые поля)
        const string Group = "PV221";

        public Person(int n)
        {
            ID = n;
        }

        public override string ToString()
        {
            return $"{Name} {Age} {ID} {Group}";
        }


    } 
    internal class Program
    {
        static void Main(string[] args) 
        { 
            BinaryFormatter bf = new BinaryFormatter();

            Person p1 = new Person(6) { Name = "Sofya", Age = 20 };
            WriteLine(p1);


            try
            {
                using (Stream fs = File.Create("testc.bin"))
                {
                    bf.Serialize(fs, p1);
                }

                WriteLine("Serialize OK");
            }
            catch (Exception ex)
            {
                WriteLine(ex);
            }

            // десириaлизация

            Person p2 = null;
            try
            {
                using (Stream fs = File.OpenRead("testc.bin"))
                {
                    p2 = (Person)bf.Deserialize(fs);
                }
                WriteLine(p2);
                WriteLine("Deserialize OK");
            }
            catch (Exception ex)
            {
                WriteLine(ex);
            }
        }
    }
}
*/

// SOAP (simple object access protocol) - протокол обмена сообщениями при работе с распределенными приложениями
// способ не зависящий от операционной системы

//SOAP
/*namespace serelization
{

    [Serializable] // атрибут для класса объект которого мы собираемся серилизовать. ПИШЕМ ПЕРЕД К КЛАССОМ К КОТОРОМУ БУДЕТ ОТНОСИТЬСЯ
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        int ID { get; set; }

        [NonSerialized] // если какое-то поле не хочется сериализовать прописываем ему это (каждому полю) (обычно константые поля)
        const string Group = "PV221";

        public Person(int n)
        {
            ID = n;
        }

        public override string ToString()
        {
            return $"{Name} {Age} {ID} {Group}";
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            SoapFormatter sf = new SoapFormatter();

            Person p1 = new Person(6) { Name = "Sofya", Age = 20 };
            WriteLine(p1);


            try
            {
                using (Stream fs = File.Create("test.soap"))
                {
                    sf.Serialize(fs, p1);
                }

                WriteLine("Serialize OK");
            }
            catch (Exception ex)
            {
                WriteLine(ex);
            }

            // десириaлизация

            Person p2 = null;
            try
            {
                using (Stream fs = File.OpenRead("test.soap"))
                {
                    p2 = (Person)sf.Deserialize(fs);
                }
                WriteLine(p2);
                WriteLine("Deserialize OK");
            }
            catch (Exception ex)
            {
                WriteLine(ex);
            }
        }
    }
}
*/

// XML // доделать
/*namespace serelization
{

    // атрибут не обязателен
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
        
        [NonSerialized]
        int ID;

        [NonSerialized] // если какое-то поле не хочется сериализовать прописываем ему это (каждому полю) (обычно константые поля)
        public const string Group = "PV221";

        public Person(int n)
        {
            ID = n;
        }

        public Person() { } // требование xml
        public override string ToString()
        {
            return $"{Name} {Age} {ID} {Group}";
        }
        
        // private or protected не сериализуется

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>()
            {
                new Person(6) { Name = "Sofya", Age = 20 },
                new Person(7) { Name = "Sofya", Age = 21 },
                new Person(8) { Name = "Sofya", Age = 22 },
                new Person(9) { Name = "Sofya", Age = 23 }
            };
            XmlSerializer xs = new XmlSerializer(typeof(Person));

            foreach(Person item in people)
            {
                WriteLine(item);
            }


            try
            {
                using (Stream fs = File.Create("test.xml"))
                {
                    xs.Serialize(fs, people );
                }

                WriteLine("Serialize OK");
            }
            catch (Exception ex)
            {
                WriteLine(ex);
            }

            // десириaлизация

            List<Person> p2 = null;
            try
            {
                using (Stream fs = File.OpenRead("test.xml"))
                {
                    p2 = (List<Person>)xs.Deserialize(fs);
                }
                foreach (Person item in people)
                {
                    WriteLine(item);
                }

                WriteLine("Deserialize OK");
            }
            catch (Exception ex)
            {
                WriteLine(ex);
            }
        }
    }
}
*/

// JASON

namespace serelization
{

    //[Serializable] // атрибут для класса объект которого мы собираемся серилизовать. ПИШЕМ ПЕРЕД К КЛАССОМ К КОТОРОМУ БУДЕТ ОТНОСИТЬСЯ
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        int ID { get; set; }

        //NonSerialized] // если какое-то поле не хочется сериализовать прописываем ему это (каждому полю) (обычно константые поля)
        const string Group = "PV221";

        public Person(int n)
        {
            ID = n;
        }

        public override string ToString()
        {
            return $"{Name} {Age} {ID} {Group}";
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            

            Person p1 = new Person(6) { Name = "Sofya", Age = 20 };

            string p1_json = JsonSerializer.Serialize(p1);
            WriteLine(p1);


           /* try
            {
                using (Stream fs = File.Create("test.soap"))
                {
                    sf.Serialize(fs, p1);
                }

                WriteLine("Serialize OK");
            }
            catch (Exception ex)
            {
                WriteLine(ex);
            }

            // десириaлизация

            Person p2 = null;
            try
            {
                using (Stream fs = File.OpenRead("test.soap"))
                {
                    p2 = (Person)sf.Deserialize(fs);
                }
                WriteLine(p2);
                WriteLine("Deserialize OK");
            }
            catch (Exception ex)
            {
                WriteLine(ex);
            }*/
        }
    }
}