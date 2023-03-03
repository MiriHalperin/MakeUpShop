using System.Text.Json;
using entities;

namespace Repository
{
    public class UsersRepository
    {
        string filePath = "./users.txt";
        public User FindUser(User userToFind)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User userFromFile = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (userFromFile.Email == userToFind.Email && userFromFile.Password == userToFind.Password)
                        return userFromFile;
                }

                return null;
            }
        }
        public bool IsUserNameExist(string Email)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User userFromFile = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (userFromFile.Email == Email)
                        return true;
                }
                return false;
            }
        }
        public User AddUser(User newUser)
        {
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            newUser.Id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(newUser);
            System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);
            return newUser;
        }
        public void UpdateUser(int id, User userToUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {

                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Id == id)
                        textToReplace = currentUserInFile;
                }
            }
            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText(filePath, text);
            }

        }
        public User GetUser(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Id == id)
                        return user;
                }
            }
            return null;
        }
    }
}
