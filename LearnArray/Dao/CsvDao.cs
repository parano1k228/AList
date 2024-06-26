using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LearnArray.Dao
{
    public class CsvDao : IDao
    {
        public readonly string _filePath;

        public CsvDao(string filePath = "person.csv")
        {
            _filePath = filePath;

            if (!File.Exists(_filePath))
            {
                // Создаем пустой файл CSV с заголовком
                using (StreamWriter writer = new StreamWriter(_filePath))
                {
                    writer.WriteLine("Id,Lastname,Firstname,Phone,Six");
                }
            }
        }

        public int Create(Person person)
        {
            // Чтение всех записей из CSV файла (если требуется)
            List<Person> people = Read();

            // Генерация нового Id (предполагается, что Id уникален)
            int newId = people.Count > 0 ? people.Max(p => p.Id) + 1 : 1;

            // Добавление новой персоны
            person.Id = newId;
            people.Add(person);

            // Запись обновленных данных в CSV файл
            WriteCsv(people);

            return newId;
        }

        private void WriteCsv(List<Person> people)
        {
            // Запись данных в файл CSV
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                writer.WriteLine("Id,Lastname,Firstname,Phone,Six");
                foreach (Person person in people)
                {
                    writer.WriteLine($"{person.Id},{person.Lastname},{person.Firstname},{person.Phone},{person.Six}");
                }
            }
        }

        public List<Person> Read()
        {
            if (!File.Exists(_filePath))
            {
                // Если файл не существует, возвращаем пустой список
                return new List<Person>();
            }

            List<Person> people = new List<Person>();

            // Чтение CSV файла и добавление данных в список
            using (StreamReader reader = new StreamReader(_filePath))
            {
                // Пропускаем заголовок
                reader.ReadLine();

                // Читаем остальные строки файла
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split(',');

                    // Парсим данные персоны из строки CSV
                    int id = int.Parse(parts[0]);
                    string lastname = parts[1];
                    string firstname = parts[2];
                    string phone = parts[3];
                    string six = parts[4];

                    // Создаем объект Person и добавляем его в список
                    Person person = new Person
                    {
                        Id = id,
                        Lastname = lastname,
                        Firstname = firstname,
                        Phone = phone,
                        Six = six
                    };

                    people.Add(person);
                }
            }

            return people;
        }

        public void Update(Person updatedPerson)
        {
            List<Person> people = Read();

            // Находим персону для обновления по Id
            Person existingPerson = people.FirstOrDefault(p => p.Id == updatedPerson.Id);

            if (existingPerson != null)
            {
                // Обновляем данные персоны
                existingPerson.Lastname = updatedPerson.Lastname;
                existingPerson.Firstname = updatedPerson.Firstname;
                existingPerson.Phone = updatedPerson.Phone;
                existingPerson.Six = updatedPerson.Six;

                // Записываем обновленные данные в CSV файл
                WriteCsv(people);
            }
            else
            {
                throw new Exception($"Person with Id {updatedPerson.Id} not found.");
            }
        }

        public void Delete(Person personToDelete)
        {
            List<Person> people = Read();

            // Находим персону для удаления по Id
            Person personToRemove = people.FirstOrDefault(p => p.Id == personToDelete.Id);

            if (personToRemove != null)
            {
                // Удаляем персону из списка
                people.Remove(personToRemove);

                // Записываем обновленные данные в CSV файл
                WriteCsv(people);
            }
            else
            {
                throw new Exception($"Person with Id {personToDelete.Id} not found.");
            }
        }
    }
}