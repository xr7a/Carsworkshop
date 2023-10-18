using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.Properties.Repositories
{
    public class UsersRepository
    {
        public static List<User> users = new List<User>
        {
            new User
            {
                Id = 1,
                FirstName = "Ivan",
                LastName = "Ivanov",
                Email = "fefl;k@yandex.ru",
                PhoneNumber = "89240241221",
                Adress = "Saratov, street of Peace, 106"
            },
            new User
            {
                Id = 2,
                FirstName = "Yaroslava",
                LastName = "Petrovna",
                Adress = "Penza, military town, 16",
                PhoneNumber = "89024528156"
            }
        };
        public List<User> GetAll()
        {
            return users;
        }
        public void Add(User user)
        {
            users.Add(user);
        }
        public void Update(int id, string email, string number, string adress) 
        {
            User userToUpdate = users.Find(c => c.Id == id);
            if(userToUpdate != null) {
            userToUpdate.Email = email;
            userToUpdate.PhoneNumber = number;
            userToUpdate.Adress = adress;
            }
        }
        public void Delete(int id)
        {
            User userToDelete = users.Find(c => c.Id == id);
            if (userToDelete != null)
            {
                users.Remove(userToDelete); 
            }

        }
    }
}
