common.net
==========

A random collection of common .net code.

### Structures/Tree
A simple C# tree data structure.

See Tests\TreeTest for detailed example usage.

####Example:
```C#
var employees = new Tree<Person>(new Person { Name = "Jeremy Jones", Title = "CEO" });
employees.Root.Children.Add(new Person { Name = "Joe Grime", Title = "Secretary" });
var cio = employees.Root.Children.Add(new Person { Name = "John Smith", Title = "CIO" });
var director = cio.Children.Add(new Person { Name = "Jay Johnson", Title = "Director" });
```
