using System.Data;
using MedicalClinic.Core;
using MedicalClinic.DataBase;
using MedicalClinic.DataBase.Models;
using MedicalClinic.UI;
using Terminal.Gui;

namespace MedicalClinic
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
            buttonHelp.Clicked += () => MessageBox.ErrorQuery("Help", "This is a simple medical clinic app in retro style. App fully supports both mouse and keyboard and runs smoothly on literally any device", "Ok");
            buttonHelp2.Clicked += () => MessageBox.ErrorQuery("Help", "Search functionality is based on regex. You can search for specific values in columns by typing: key:{value}. For example: FirstName:{John} PESEL:{[0-9]{11}}", "Ok");
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
            buttonRemoveAll.Clicked += () =>
            {
                DbHandler.Clear();
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
                // show prompt with buttons to delete and edit  
                var dialog = MessageBox.Query(50, 10, "Patient details", selectedPatient.ToNewLineString(), "Edit", "Delete", "Cancel");
                if (dialog == 0)
                {
                    // Edit
                    var id = int.Parse(patientList.Table.Rows[args.NewRow][0].ToString());
                    var editDialog = new EditDialog(id);
                    editDialog.ShowDialog(selectedPatient);
                    PrintTable(DbHandler.GetPatients());
                }
                else if (dialog == 1)
                {
                    // Delete
                    DbHandler.Delete(selectedPatient);
                    PrintTable(DbHandler.GetPatients());
                }
            };
        }


        void PrintTable(List<Patient> patients)
        {
            var dataTable = new DataTable();

            foreach (var columnName in Patient.returnNamesOfAllColumns())
            {
                var col = new DataColumn();
                col.ColumnName = columnName;
                dataTable.Columns.Add(col);
            }

            foreach (var patient in patients)
            {
                dataTable.Rows.Add(new object[]
                {
                    patient.Id, patient.FirstName, patient.LastName, patient.PESEL, patient.Gender, patient.Email,
                    patient.City, patient.Street, patient.ZipCode
                });
            }

            patientList.Table = dataTable;

        }

    }


}