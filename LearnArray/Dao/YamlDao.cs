using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LearnArray.Dao
{
    public class YamlDao : IDao
    {
        public readonly string _filePath;

        public YamlDao(string filePath = "person.yaml")
        {
            _filePath = filePath;

            if (!File.Exists(_filePath))
            {
                // Создаем пустой YAML файл
                File.WriteAllText(_filePath, "");
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

            // Запись обновленных данных в YAML файл
            WriteYaml(people);

            return newId;
        }

        public List<Person> Read()
        {
            List<Person> people = new List<Person>();

            if (File.Exists(_filePath))
            {
                string[] lines = File.ReadAllLines(_filePath);
                Person person = null;

                foreach (var line in lines)
                {
                    if (line.StartsWith("- Id:"))
                    {
                        if (person != null)
                        {
                            people.Add(person);
                        }
                        person = new Person { Id = int.Parse(line.Replace("- Id:", "").Trim()) };
                    }
                    else if (line.StartsWith("  Lastname:") && person != null)
                    {
                        person.Lastname = line.Replace("  Lastname:", "").Trim();
                    }
                    else if (line.StartsWith("  Firstname:") && person != null)
                    {
                        person.Firstname = line.Replace("  Firstname:", "").Trim();
                    }
                    else if (line.StartsWith("  Phone:") && person != null)
                    {
                        person.Phone = line.Replace("  Phone:", "").Trim();
                    }
                    else if (line.StartsWith("  Six:") && person != null)
                    {
                        person.Six = line.Replace("  Six:", "").Trim();
                    }
                }

                if (person != null)
                {
                    people.Add(person);
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

                // Записываем обновленные данные в YAML файл
                WriteYaml(people);
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

                // Записываем обновленные данные в YAML файл
                WriteYaml(people);
            }
            else
            {
                throw new Exception($"Person with Id {person.Id} not found.");
            }
        }

        private void WriteYaml(List<Person> people)
        {
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                foreach (var person in people)
                {
                    writer.WriteLine($"- Id: {person.Id}");
                    writer.WriteLine($"  Lastname: {person.Lastname}");
                    writer.WriteLine($"  Firstname: {person.Firstname}");
                    writer.WriteLine($"  Phone: {person.Phone}");
                    writer.WriteLine($"  Six: {person.Six}");
                }
            }
        }
    }
}