using JRPG.Core;
using NAudio.Wave;
using System.Media;

Player p1 = new Player();
Enemy sheep = new Enemy();

Console.WriteLine(sheep.CurrentHealth);
p1.NormalAttack(sheep);
Console.WriteLine(sheep.CurrentHealth);
p1.NormalAttack(sheep);
Console.WriteLine(sheep.CurrentHealth);
