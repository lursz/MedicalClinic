using MedicalClinic.DataBase;
using MedicalClinic.DataBase.Models;
using Terminal.Gui;

namespace MedicalClinic.UI.Dialogs;

public class DetailsDialog : Dialog
{
    public DetailsDialog(Patient patient)
    {
        Title = "Patient details";
        X = Pos.Center();
        Y = Pos.Center();
        

        
        var detailsLabel = new Label()
        {
            Text = patient.ToNewLineString(),
            Width = Dim.Fill(),
            Height = Dim.Fill()
            
        };
        
        var editButton = new Button("Edit")
        {
            X = Pos.Right(detailsLabel),
            Y = Pos.Bottom(detailsLabel) + 20
        };
        
        var deleteButton = new Button("Delete")
        {
            X = Pos.Right(editButton) + 1,
            Y = Pos.Top(editButton)
        };
        
        var cancelButton = new Button("Cancel")
        {
            X = Pos.Right(deleteButton) + 1,
            Y = Pos.Top(deleteButton)
        };
        Add(detailsLabel, editButton, deleteButton, cancelButton);
        
        editButton.Clicked += () =>
        {
            var editDialog = new EditDialog(patient.Id);
            editDialog.ShowDialog(patient);
            Application.RequestStop();
        };
        
        deleteButton.Clicked += () =>
        {
            DbHandler.Delete(patient);
            Application.RequestStop();
        };
        
        cancelButton.Clicked += () =>
        {
            Application.RequestStop();
        };
        
        
    }
    
    public void ShowDialog()
    {
        Application.Run(this);
    } 


}