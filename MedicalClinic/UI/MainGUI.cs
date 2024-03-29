using System.Data;
using MedicalClinic.Core;
using MedicalClinic.DataBase;
using MedicalClinic.DataBase.Models;
using MedicalClinic.UI.Dialogs;
using Terminal.Gui;

namespace MedicalClinic.UI
{


    public partial class MainGUI
    {

        public MainGUI()
        {
            SearchSystem searchSystem = new();
            
            InitializeComponent();
            Title = "Medical Clinic (Ctrl+Q to quit)";
            // Normal print
            PrintTable(DbHandler.GetPatients());
            
            // Buttons
            buttonQuit.Clicked += () => Application.RequestStop();
            buttonHelp.Clicked += () => MessageBox.ErrorQuery("Help", "This is a simple medical clinic app in retro style. App was built in .NET 8, fully supports both mouse and keyboard and runs on Windows and Unix (Mac/Linux).", "Ok");
            buttonHelp2.Clicked += () => MessageBox.ErrorQuery("Help", "Search functionality is based on regex. You can search for specific values in columns by typing: key:{value}. \nFor instance: FirstName:{John}", "Ok");
            buttonAdd.Clicked += () =>
            {
                var addDialog = new AddDialog();
                addDialog.ShowDialog();
                PrintTable(DbHandler.GetPatients());
            };
            buttonAddRandom.Clicked += () =>
            {
                PatientLogic.AddRandomPatient();
                PrintTable(DbHandler.GetPatients());
            };


            
            // searchBar
            searchBar.TextChanging += (query) =>
            {
                searchSystem.SetRequirements(query.NewText.ToString());
                PrintTable(searchSystem.Search(DbHandler.GetPatients()));
            };

            
            // Table Click 
            patientList.SelectedCellChanged += (args) =>
            {
                var selectedPatient = DbHandler.Get<Patient>(int.Parse(patientList.Table.Rows[args.NewRow][0].ToString()));
                
                var dialog = MessageBox.Query(50, 10, "Patient details", selectedPatient.ToNewLineString(), "Edit", "Delete", "Cancel");
                switch (dialog)
                {
                    case 0:
                    {
                        // Edit
                        var id = int.Parse(patientList.Table.Rows[args.NewRow][0].ToString());
                        var editDialog = new EditDialog(id);
                        editDialog.ShowDialog(selectedPatient);
                        PrintTable(DbHandler.GetPatients());
                        break;
                    }
                    case 1:
                        // Delete
                        DbHandler.Delete(selectedPatient);
                        PrintTable(DbHandler.GetPatients());
                        break;
                }
            };
        }


        void PrintTable(List<Patient> patients)
        {
            var dataTable = new DataTable();

            foreach (var columnName in Patient.ReturnNamesOfAllColumns())
            {
                var col = new DataColumn();
                col.ColumnName = columnName;
                dataTable.Columns.Add(col);
            }

            foreach (var patient in patients)
            {
                dataTable.Rows.Add(new object[]
                {
                    patient.Id, patient.FirstName, patient.LastName, patient.Pesel, patient.Gender, patient.Email,
                    patient.City, patient.Street, patient.ZipCode
                });
            }

            patientList.Table = dataTable;

        }

    }


}