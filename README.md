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
![addNew](https://github.com/lursz/MedicalClinic/assets/93160829/aca85fe0-3cf3-4306-b44c-b45370c1dc23)

#### Edit patient
![edit](https://github.com/lursz/MedicalClinic/assets/93160829/437fea6f-9a20-4a1e-a934-c76f6507976c)

#### Remove patient
![remove](https://github.com/lursz/MedicalClinic/assets/93160829/59dd303e-8fb0-4efd-94be-919004d24025)

#### Search
![search](https://github.com/lursz/MedicalClinic/assets/93160829/f200db99-831d-4af5-9a34-63984d274779)

#### GUI Interface
![freedomofmovement61](https://github.com/lursz/MedicalClinic/assets/93160829/3e122ec2-a43d-44a8-b0e9-6689df2d4992)
