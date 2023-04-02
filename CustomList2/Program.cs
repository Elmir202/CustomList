using CustomList2.Collections;

MyList<int> list = new MyList<int>();
list.Add(10);
list.Add(20);
list.Add(30);
list.Add(40);
list.Add(50);
Console.WriteLine(list.Exist(n=>n==40)); 

