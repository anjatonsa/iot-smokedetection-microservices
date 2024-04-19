# Project 1 - Internet of Things

## Description 
The task for this project was to create 2 microservices in 2 different technologies that communicate with each other using gRPC.

## Data
Data set for this project can be found on this [link](https://www.kaggle.com/datasets/deepcontractor/smoke-detection-dataset). Database used for this project is MonogDB. 

## Architecture 
First micorservice is written in .Net Core(C#) and is responsible for communication with the database and for the CRUD operations.
Second microservice is written in Flask(Python) and is responsible for communication with the client.
Both the microservice and the database have been dockerized and are running as containers.

## Running the project
  1 Running: docker compose -up <br>
  2 Starting the insertData.py script <br>
  3 Ready for usage <br>
  $ Testing can be done with Postman or at [http://localhost:5000/api/docs/](http://localhost:5000/api/docs/) <br>
