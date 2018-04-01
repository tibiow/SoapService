# SoapService

## Resume 

* This project is a SOAP Service use to have information on velib stations of different cities.


## Features implemented

* This project contains a basic SOAP service with few features to improve it.
* Actual features:
* -the server part use cache in order to decrease the number of API requests. It is used to decrease the time of processing at each client request.
* -a console app can be used to test the service. 3 different méthode can be used(contrat,list,bike).
* -a graphical app can be used to test the service aswell and it is way more simple to use than the console one.

## How to test

* Open the solution `VelibGateway2.sln`

* If you want to test with the console client:
* Set `VelibConsoleClient` as start up project and run it
* As the console propose you, type `contrat` to get the list of the cities you can check
* Then type `list`. The console will ask you to enter the name of a city to have access to the list of stations. pick up one city in the list of contracts
* Finally you can type `bike`. The console will ask you 2 questions. The name of the contract and the name of the station. For the contract you have the pick the same one as the previous point and for the station you have to pick a name from the list you acquired on the previous point.

* If you want to test with the graphic client:
* Set `VelibGraphicClient` as start up project and run it
* Press the `getAllCity` button
* select a city in the list just below
* Press the `getAllStations` button
* select a station in the list just below
* Press the `GetAvailable` button to have the number of bike available.



