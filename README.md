# Booking-Car-App
This an TMPP application to practice implementing of Different Design Patterns.
1.To start Application You need an C# compling IDE. Easiest one is Visual Studio-there you can select <Start in Debug Mode> and an new tab with app will open in Browser.
2.In order to have some Test data, you can Get from DataBaseBackUp the Booking.bak file and try to restore it in you SQL Server. after that ,in Booking.WEB.appsettings.json change connection string:BookingDbConnection Server: <Your own Server>
3.Now all app functionality can be tested. also in Login/SignIn page there are credentials(if you use my stored Database) to connect to 2 different account (admin and simple user) to see all functionality of the app.

The Next Design Patterns were used in this app
	Creational Patterns
		-Builder: to create step by step order of booking an app // Booking.Application.Features.Order.Builder.OrderBuilder.cs
		-Prototype: to clone all car settings when passing them to mediator // BrandModel.cs DriveModel.cs FuelType.cs Vehicle.cs Transmission.cs
		-Factory: Used to create car settings when returning from DB // Booking.Application.Features.Common ICarSettingFactory.cs ICarSettings.cs
	Structural Patterns
		-Proxy: used to call authentication logic inside other class for security // Booking.Application.Features.User.Proxy ILoginProxy.cs LoginProxy.cs
		-Facade: also used for authentication to store in one palce all interfaces used for authentication(signIn, login, logout) //Booking.Application.Features.User.Facade
		-Decorator: used to add some implementation for car class(description and getting soem data) // Booking.Application.Features.Car.Decorator
	Behavioral Patterns
		-Mediator: used to be able to send data between application and web layer.also it is used to avoid using repository so every command/query is independent nad the guy from Web does not get all data from Application side // Booking.Application.Features
		-Command: used to store requests for data when calling Db // Booking.Application.Features
		-Strategy used to store different algorithms for sorting cars in one interface and to call it when it is convinient // Booking.Application.Features.Car.Strategy