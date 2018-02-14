using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortHelper
{
    public class PersonName
    {
        private string firstName;
        private string lastName;
        public ObservableCollection<string> Older { get; set; }

        public PersonName(string first, string last)
        {
            this.firstName = first;
            this.lastName = last;
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
    }

    public class NameList : ObservableCollection<PersonName>
    {
        public NameList() : base()
        {
            Add(new PersonName("Willa", "Cather") { Older = new ObservableCollection<string>() { "10", "11", "12" } });
            Add(new PersonName("Isak", "Dinesen"));
            Add(new PersonName("Victor", "Hugo"));
            Add(new PersonName("Jules", "Verne"));
        }
    }

    public class MyPerkList : ObservableCollection<List<Perk>>
    {
        public MyPerkList() : base()
        {
            Add(new Perk(PerkQuality.Common).PicList());
            //Add(new Perk(PerkQuality.Rare));
            //Add(new Perk(PerkQuality.Legendary));
        }
    }
}
