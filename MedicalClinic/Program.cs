using MedicalClinic.Core;
using MedicalClinic.DataBase;
using MedicalClinic.DataBase.Connection;
using MedicalClinic.DataBase.Models;
using MedicalClinic.Exceptions;
using MedicalClinic.UI;
using Terminal.Gui;

namespace MedicalClinic;

internal static class Program
{
    public static void Main(string[] args)
    {
        // var context = new Context(ConnString.DbConnectionString);
        // DbHandler.Clear();
        DbHandler.EnsureCreatedDB();
        DbHandler.MigrateDB();
        // DbHandler.Create(new Patient("John", "Doe", "12345678901", "easd@sdd.com", "Warsaw", "Marszalkowska", "00-000"));
        // DbHandler.Create(new Patient("Fred", "Doe", "12345678901", "easd@sdd.com", "Warsaw", "Marszalkowska", "00-000"));
        // DbHandler.Create(new Patient("Barny", "Doe", "12345678901", "easd@sdd.com", "Warsaw", "Marszalkowska", "00-000"));
        // DbHandler.Create(new Patient("Wilson", "Doe", "12345678901", "easd@sdd.com", "Warsaw", "Marszalkowska", "00-000"));

        Application.Init();
        Application.Run(new MainGUI());
        Application.Shutdown();
        
        // Application.Run<MainWindow> ();
        // System.Console.WriteLine ($"Username: {((MainWindow)Application.Top).usernameText.Text}");
        // // Before the application exits, reset Terminal.Gui for clean shutdown
        // Application.Shutdown ();
   
        
        
    }
}