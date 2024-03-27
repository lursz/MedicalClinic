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
        var context = new Context(ConnString.DbConnectionString);
        DbHandler.EnsureCreatedDB();
        DbHandler.MigrateDB();
        var patient = new Patient();

        Application.Init();
        Application.Run(new MedicalClinic.MainGUI());
        Application.Shutdown();
        
        // Application.Run<MainWindow> ();
        // System.Console.WriteLine ($"Username: {((MainWindow)Application.Top).usernameText.Text}");
        // // Before the application exits, reset Terminal.Gui for clean shutdown
        // Application.Shutdown ();
        //
        //
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        // var inputNum = 0;
        // do
        // {
        //     Console.WriteLine("Patients database main menu");
        //     Console.WriteLine("[1] List all customers");
        //     Console.WriteLine("[2] Add random patient");
        //     Console.WriteLine("[3] Add customer");
        //     Console.WriteLine("[4] Edit customer");
        //     Console.WriteLine("[5] Delete customer");
        //     Console.WriteLine("[6] Search customers");
        //     Console.WriteLine("[6] Clear database");
        //     Console.WriteLine("[q] Quit");
        //
        //     inputNum = Console.ReadKey().KeyChar;
        //     Console.WriteLine(inputNum);
        //     Console.WriteLine("\n");
        //
        //     try
        //     {
        //         switch (inputNum)
        //         {
        //             case '1':
        //                 PromptHub.ListAllPatients();
        //                 break;
        //             case '2':
        //                 PromptHub.AddRandomPatientPrompt();
        //                 break;
        //             case '3':
        //                 PromptHub.AddNewPatientPrompt();
        //                 break;
        //             case '4':
        //                 PromptHub.EditPatientPrompt();
        //                 break;
        //             case '5':
        //                 PromptHub.DeletePatientPrompt();
        //                 break;
        //             case '6':
        //                 PromptHub.SearchForPatient(patient);
        //                 break;
        //             case 'c':
        //                 DbHandler.Clear();
        //                 break;
        //             case 'q':
        //                 break;
        //             default:
        //                 Console.WriteLine("Invalid input");
        //                 break;
        //         }
        //     }
        //     catch (BadIdException e)
        //     {
        //         Console.WriteLine(e.Message);
        //     }
        //     catch (Exception e)
        //     {
        //         Console.WriteLine("An error occurred: " + e.Message);
        //     }
        // } while (inputNum != 'q');
    }
}