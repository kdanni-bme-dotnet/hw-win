using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_WPF_ControlExample
{
    class PersonManager
    {
        private static readonly Lazy<ObservableCollection<Person>> peopleHolder
            = new Lazy<ObservableCollection<Person>>(
                () => {
                    var rnd = new Random();
                    return new ObservableCollection<Person>
                    (
                        Enumerable.Range(0, 5).Select(i =>
                        new Person
                        {
                            Id = Guid.NewGuid(),
                            Name = "Person " + i,
                            Age = rnd.Next(20, 100)
                        }
                    ));
                });

        public static ObservableCollection<Person> People
        {
            get { return peopleHolder.Value; }
        }
    }
}
