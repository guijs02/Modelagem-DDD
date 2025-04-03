// See https://aka.ms/new-console-template for more information
using Domain.entity;

Console.WriteLine("Hello, World!");


var adress1 = new Address("Street 1", "City 1", "State 1", "ZipCode 1");

var customer1 = new Customer(1, "Name 1", "Age 1", adress1);

var adress2 = new Address("Street 1", "City 1", "State 1", "ZipCode 1");

System.Console.WriteLine(adress2.Equals(adress1));

