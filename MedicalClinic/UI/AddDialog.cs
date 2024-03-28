using MedicalClinic.DataBase;
using MedicalClinic.DataBase.Models;
using Terminal.Gui;

namespace MedicalClinic.UI;

class PatientAdd : Dialog
{
    public PatientAdd()
    {
        Title = "Add patient";
        X = Pos.Center();
        Y = Pos.Center();
        

        var firstName = new TextField("");
        var firstNameLabel = new Label("First name:");
        var lastName = new TextField( "");
        var pesel = new TextField("");
        var gender = new TextField("");
        var email = new TextField("");
        var city = new TextField("");
        var street = new TextField("");
        var zipCode = new TextField("");

        var buttonAdd = new Button("Add");
        buttonAdd.Clicked += () =>
        {
            var patient = new Patient(firstName.Text.ToString(), lastName.Text.ToString(), "elooo",
                email.Text.ToString(), city.Text.ToString(), street.Text.ToString(), zipCode.Text.ToString());
            DbHandler.Create(patient);
        };
        
        
        // Now add to the view: Label: First name, textfield firstName, Label: Last name, textfield lastName, Label: PESEL, text etc
        Add(
            firstNameLabel,
            firstName,
            lastName,
            pesel
            );
        
        AddButton(buttonAdd);
    }
        
    public void ShowDialog()
    {
        Application.Run(this);
    }
}