# Medical Clinic

## Description
The main idea behind this fun, little project is to create a Medical Clinic Management System. The system ought to be able, but is not limited to following functionalities:
- Adding new patients
- Adding new random patients
- Editing patient's data
- Deleting patients
- Displaying all patients
- Filtering patients by any criteria

## Motivation
This project is an interview assignment for Esatto Poland. The main goal, obviously, was to fulfill the requirements of the assignment, but I also decided to have some fun with it, and this is why I decided to implement a terminal-gui interface with mouse support.


## Run
In order to run the project, you must have [Docker](https://www.docker.com/products/docker-desktop/) (with Docker Compose) and [.NET 8.0](https://dotnet.microsoft.com/en-us/download) 
installed on your machine.  
First, you need to create the database. You can provide your own or use Docker to create them. To do the latter, run following command in the `/Docker` directory:
```bash
docker-compose up
```
With the databases up and running, you can now run the Load Balancer. To do so, navigate to the `/MedicalClinic` directory and run the project
```bash
dotnet run
```


## Technology stack
- `C#`
- `.NET 8.0`
- `Entity Framework`
- `Docker`
- `PostgreSQL`

## Chosen functionalities

#### Add new patient


#### Edit patient


#### Remove patient


#### Search


#### GUI Interface