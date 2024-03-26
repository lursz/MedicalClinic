
using MedicalClinic.DataBase;
using MedicalClinic.DataBase.Connection;
using MedicalClinic.DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinic;

static class Program
{
    public static void Main(string[] args)
    {
        var context = new DataBase.Context(ConnString.DbConnectionString);
        DbHandler.EnsureCreatedDB();
        DbHandler.MigrateDB();
        DbHandler.Create(new Patient{Id = 1, FirstName = "Jan", LastName = "Kowalski", PESEL = "12345678901", Gender = "male", Email = "email", City = "city", Street = "street", ZipCode = "zipCode"});   

        
        char input_key = ' ';

        do {
            Console.WriteLine("Customers database main menu");
            Console.WriteLine("[a] Add customer");
            Console.WriteLine("[e] Edit customer");
            Console.WriteLine("[d] Delete customer");
            Console.WriteLine("[s] Search customers");
            Console.WriteLine("[l] List all customers");
            Console.WriteLine("[v] Save database to file");
            Console.WriteLine("[r] Load database from file");
            Console.WriteLine("[c] Clear database");
            Console.WriteLine("[q] Quit");
        
            input_key = Console.ReadKey().KeyChar;
        
            try {
                switch (input_key) {
                    case 'a':
                        AddNewCustomerPrompt(database);
                        break;
                    case 'e':
                        EditCustomerPrompt(database);
                        break;
                    case 'd':
                        DeleteCustomerPrompt(database);
                        break;
                    case 's':
                        SearchCustomersPrompt(database);
                        break;
                    case 'l':
                        ListAllCustomers(database);
                        break;
                    case 'v':
                        SaveDatabaseToFile(database);
                        break;
                    case 'r':
                        LoadDatabaseFromFile(database);
                        break;
                    case 'c':
                        database.Clear();
                        break;
                    case 'q':
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            } catch (BadIdException e) {
                Console.WriteLine(e.Message);
            } catch (Exception e) {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        } while(input_key != 'q');
        
        
        
        
        
    }
}