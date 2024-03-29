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
        // DbHandler.Clear();
        DbHandler.EnsureCreatedDB();
        DbHandler.MigrateDB();
        
        Application.Init();
        Application.Run(new MainGUI());
        Application.Shutdown();
    }
}