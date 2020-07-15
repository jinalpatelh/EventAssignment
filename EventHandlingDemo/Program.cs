using System;

namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {

			var person = new Person();
			var alarm = new UserBanned();
			alarm.userevent += person.HandleAlarm;
			alarm.userevent += person.SendEmail;
			
			person.name = Console.ReadLine();
			if (person.name == "Jack" || person.name == "Mathew" || person.name == "Steven")
			{

				alarm.Alarm();
			}
			else
			{
				Console.WriteLine($"Welcome, {person.name}!");
			}

		}
		public class Person
		{
			public string name { get; set; }

			public void HandleAlarm(object sender, UserBannedEventArgs e)
			{
				Console.WriteLine($"Firealarm : This {e._message} You are not allowed.");
			}

			public void SendEmail(object sender, UserBannedEventArgs e)
			{
				Console.WriteLine($"Email Sent: This {e._message} is not allowed");
			}

		}

		public class UserBanned
		{
			public event UserBannedEventHandler userevent;

			public void Alarm()
			{
				Console.WriteLine("Alert!");
				UserBannedEventHandler alarm = userevent;
				if (userevent != null)
				{
					alarm(this, new UserBannedEventArgs(""));
				}

			}
		}

		public delegate void UserBannedEventHandler(object source, UserBannedEventArgs e);

		public class UserBannedEventArgs : EventArgs
		{
			public string _message { get; set; }
			public UserBannedEventArgs(string message)
			{
				this._message = message;

			}
		}
	}
}
