using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LearnArray.Dao
{
    public class XmlDao : IDao
    {
        public readonly string _filePath;

        public XmlDao(string filePath = "person.xml")
        {
            _filePath = filePath;

            if (!File.Exists(_filePath))
            {
                // Создаем пустой XML файл с корневым элементом Persons
                File.WriteAllText(_filePath, "<?xml version=\"1.0\" encoding=\"utf-8\"?><Persons></Persons>");
            }
        }

        public int Create(Person person)
        {
            List<Person> people = Read();

            // Генерация нового Id (предполагается, что Id уникален)
            int newId = people.Count > 0 ? people.Max(p => p.Id) + 1 : 1;
            person.Id = newId;

            // Добавление новой персоны с присвоением Id
            people.Add(person);

            // Запись обновленных данных в XML файл
            WriteXml(people);

            return newId;
        }

        public List<Person> Read()
        {
            List<Person> people = new List<Person>();

            if (File.Exists(_filePath))
            {
                using (StreamReader reader = new StreamReader(_filePath))
                {
                    string line;
                    Person person = null;

                    while ((line = reader.ReadLine()) != null)
                    {
                        line = line.Trim();

                        if (line.StartsWith("<Person>"))
                        {
                            person = new Person();
                        }
                        else if (line.StartsWith("<Id>") && person != null)
                        {
                            person.Id = int.Parse(line.Replace("<Id>", "").Replace("</Id>", "").Trim());
                        }
                        else if (line.StartsWith("<Lastname>") && person != null)
                        {
                            person.Lastname = line.Replace("<Lastname>", "").Replace("</Lastname>", "").Trim();
                        }
                        else if (line.StartsWith("<Firstname>") && person != null)
                        {
                            person.Firstname = line.Replace("<Firstname>", "").Replace("</Firstname>", "").Trim();
                        }
                        else if (line.StartsWith("<Phone>") && person != null)
                        {
                            person.Phone = line.Replace("<Phone>", "").Replace("</Phone>", "").Trim();
                        }
                        else if (line.StartsWith("<Six>") && person != null)
                        {
                            person.Six = line.Replace("<Six>", "").Replace("</Six>", "").Trim();
                        }
                        else if (line.StartsWith("</Person>") && person != null)
                        {
                            people.Add(person);
                            person = null;
                        }
                    }
                }
            }

            return people;
        }

        public void Update(Person person)
        {
            List<Person> people = Read();

            // Находим персону для обновления по Id
            Person existingPerson = people.FirstOrDefault(p => p.Id == person.Id);

            if (existingPerson != null)
            {
                // Обновляем данные персоны
                existingPerson.Lastname = person.Lastname;
                existingPerson.Firstname = person.Firstname;
                existingPerson.Phone = person.Phone;
                existingPerson.Six = person.Six;

                // Записываем обновленные данные в XML файл
                WriteXml(people);
            }
            else
            {
                throw new Exception($"Person with Id {person.Id} not found.");
            }
        }

        public void Delete(Person person)
        {
            List<Person> people = Read();

            // Находим персону для удаления по Id
            Person personToRemove = people.FirstOrDefault(p => p.Id == person.Id);

            if (personToRemove != null)
            {
                // Удаляем персону из списка
                people.Remove(personToRemove);

                // Записываем обновленные данные в XML файл
                WriteXml(people);
            }
            else
            {
                throw new Exception($"Person with Id {person.Id} not found.");
            }
        }

        private void WriteXml(List<Person> people)
        {
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                writer.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?><Persons>");

                foreach (var person in people)
                {
                    writer.WriteLine("  <Person>");
                    writer.WriteLine($"    <Id>{person.Id}</Id>");
                    writer.WriteLine($"    <Lastname>{person.Lastname}</Lastname>");
                    writer.WriteLine($"    <Firstname>{person.Firstname}</Firstname>");
                    writer.WriteLine($"    <Phone>{person.Phone}</Phone>");
                    writer.WriteLine($"    <Six>{person.Six}</Six>");
                    writer.WriteLine("  </Person>");
                }

                writer.WriteLine("</Persons>");
            }
        }
    }
}