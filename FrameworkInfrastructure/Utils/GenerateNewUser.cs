using FrameworkInfrastructure.Models;

namespace FrameworkInfrastructure.Utils
{
    public class GenerateNewUser
    {
        private static readonly Random random = new Random();

        // Method for generating random user data
        public static User CreateUser()
        {
            return new User 
            {
               FirstName = Faker.Name.First(),
               LastName = Faker.Name.Last(),
               Address = Faker.Address.StreetAddress(),
               City = Faker.Address.City(),
               State = Faker.Address.UsState(),
               ZipCode = Faker.Address.ZipCode(),
               Phone = Faker.Phone.Number(),
               SSN = random.Next(1000, 9999),
               UserName = Faker.Internet.UserName(),
               Password = GenerateRandomPassword(12)

            };
        }

        // Method for generating random password
        private static string GenerateRandomPassword(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()";

            return new string(Enumerable.Repeat(chars, length)
                                        .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
