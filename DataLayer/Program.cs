using DataLayer.Database;
using DataLayer.Model;
using DataLayer.Loggers;
using Welcome.Others;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace DataLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new DatabaseLogger();

            using (var context = new DatabaseContext())
            {
                context.Database.EnsureCreated();

                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("1. List All Users");
                    Console.WriteLine("2. Add New User");
                    Console.WriteLine("3. Delete Existing User");
                    Console.WriteLine("4. Test Login");
                    Console.WriteLine("5. View DB logs");
                    Console.WriteLine("6. Exit");
                    Console.Write("Select an option: ");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            var allUsers = context.Users.ToList();
                            Console.WriteLine("\nExisting Users:");
                            foreach (var u in allUsers)
                            {
                                Console.WriteLine($" ID: {u.Id}, Name: {u.Name}, Role: {u.Role}");
                            }
                            break;

                        case "2":
                            Console.Write("Enter Name: ");
                            string newName = Console.ReadLine();
                            Console.Write("Enter Password: ");
                            string newPass = Console.ReadLine();

                            var newUser = new DatabaseUser()
                            {
                                Name = newName,
                                Password = newPass,
                                Role = UserRolesEnum.STUDENT,
                                Expires = DateTime.Now.AddYears(1)
                            };

                            context.Users.Add(newUser);
                            context.SaveChanges();

                            logger.LogInformation($"Added new user: {newName}");
                            Console.WriteLine("User added successfully.");
                            break;

                        case "3":
                            Console.Write("Enter Name to delete: ");
                            string deleteName = Console.ReadLine();

                            var userToDelete = context.Users.FirstOrDefault(u => u.Name == deleteName);
                            if (userToDelete != null)
                            {
                                context.Users.Remove(userToDelete);
                                context.SaveChanges();
                                logger.LogWarning($"Deleted user: {deleteName}");
                                Console.WriteLine("User deleted.");
                            }
                            else
                            {
                                Console.WriteLine("User not found.");
                            }
                            break;

                        case "4":
                            Console.Write("Enter Username: ");
                            string inputName = Console.ReadLine();
                            Console.Write("Enter Password: ");
                            string inputPass = Console.ReadLine();

                            if (isValidUser(inputName, inputPass))
                            {
                                Console.WriteLine("Valid user");
                                logger.LogInformation($"Successful login test for: {inputName}");
                            }
                            else
                            {
                                Console.WriteLine("Invalid data");
                                logger.LogWarning($"Failed login test for: {inputName}");
                            }
                            break;
                        case "5":
                            Console.WriteLine("\n Logs ");
                            var logs = context.Logs.OrderByDescending(l => l.Timestamp).ToList();

                            if (logs.Any())
                            {
                                foreach (var log in logs)
                                {
                                    Console.WriteLine($"[{log.Timestamp}] ID: {log.Id} | Message: {log.Message}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No logs found");
                            }
                            break;

                        case "6":
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Invalid selection.");
                            break;
                    }
                }

                bool isValidUser(string name, string password)
                {
                    return context.Users.Any(u => u.Name == name && u.Password == password);
                }
            }
        }
    }
}