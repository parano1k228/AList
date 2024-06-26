using NUnit.Framework;
using LearnArray.Dao;
using System;
using System.Collections.Generic;
using System.IO;

namespace LearnArray.Tests
{
    [TestFixture(typeof(XmlDao))]
    [TestFixture(typeof(YamlDao))]
    [TestFixture(typeof(CsvDao))]
    [TestFixture(typeof(JsonDao))]
    public class DaoTest<T> where T : IDao
    {
        private IDao dao;
        private string _filePath;

        [SetUp]
        public void Setup()
        {
            _filePath = GetUniqueFilePath();
            dao = (IDao)Activator.CreateInstance(typeof(T), _filePath);

            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
        }

        private string GetUniqueFilePath()
        {
            string directory = AppDomain.CurrentDomain.BaseDirectory; // Получаем базовый каталог приложения

            string typeName = typeof(T).Name; // Получаем имя типа (например, "XmlDao", "JsonDao")
            string fileName = $"test_person_{typeName.ToLower()}.dat"; // Создаем уникальное имя файла на основе типа DAO

            return Path.Combine(directory, fileName);
        }

        [Test]
        public void CreateTest()
        {
            var person = new Person
            {
                Lastname = "Doe",
                Firstname = "John",
                Phone = "123-456-7890",
                Six = "M"
            };

            int newId = dao.Create(person);
            Assert.AreEqual(1, newId);

            var people = dao.Read();
            Assert.AreEqual(1, people.Count);
            Assert.AreEqual("Doe", people[0].Lastname);
            Assert.AreEqual("John", people[0].Firstname);
            Assert.AreEqual("123-456-7890", people[0].Phone);
            Assert.AreEqual("M", people[0].Six);
        }

        [Test]
        public void ReadTest()
        {
            var person1 = new Person
            {
                Lastname = "Doe",
                Firstname = "John",
                Phone = "123-456-7890",
                Six = "M"
            };

            var person2 = new Person
            {
                Lastname = "Smith",
                Firstname = "Jane",
                Phone = "098-765-4321",
                Six = "F"
            };

            dao.Create(person1);
            dao.Create(person2);

            var people = dao.Read();
            Assert.AreEqual(2, people.Count);

            Assert.AreEqual("Doe", people[0].Lastname);
            Assert.AreEqual("John", people[0].Firstname);
            Assert.AreEqual("123-456-7890", people[0].Phone);
            Assert.AreEqual("M", people[0].Six);

            Assert.AreEqual("Smith", people[1].Lastname);
            Assert.AreEqual("Jane", people[1].Firstname);
            Assert.AreEqual("098-765-4321", people[1].Phone);
            Assert.AreEqual("F", people[1].Six);
        }

        [Test]
        public void UpdateTest()
        {
            var person = new Person
            {
                Lastname = "Doe",
                Firstname = "John",
                Phone = "123-456-7890",
                Six = "M"
            };

            int newId = dao.Create(person);

            var updatedPerson = new Person
            {
                Id = newId,
                Lastname = "Doe",
                Firstname = "Johnny",
                Phone = "987-654-3210",
                Six = "M"
            };

            dao.Update(updatedPerson);

            var people = dao.Read();
            Assert.AreEqual(1, people.Count);
            Assert.AreEqual("Doe", people[0].Lastname);
            Assert.AreEqual("Johnny", people[0].Firstname);
            Assert.AreEqual("987-654-3210", people[0].Phone);
            Assert.AreEqual("M", people[0].Six);
        }

        [Test]
        public void DeleteTest()
        {
            var person = new Person
            {
                Lastname = "Doe",
                Firstname = "John",
                Phone = "123-456-7890",
                Six = "M"
            };

            int newId = dao.Create(person);

            dao.Delete(person);

            var people = dao.Read();
            Assert.AreEqual(0, people.Count);
        }
    }
}