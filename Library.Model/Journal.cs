using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Journal : LibraryItem
    {
        public static List<string> JournalGanres = new List<string>();

        public List<string> Contributers { get; private set; }
        public List<string> Editors { get; private set; }
        public JournalFrequency Frequency { get; set; }
        public List<string> Ganres { get; private set; }

        public Journal(string title, DateTime publishDate)
            : base(title, publishDate)
        {
            Contributers = new List<string>();
            Editors = new List<string>();
            Ganres = new List<string>();
        }
    }

    public enum JournalFrequency
    {
        Daily,
        Weekly,
        BiWeekly,
        Monthly,
        BiMonthly,
        Qurterly,
        SemiAnnualy,
        Annualy,
        BiAnnualy,
        Other
    }
}

