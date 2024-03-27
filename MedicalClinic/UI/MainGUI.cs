using System.Data;
using MedicalClinic.Core;
using MedicalClinic.DataBase;
using Terminal.Gui;
using MedicalClinic.DataBase.Models;
namespace MedicalClinic;


public partial class MainGUI
{

        public MainGUI()
        {
            SearchSystem searchSystem = new();

            InitializeComponent();
            quitMenuItem.Action = () => Application.RequestStop();

            // Normal print
            PrintTable(DbHandler.GetPatients());

            // searchBar
            searchBar.TextChanging += (query) =>
            {
                searchSystem.SetRequirements(query.NewText.ToString());
                PrintTable(searchSystem.Search(DbHandler.GetPatients()));
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
