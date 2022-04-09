
namespace CatWorx.BadgeMaker
{
    class Employee
    {
        public string FirstName;
        public string LastName;
        public int Id;
        public string PhotoUrl;
        public Employee(string firstName, string lastName, int id, string photoUrl) {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            PhotoUrl = photoUrl;
        }

        public string GetName() {
            return FirstName + " " + LastName;
        }
        public int GetID() {
            return Id;
        }
        public string GetPhotoURL() {
            return PhotoUrl;
        }
        public string GetCompanyName() {
            return "Cat Worx";
        }
    }
}