using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnArray
{
    public interface IDao
    {
        public int Create(Person person);
        public List<Person> Read();
        public void Update(Person person);
        public void Delete(Person person);
    }
}
