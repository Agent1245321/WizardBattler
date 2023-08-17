// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

Console.WriteLine("Hello, World!");

Wizard dave = new Wizard("Dave");
Wizard john = new Wizard("John");
EndRound end = new EndRound();

dave.Attack(john);
john.WildMagic();


dave.EndRound();
john.EndRound();

