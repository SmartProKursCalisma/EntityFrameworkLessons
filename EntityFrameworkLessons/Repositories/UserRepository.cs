using EntityFrameworkLessons.DbConnection;
using EntityFrameworkLessons.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkLessons.Repositories
{
    public class UserRepository
    {
        AppDbContext db;
        public UserRepository()
        {
            db = new AppDbContext();
        }
        public bool Login(string userName,string password)
        {
            var user = db.Users.FirstOrDefault(x => x.Username == userName && x.Password == password);
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<User> GetAllUser()
        {
            var list = db.Users.ToList();
            return list;
            //return db.Users.ToList();
        }

        public void AddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
        public void UpdateUser(User user)
        {
          User oldUser =  db.Users.FirstOrDefault(x => x.Id == user.Id);
            oldUser.Username = user.Username;
            oldUser.Password = user.Password;
            oldUser.Role = user.Role;
            db.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }
        public List<User> SearchUser(string searchTerm)
        {
            var result = db.Users.Where(x => x.Username.Contains(searchTerm)).ToList();
            return result;
        }
    }
}
