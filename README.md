<h1 align="center">Booking Car App</h1>

## **Description**
This an TMPP application to practice implementing of Different Design Patterns.
## **How to start Application**
To start Application You need an C# compling IDE. 
Easiest one is Visual Studio-there you can select "Start in Debug Mode" and an new tab with app will open in Browser.
## **Use Test Data**
In order to have some Test data, you can Get from DataBaseBackUp the Booking.bak file and try to restore it in you SQL Server.
After that, in Booking.WEB.appsettings.json change connection string:BookingDbConnection Server: "Your own Server"
## **Test App**
Now all app functionality can be tested. also in Login/SignIn page there are credentials(if you use my stored Database) to connect to 2 different account (admin and simple user) to see all functionality of the app.
## **TMPP Design Patterns**
Used Design Patterns Are:
<table>
  <tr>
    <th>Design Pattern</th>
    <th>Name</th>
    <th>Description</th>
    <th>Usages</th>
  </tr>
  <tr>
    <td>Creational</td>
    <td>Builder</td>
    <td>Create step by step Order of Booking an Car</td>
    <td>Booking.Application.Features.Order.Builder.OrderBuilder.cs usage:AddOrderCommandHandler.cs</td>  
  </tr>
  <tr>
    <td>Creational</td>
    <td>Prototype</td>
    <td>Add possibility to clone all car settings when passing them to Mediator</td>
    <td>BrandModel.cs DriveModel.cs FuelType.cs Vehicle.cs Transmission.cs</td>
  </tr>
  <tr>
    <td>Creational</td>
    <td>Factory</td>
    <td>Used to create different car settings sunder same interface when returning from DB</td>
    <td>Booking.Application.Features.Common ICarSettingFactory.cs ICarSettings.cs</td>
  </tr>
  <tr>
    <td>Structural</td>
    <td>Proxy</td>
    <td>Used to call  authentication logic inside other class for security</td>
    <td>Booking.Database.User.LoginProxy.cs/Login.cs </td>
  </tr>
  <tr>
    <td>Structural</td>
    <td>Facade</td>
    <td>Used for authentication: to store in one place all interfaces used for authentication(SignIn, Login, Logout)</td>
    <td>Booking.Application.Features.User.Facade</td>
  </tr>
  <tr>
    <td>Structural</td>
    <td>Decorator</td>
    <td>Used to add some implementation for car class(description and getting some data)</td>
    <td> Booking.Application.Features.Car.Decorator</td>
  </tr>
  <tr>
    <td>Behavioral</td>
    <td>Command</td>
    <td>Used to store requests for data when calling DB</td>
    <td>Booking.Application.Features.Car.CommandS.Add.AddCarCoomad or any file with command name</td>
  </tr>
  <tr>
    <td>Behavioral</td>
    <td>Strategy</td>
    <td>Used to store different algorithms for sorting cars in one interface and to call it when it is convinient</td>
    <td>Booking.Application.Features.Car.Strategy</td>
  </tr>
  <tr>
    <td>Behavioral</td>
    <td>Mediator</td>
    <td>Used to be able to send data between application and Web layer. Also it is used to avoid using repository so every command/query is independent</td>
    <td>Booking.Booking.Infrastructure.IMediator/Mediator + Any Controller</td>
  </tr>
</table>
	
