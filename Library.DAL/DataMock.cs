using Library.Model;
using Library.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class DataMock
    {
        public List<LibraryItem> LibraryItems { get; private set; }
        public List<Person> Users { get; private set; }

        private static DataMock _instance;

        public static DataMock Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DataMock();
                return _instance;
            }

        }
        private DataMock()
        {
            LibraryItems = new List<LibraryItem>();
            Users = new List<Person>();
            ISBN.Publishers = new Dictionary<string, int> { };
            ISBN.Countries = new Dictionary<string, int> { };
            Init();
        }

        private void Init()
        {

            #region AddCountries
            ISBN.Publishers.Add("Penguin english library", 22);
            ISBN.Countries.Add("English", 0);
            ISBN.Countries.Add("French", 2);
            ISBN.Countries.Add("German", 3);
            ISBN.Countries.Add("Japanese", 4);
            ISBN.Countries.Add("Russian ", 5);
            ISBN.Countries.Add("Vietnam", 604);
            ISBN.Countries.Add("International Publishers", 92);
            ISBN.Countries.Add("Finland", 952);
            ISBN.Countries.Add("Croatia", 953);
            ISBN.Countries.Add("Bulgaria", 954);
            ISBN.Countries.Add("Sri Lanka", 955);
            ISBN.Countries.Add("Chile", 956);
            ISBN.Countries.Add("Colombia", 958);
            ISBN.Countries.Add("Cuba", 959);
            ISBN.Countries.Add("Greece", 960);
            ISBN.Countries.Add("Slovenia", 961);
            ISBN.Countries.Add("Hungary", 963);
            ISBN.Countries.Add("Iran", 964);
            ISBN.Countries.Add("Israel", 965);
            ISBN.Countries.Add("Ukraine", 966);
            ISBN.Countries.Add("Pakistan", 969);
            ISBN.Countries.Add("Mexico", 970);
            ISBN.Countries.Add("Philippines", 971);
            ISBN.Countries.Add("Romania", 973);
            ISBN.Countries.Add("Thailand", 974);
            ISBN.Countries.Add("Caribbean Community", 976);
            ISBN.Countries.Add("Egypt", 977);
            ISBN.Countries.Add("Nigeria", 978);
            ISBN.Countries.Add("Indonesia", 979);
            ISBN.Countries.Add("Venezuela", 980);
            ISBN.Countries.Add("South Pacific", 982);
            ISBN.Countries.Add("Malaysia", 983);
            ISBN.Countries.Add("Bangladesh", 984);
            ISBN.Countries.Add("Belarus", 985);
            ISBN.Countries.Add("Taiwan", 986);
            ISBN.Countries.Add("Argentina", 987);
            ISBN.Countries.Add("Hongkong", 988);
            ISBN.Countries.Add("Portugal", 989);
            ISBN.Countries.Add("Laos", 9932);
            ISBN.Countries.Add("Syria", 9933);
            ISBN.Countries.Add("Afghanistan", 9936);
            ISBN.Countries.Add("Montenegro", 9940);
            ISBN.Countries.Add("Uzbekistan", 9943);
            ISBN.Countries.Add("Turkey", 9944);
            ISBN.Countries.Add("North Korea", 9946);
            ISBN.Countries.Add("United Arab Emirates", 9948);
            ISBN.Countries.Add("Palestinian Territories", 9950);
            ISBN.Countries.Add("Kosovo", 9951);
            ISBN.Countries.Add("Azerbaijan", 9952);
            ISBN.Countries.Add("Lebanon", 9953);
            ISBN.Countries.Add("Cameroon", 9956);
            ISBN.Countries.Add("Jordan", 9957);
            ISBN.Countries.Add("Bosnia and Herzegovina", 9958);
            ISBN.Countries.Add("Libya", 9959);
            ISBN.Countries.Add("Saudi Arabia", 9960);
            ISBN.Countries.Add("Algeria", 9961);
            ISBN.Countries.Add("Panama", 9962);
            ISBN.Countries.Add("Cyprus", 9963);
            ISBN.Countries.Add("Kazakhstan", 9965);
            ISBN.Countries.Add("Kenya", 9966);
            ISBN.Countries.Add("Kyrgyzstan", 9967);
            ISBN.Countries.Add("Uganda", 9970);
            ISBN.Countries.Add("Singapore", 9971);
            ISBN.Countries.Add("Peru", 9972);
            ISBN.Countries.Add("Tunisia", 9973);
            ISBN.Countries.Add("Uruguay", 9974);
            ISBN.Countries.Add("Republic of Moldova", 9975);
            ISBN.Countries.Add("Costa Rica", 9977);
            ISBN.Countries.Add("Ecuador", 9978);
            ISBN.Countries.Add("Island", 9979);
            ISBN.Countries.Add("Papua New Guinea", 9980);
            ISBN.Countries.Add("Morocco", 9981);
            ISBN.Countries.Add("Zambia", 9982);
            ISBN.Countries.Add("Gambia", 9983);
            ISBN.Countries.Add("Latvia", 9984);
            ISBN.Countries.Add("Estonia", 9985);
            ISBN.Countries.Add("Lithuania", 9986);
            ISBN.Countries.Add("Tanzania", 9987);
            ISBN.Countries.Add("Ghana", 9988);
            ISBN.Countries.Add("Macedonia", 9989);
            ISBN.Countries.Add("Gabon", 99902);
            ISBN.Countries.Add("Netherlands Antilles(Curaçao)", 99904);
            ISBN.Countries.Add("Sierra Leone", 99910);
            ISBN.Countries.Add("Lesotho", 99911);
            ISBN.Countries.Add("Suriname", 99914);
            ISBN.Countries.Add("Maldives", 99915);
            ISBN.Countries.Add("Brunei", 99917);
            ISBN.Countries.Add("Benin", 99919);
            ISBN.Countries.Add("Andorra", 99920);
            ISBN.Countries.Add("Qatar", 99921);
            ISBN.Countries.Add("El Salvador", 99923);
            ISBN.Countries.Add("Seychelles", 99931);
            ISBN.Countries.Add("Dominican Republic", 99934);
            ISBN.Countries.Add("Bhutan", 99936);
            ISBN.Countries.Add("Guatemala", 99939);
            ISBN.Countries.Add("Georgia", 99940);
            ISBN.Countries.Add("Armenia", 99941);
            ISBN.Countries.Add("Sudan", 99942);
            ISBN.Countries.Add("Ethiopia", 99944);
            ISBN.Countries.Add("Namibia", 99945);
            ISBN.Countries.Add("Nepal", 99946);
            ISBN.Countries.Add("Eritrea", 99948);
            ISBN.Countries.Add("Mauritius", 99949);
            ISBN.Countries.Add("Democratic Republic of the Congo", 99951);
            ISBN.Countries.Add("Mali", 99952);
            ISBN.Countries.Add("Republika Srpska", 99955);
            ISBN.Countries.Add("Albania", 99956);
            ISBN.Countries.Add("Malta", 99957);
            ISBN.Countries.Add("Bahrain", 99958);
            ISBN.Countries.Add("Luxembourg", 99959);
            ISBN.Countries.Add("Malawi", 99960);
            ISBN.Countries.Add("Cambodia", 99963);
            ISBN.Countries.Add("Nicaragua", 99964);
            ISBN.Countries.Add("Macau", 99965);
            ISBN.Countries.Add("Kuwait", 99966);
            ISBN.Countries.Add("Paraguay", 99967);
            ISBN.Countries.Add("Botswana", 99968);
            ISBN.Countries.Add("Oman", 99969);
            ISBN.Countries.Add("Haiti", 99970);
            ISBN.Countries.Add("Myanmar", 99971);
            ISBN.Countries.Add("Faroe Islands", 99972);
            ISBN.Countries.Add("Mongolia", 99973);
            ISBN.Countries.Add("Bolivia", 99974);
            ISBN.Countries.Add("Tajikistan", 99975);
            ISBN.Countries.Add("Rwanda", 99977);
            ISBN.Countries.Add("Honduras", 99979);
            #endregion

            #region AddKnownAuthors
            Book.KnownAuthors.Add("Jane Austen");
            Book.KnownAuthors.Add("Harper Lee");
            Book.KnownAuthors.Add("F. Scott Fitzgerald");
            #endregion

            #region AddBookGenres
            Book.BookGenres.Add("Action and adventure");
            Book.BookGenres.Add("Art / architecture");
            Book.BookGenres.Add("Alternate history");
            Book.BookGenres.Add("Autobiography");
            Book.BookGenres.Add("Anthology");
            Book.BookGenres.Add("Biography");
            Book.BookGenres.Add("Chick lit");
            Book.BookGenres.Add("Business / economics");
            Book.BookGenres.Add("Children's");
            Book.BookGenres.Add("Crafts / hobbies");
            Book.BookGenres.Add("Classic");
            Book.BookGenres.Add("Cookbook");
            Book.BookGenres.Add("Comic book");
            Book.BookGenres.Add("Diary");
            Book.BookGenres.Add("Coming-of-age");
            Book.BookGenres.Add("Dictionary");
            Book.BookGenres.Add("Crime");
            Book.BookGenres.Add("Encyclopedia");
            Book.BookGenres.Add("Drama");
            Book.BookGenres.Add("Guide");
            Book.BookGenres.Add("Fairytale");
            Book.BookGenres.Add("Health / fitness");
            Book.BookGenres.Add("Fantasy");
            Book.BookGenres.Add("History");
            Book.BookGenres.Add("Graphic novel");
            Book.BookGenres.Add("Home and garden");
            Book.BookGenres.Add("Historical fiction");
            Book.BookGenres.Add("Humor");
            Book.BookGenres.Add("Horror");
            Book.BookGenres.Add("Journal");
            Book.BookGenres.Add("Mystery");
            Book.BookGenres.Add("Math");
            Book.BookGenres.Add("Paranormal romance");
            Book.BookGenres.Add("Memoir");
            Book.BookGenres.Add("Picture book");
            Book.BookGenres.Add("Philosophy");
            Book.BookGenres.Add("Poetry");
            Book.BookGenres.Add("Prayer");
            Book.BookGenres.Add("Political thriller");
            Book.BookGenres.Add("Religion, spirituality, and new age");
            Book.BookGenres.Add("Romance");
            Book.BookGenres.Add("Textbook");
            Book.BookGenres.Add("Satire");
            Book.BookGenres.Add("True crime");
            Book.BookGenres.Add("Science fiction");
            Book.BookGenres.Add("Review");
            Book.BookGenres.Add("Short story");
            Book.BookGenres.Add("Science");
            Book.BookGenres.Add("Suspense");
            Book.BookGenres.Add("Self help");
            Book.BookGenres.Add("Thriller");
            Book.BookGenres.Add("Sports and leisure");
            Book.BookGenres.Add("Western");
            Book.BookGenres.Add("Travel");
            Book.BookGenres.Add("Young adult");
            Book.BookGenres.Add("True crime");
            #endregion

            #region MakeBooks

            var book1 = new Book("Pride and Prejudice", new DateTime(2012, 6, 12), 123);
            book1.Authors.Add("Jane Austen");
            book1.Publisher = "Penguin english library";
            book1.Synopsis = "A lawyer's advice to his children as he defends the real mockingbird of Harper Lee's classic novel - a black man falsely charged with the rape of a white girl. Through the young eyes of Scout and Jem Finch, Harper Lee explores with exuberant humour the irrationality of adult attitudes to race and class in the Deep South of the 1930s. The conscience of a town steeped in prejudice, violence and hypocrisy is pricked by the stamina of one man's struggle for justice. But the weight of history will only tolerate so much.";
            book1.Genres.Add("Action and adventure");
            book1.Genres.Add("Classic");
            book1.Genres.Add("Drama");
            book1.Genres.Add("Historical fiction");
            book1.Revision = 103;
            book1.Price = 24;

            var book2 = new Book("To Kill A Mockingbird", new DateTime(2015, 4, 6), 145);
            book2.Authors.Add("Harper Lee");
            book2.Publisher = "Penguin english library";
            book2.Synopsis = "When Elizabeth Bennet first meets eligible bachelor Fitzwilliam Darcy, she thinks him arrogant and conceited; he is indifferent to her good looks and lively mind. When she later discovers that Darcy has involved himself in the troubled relationship between his friend Bingley and her beloved sister Jane, she is determined to dislike him more than ever. In the sparkling comedy of manners that follows, Jane Austen shows the folly of judging by first impressions and superbly evokes the friendships, gossip and snobberies of provincial middle-class life.";
            book2.Genres.Add("Young adult");
            book2.Genres.Add("Classic");
            book2.Genres.Add("Drama");
            book2.Genres.Add("Historical fiction");
            book2.Revision = 156;
            book2.Price = 100;

            var book3 = new Book("The Great Gatsby", new DateTime(2000, 2, 24), 145);
            book3.Authors.Add("F. Scott Fitzgerald");
            book3.Publisher = "Penguin english library";
            book3.Synopsis = "Young, handsome and fabulously rich, Jay Gatsby is the bright star of the Jazz Age, but as writer Nick Carraway is drawn into the decadent orbit of his Long Island mansion, where the party never seems to end, he finds himself faced by the mystery of Gatsby's origins and desires. Beneath the shimmering surface of his life, Gatsby is hiding a secret: a silent longing that can never be fulfilled. And soon, this destructive obsession will force his world to unravel.";
            book3.Genres.Add("Classic");
            book3.Genres.Add("Drama");
            book3.Genres.Add("Historical fiction");
            book3.Revision = 53;
            book3.Price = 90;

            var journal1 = new Journal("Teens Magazine", DateTime.Now);
            journal1.Editors.Add("Mark zober");
            journal1.Contributers.Add("Tiler Noon");
            journal1.Frequency = JournalFrequency.Daily;
            journal1.Ganres.Add("Entertament");
            #endregion

            Employee jim = new Employee("JimK", "123123");
            Employee vad = new Employee("vadSlayer", "321321");
            Customer bob = new Customer("Bob");
            Employee One = new Employee("1", "1");

            Users.AddRange(new[] { vad, jim ,One});
            Users.Add(bob);
            LibraryItems.AddRange(new[] { book1, book2, book3 });
            LibraryItems.Add(journal1);
        }
    }
}
