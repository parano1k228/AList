using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LearnArray.Dao
{
    public class JsonDao : IDao
    {
        public readonly string _filePath;

        public JsonDao(string filePath = "person.json")
        {
            _filePath = filePath;

            if (!File.Exists(_filePath))
            {
                // Создаем пустой JSON файл
                File.WriteAllText(_filePath, "[]");
            }
        }

        public int Create(Person person)
        {
            List<Person> people = Read();

            // Генерация нового Id (предполагается, что Id уникален)
            int newId = people.Count > 0 ? people.Max(p => p.Id) + 1 : 1;

            // Добавление новой персоны с присвоением Id
            person.Id = newId;
            people.Add(person);

            // Запись обновленных данных в JSON файл
            WriteJson(people);

            return newId;
        }

        public List<Person> Read()
        {
            if (!File.Exists(_filePath))
            {
                // Если файл не существует, возвращаем пустой список
                return new List<Person>();
            }

            string json = File.ReadAllText(_filePath);
            List<Person> people = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Person>>(json);
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

                // Записываем обновленные данные в JSON файл
                WriteJson(people);
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

                // Записываем обновленные данные в JSON файл
                WriteJson(people);
            }
            else
            {
                throw new Exception($"Person with Id {person.Id} not found.");
            }
        }

        private void WriteJson(List<Person> people)
        {
            // Сериализация списка людей в JSON и запись в файл
            string json = SerializeJson(people);
            File.WriteAllText(_filePath, json);
        }

        private string SerializeJson<T>(T data)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (StreamWriter sw = new StreamWriter(ms))
                {
                    var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(T));
                    serializer.WriteObject(ms, data);
                    sw.Flush();
                    ms.Position = 0;
                    using (StreamReader sr = new StreamReader(ms))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }

        private T DeserializeJson<T>(string json)
        {
            // Простая реализация десериализации из JSON
            using (MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(json)))
            {
                using (StreamReader sr = new StreamReader(ms))
                {
                    return System.Text.Json.JsonSerializer.Deserialize<T>(sr.ReadToEnd());
                }
            }
        }
    }
}