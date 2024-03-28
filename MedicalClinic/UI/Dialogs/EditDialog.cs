using MedicalClinic.Core;
using MedicalClinic.DataBase.Models;
using Terminal.Gui;

namespace MedicalClinic.UI;

public class EditDialog : Dialog
{
    public EditDialog(int id)
    {
        Title = "Edit patient";
        X = Pos.Center();
        Y = Pos.Center();
        
        var firstNameLabel = new Label()
        {
            Text = "FirstName:"
        };
        
        var firstNameText = new TextField("")
        {
            // Position text field adjacent to the label
            X = Pos.Right(firstNameLabel) + 1,
            Width = Dim.Fill(),
        };
        
        var lastNameLabel = new Label()
        {
            Text = "LastName:",
            X = Pos.Left(firstNameLabel),
            Y = Pos.Bottom(firstNameLabel) + 1
        };

        var lastNameText = new TextField("")
        {
            X = Pos.Left(firstNameText),
            Y = Pos.Top(lastNameLabel),
            Width = Dim.Fill(),
        };
        
        var peselLabel = new Label()
        {
            Text = "Pesel:",
            X = Pos.Left(lastNameLabel),
            Y = Pos.Bottom(lastNameLabel) + 1
        };
        
        var peselText = new TextField("")
        {
            X = Pos.Left(lastNameText),
            Y = Pos.Top(peselLabel),
            Width = Dim.Fill(),
        };
        
        var emailLabel = new Label()
        {
            Text = "Email:",
            X = Pos.Left(peselLabel),
            Y = Pos.Bottom(peselLabel) + 1
        };
        
        var emailText = new TextField("")
        {
            X = Pos.Left(peselText),
            Y = Pos.Top(emailLabel),
            Width = Dim.Fill(),
        };
        
        var cityLabel = new Label()
        {
            Text = "City:",
            X = Pos.Left(emailLabel),
            Y = Pos.Bottom(emailLabel) + 1
        };
        
        var cityText = new TextField("")
        {
            X = Pos.Left(emailText),
            Y = Pos.Top(cityLabel),
            Width = Dim.Fill(),
        };
        
        var streetLabel = new Label()
        {
            Text = "Street:",
            X = Pos.Left(cityLabel),
            Y = Pos.Bottom(cityLabel) + 1
        };
        
        var streetText = new TextField("")
        {
            X = Pos.Left(cityText),
            Y = Pos.Top(streetLabel),
            Width = Dim.Fill(),
        };
        
        var zipCodeLabel = new Label()
        {
            Text = "ZipCode:",
            X = Pos.Left(streetLabel),
            Y = Pos.Bottom(streetLabel) + 1
        };
        
        var zipCodeText = new TextField("")
        {
            X = Pos.Left(streetText),
            Y = Pos.Top(zipCodeLabel),
            Width = Dim.Fill(),
        };
        
        var saveButton = new Button()
        {
            Text = "Save",
            Y = Pos.Bottom(zipCodeLabel) + 1,
            X = Pos.Center(),
            IsDefault = true,
        };
        
        Add(firstNameLabel, firstNameText, lastNameLabel, lastNameText, peselLabel, peselText, emailLabel, emailText, cityLabel, cityText, streetLabel, streetText, zipCodeLabel, zipCodeText, saveButton);
        Console.WriteLine(peselText.Text.ToString());

        saveButton.Clicked += () =>
        {
            PatientLogic.EditPatient(id, firstNameText.Text.ToString(), lastNameText.Text.ToString(), peselText.Text.ToString(), emailText.Text.ToString(), cityText.Text.ToString(), streetText.Text.ToString(), zipCodeText.Text.ToString());
            Application.RequestStop();
        };
        
    }
    
    public void ShowDialog(Patient patient)
    {
        Application.Run(this);
    }
    
}