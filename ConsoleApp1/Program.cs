﻿// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

Console.WriteLine("Welcome To Wizard Battle!");
Wizard wiz1 = null;
Wizard wiz2 = null;


void StartGame2Player()
{
    Console.WriteLine("Player 1, Name Your Wizard!");
    wiz1 = new Wizard(Console.ReadLine());

    Console.WriteLine("Player 2, Name Your Wizard!");
    wiz2 = new Wizard(Console.ReadLine());

    RoundStart();

}

void RoundStart()
{
    if(wiz1.Speed > wiz2.Speed) { Console.WriteLine($"{wiz1.Name} shall go first"); Wiz1Turn(); Wiz2Turn(); wiz1.EndRound(); wiz2.EndRound(); Console.WriteLine("\n \n \n Next Round..."); RoundStart(); }
    else {
        Console.WriteLine($"{wiz2.Name} shall go first") ; Wiz2Turn(); Wiz1Turn(); wiz1.EndRound(); wiz2.EndRound(); Console.WriteLine("\n \n \n Next Round..."); RoundStart();
    }
}

void Wiz1Turn()
{
    Console.WriteLine($"{wiz1.Name} choose your move...");
    Console.WriteLine("\n 1: Attack \n 2: Defend \n 3: Dodge \n 4: Hinder \n 5: Concentrate \n 6: WildMagic");
    int move = Convert.ToInt32(Console.ReadLine());
    switch (move)
    {
        case 1:
            wiz1.Attack(wiz2);
        break;

        case 2:
            wiz1.Defend();
            break;

        case 3:
            wiz1.Dodge();
            break;

        case 4:
            wiz1.Hinder(wiz2);
            break;

        case 5:
            wiz1.Concentrate();
            break;

        case 6:
            wiz1.WildMagic();
            break;

        default:
            Console.WriteLine("Not a valid move");
            Wiz1Turn();
            break;

    }
}

void Wiz2Turn()
{
    Console.WriteLine($"{wiz2.Name} choose your move...");
    Console.WriteLine("\n 1: Attack \n 2: Defend \n 3: Dodge \n 4: Hinder \n 5: Concentrate \n 6: WildMagic");
    int move = Convert.ToInt32(Console.ReadLine());
    switch (move)
    {
        case 1:
            wiz2.Attack(wiz1);
            break;

        case 2:
            wiz2.Defend();
            break;

        case 3:
            wiz2.Dodge();
            break;

        case 4:
            wiz2.Hinder(wiz1);
            break;

        case 5:
            wiz2.Concentrate();
            break;

        case 6:
            wiz2.WildMagic();
            break;

        default:
            Console.WriteLine("Not a valid move");
            Wiz2Turn();
            break;

    }
}



StartGame2Player();


