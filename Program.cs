using System;

class Program {
  static void Main() {
    // 1.1
    Console.Write("Enter number of cities: ");
    int n = int.Parse(Console.ReadLine());
    string[] cityNames = new string[n];
    int[] cityContact = new int[n];
    int[] cityCovidLevel = new int[n];

    for (int i = 0; i < n; i++) {
      Console.Write($"Enter name of city {i}: ");
      cityNames[i] = Console.ReadLine();
      Console.Write($"Enter contact city ID for city {i}: ");
      int contactID = int.Parse(Console.ReadLine());
      while (contactID < 0 || contactID >= i || contactID == i) {
        Console.WriteLine("Invalid ID");
        Console.Write($"Enter contact city ID for city {i}: ");
        contactID = int.Parse(Console.ReadLine());
      }
      cityContact[i] = contactID;
    }

    // 1.2
    Console.WriteLine("City ID\tCity Name\tCOVID-19 Level");
    for (int i = 0; i < n; i++) {
      Console.WriteLine($"{i}\t{cityNames[i]}\t\t{cityCovidLevel[i]}");
    }

    // 1.3
    Console.Write("Enter event (Outbreak, Vaccinate, Lockdown, or Spread): ");
    string eventString = Console.ReadLine();
    while (eventString != "Outbreak" && eventString != "Vaccinate" && eventString != "Lockdown" && eventString != "Spread") {
      Console.WriteLine("Invalid event");
      Console.Write("Enter event (Outbreak, Vaccinate, Lockdown, or Spread): ");
      eventString = Console.ReadLine();
    }
    if (eventString == "Spread") {
      Console.Write("Enter city ID: ");
      int spreadID = int.Parse(Console.ReadLine());
      cityCovidLevel[spreadID]++;
    } else {
      Console.Write("Enter city ID: ");
      int cityID = int.Parse(Console.ReadLine());
      Console.Write("Enter target city ID: ");
      int targetID = int.Parse(Console.ReadLine());
      while (targetID < 0 || targetID >= n || targetID == cityID) {
        Console.WriteLine("Invalid ID");
        Console.Write("Enter target city ID: ");
        targetID = int.Parse(Console.ReadLine());
      }
      if (eventString == "Outbreak") {
        cityCovidLevel[cityID] += 2;
      } else if (eventString == "Vaccinate") {
        cityCovidLevel[cityID]--;
        cityCovidLevel[targetID]--;
      } else if (eventString == "Lockdown") {
        cityCovidLevel[cityID]--;
        cityCovidLevel[cityContact[cityID]]--;
      }
    }

    // 1.4
    Console.WriteLine("City ID\tCity Name\tCOVID-19 Level");
    for (int i = 0; i < n; i++) {
      Console.WriteLine($"{i}\t{cityNames[i]}\t\t{cityCovidLevel[i]}");
    }
  }
}
