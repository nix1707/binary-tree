// var tree = new Tree<int>(7);

// tree.Insert(56);
// tree.Insert(77);
// tree.Insert(11);
// tree.Insert(2);
// tree.Insert(3);
// tree.Insert(6);
// tree.Insert(34);

var nameHierarchy = new Tree<string>("Sean");

for(int i = 0; i < 20; i++)
{
    nameHierarchy.Insert(new Bogus.Faker().Person.FirstName);
}

Console.WriteLine("\n In Order \n");

Console.WriteLine(string.Join(',', nameHierarchy.GetInOrder()));
System.Console.WriteLine(nameHierarchy.Contains("Sean"));

