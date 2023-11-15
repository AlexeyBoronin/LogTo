using LogTo;
using (ApplicationContext db = new ApplicationContext())
{
    Human h1 = new Human { Name = "Ted", Age = 30 };
    Human h2 = new Human { Name = "Jane", Age = 25 };
    
    db.Humans.Add(h1);
    db.Humans.Add(h2);
    db.SaveChanges();

    var humans = db.Humans.ToList();
    Console.WriteLine("Список пользователей:");
    foreach (var h in humans)
        Console.WriteLine($"{h.Id}.{h.Name} - {h.Age}");

}