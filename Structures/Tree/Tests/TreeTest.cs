namespace Structures.Tree.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TreeTest
    {
        private Tree<Person> tree;

        [TestInitialize]
        public void Setup()
        {
            this.tree = this.GetEmployeeTree();
        }

        [TestMethod]
        public void TreeRootShouldBeTheCeo()
        {                       
            Assert.IsTrue(this.tree.Root.Data.Title == "CEO");
        }

        [TestMethod]
        public void TheRootShouldHaveTwoChildren()
        {
            Assert.IsTrue(this.tree.Root.Children.Count == 2);
        }

        [TestMethod]
        public void ThereAreSevenEmployeesInTheTree()
        {
            var list = new List<Person>();            
            this.tree.Walk((x, y) => list.Add(x.Data));
            Assert.IsTrue(list.Count == 7);
        }

        [TestMethod]        
        public void TreeWalkVisitsEachNodeWithCorrectDepth()
        {
            var builder = new StringBuilder();
            this.tree.Walk(
                 (node, depth) => builder.AppendLine(string.Format(
                     "{0}{1} - {2}", 
                     string.Concat(Enumerable.Repeat(" ", depth * 2)), 
                     node.Data.Name, 
                     node.Data.Title)));

            var result = new StringBuilder();
            result.AppendLine("Jeremy Jones - CEO");
            result.AppendLine("  Joe Grime - Marketer");
            result.AppendLine("  John Smith - CIO");
            result.AppendLine("    Jay Johnson - Director");
            result.AppendLine("      Jim Spark - Supervisor");
            result.AppendLine("        Johan Stravsky - Developer");
            result.AppendLine("        James Clark - Developer");
          
            Assert.IsTrue(builder.ToString() == result.ToString());
        }

        private Tree<Person> GetEmployeeTree()
        {
            var employees = new Tree<Person>(new Person { Name = "Jeremy Jones", Title = "CEO" });
            employees.Root.Children.Add(new Person { Name = "Joe Grime", Title = "Marketer" });
            var cio = employees.Root.Children.Add(new Person { Name = "John Smith", Title = "CIO" });
            var director = cio.Children.Add(new Person { Name = "Jay Johnson", Title = "Director" });
            var supervisor = director.Children.Add(new Person { Name = "Jim Spark", Title = "Supervisor" });
            supervisor.Children.Add(new Person { Name = "Johan Stravsky", Title = "Developer" });
            supervisor.Children.Add(new Person { Name = "James Clark", Title = "Developer" });
            return employees;
        }

        private class Person
        {
            public string Name { get; set; }

            public string Title { get; set; }
        }
    }
}
