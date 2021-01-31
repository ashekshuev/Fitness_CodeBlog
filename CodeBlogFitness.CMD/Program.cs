using CodeBlogFitness.BL.Controller;
using System;

namespace CodeBlogFitness.CMD
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Вас приветствует прложение CodeBlogFitness");

			Console.WriteLine("Введите имя пользователя");
			var name = Console.ReadLine();

			var userController = new UserController(name);
			if (userController.IsNewUser)
			{
				Console.WriteLine("Введите пол");
				var gender = Console.ReadLine();
				DateTime birthDate = ParseDateTime();
				double weight = ParseDouble("вес");
				double height = ParseDouble("рост");

				userController.SetNewUsersData(gender, birthDate, weight, height);

			}

			Console.WriteLine(userController.CurrentUser);
		}

		private static DateTime ParseDateTime()
		{
			DateTime birthDate;
			while (true)
			{
				Console.WriteLine("Введите дату рождения (dd.MM.yyyy)");
				if (DateTime.TryParse(Console.ReadLine(), out birthDate))
				{
					break;
				}
				else
				{
					Console.WriteLine("Неверный формат даты рождения");
				}
			}

			return birthDate;
		}

		private static double ParseDouble(string name)
		{
			while (true)
			{
				Console.WriteLine($"Введите {name}: ");
				if (double.TryParse(Console.ReadLine(), out double value))
				{
					return value;
				}
				else
				{
					Console.WriteLine($"Неверный формат {name}а");
				}
			}
		}
	}
}
