namespace AuthPage.Models
{
    public class UserPicker
    {
        public int id { get; set; }
        public string name { get; set; }
        public string fullName { get; set; }

        public static IEnumerable<UserPicker> GetInspectors()
        {
            string[] Countries = { "Albania", "Andorra", "Armenia", "Austria", "Azerbaijan", "Belarus", "Belgium", "Bosnia & Herzegovina", "Bulgaria", "Croatia", "Cyprus", "Czech Republic", "Denmark", "Estonia", "Finland", "France", "Georgia", "Germany", "Greece", "Hungary", "Iceland", "Ireland", "Italy", "Kosovo", "Latvia", "Liechtenstein", "Lithuania", "Luxembourg", "Macedonia", "Malta", "Moldova", "Monaco", "Montenegro", "Netherlands", "Norway", "Poland", "Portugal", "Romania", "Russia", "San Marino", "Serbia", "Slovakia", "Slovenia", "Spain", "Sweden", "Switzerland", "Turkey", "Ukraine", "United Kingdom", "Vatican City" };
            IEnumerable<UserPicker> IndexedUsers = Enumerable.Range(1, Countries.Length).Select(x => new UserPicker { fullName = Countries[x - 1], id = x });
            return IndexedUsers;
        }

    }
}
