using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
namespace UnitTestProject1
{
    [TestClass]
    public class DirectionTest
    {
        [TestMethod]
        public void Point_Po_Chas()
        {
            string ans = "по часовой";

            ConsoleApp1.Point p1 = new ConsoleApp1.Point(1, 3);
            ConsoleApp1.Point p2 = new ConsoleApp1.Point(3, 1);
            ConsoleApp1.Point p3 = new ConsoleApp1.Point(2, -2);
            ConsoleApp1.Point p4 = new ConsoleApp1.Point(-2, 1);
            ConsoleApp1.Point p5 = new ConsoleApp1.Point(-1, 1);
            List<ConsoleApp1.Point> points = new List<ConsoleApp1.Point>();
            points.Add(p1);
            points.Add(p2);
            points.Add(p3);
            points.Add(p4);
            points.Add(p5);
            ConsoleApp1.Direction direction = new ConsoleApp1.Direction(points);


            Assert.AreEqual(ans, direction.direction());
        }

        [TestMethod]
        public void Point_Protiv_Chas()
        {
            string ans = "против часовой";

            ConsoleApp1.Point p1 = new ConsoleApp1.Point(-1, 1);
            ConsoleApp1.Point p2 = new ConsoleApp1.Point(-2, 1);
            ConsoleApp1.Point p3 = new ConsoleApp1.Point(2, -2);
            ConsoleApp1.Point p4 = new ConsoleApp1.Point(3, 1);
            ConsoleApp1.Point p5 = new ConsoleApp1.Point(1, 3);
            List<ConsoleApp1.Point> points = new List<ConsoleApp1.Point>();
            points.Add(p1);
            points.Add(p2);
            points.Add(p3);
            points.Add(p4);
            points.Add(p5);
            ConsoleApp1.Direction direction = new ConsoleApp1.Direction(points);


            Assert.AreEqual(ans, direction.direction());
        }

        [TestMethod]
        public void One_Point_No_Line()
        {
            string ans = "по часовой";

            ConsoleApp1.Point p1 = new ConsoleApp1.Point(1, 1);
            ConsoleApp1.Point p2 = new ConsoleApp1.Point(1, 2);
            ConsoleApp1.Point p3 = new ConsoleApp1.Point(2, -2);
            ConsoleApp1.Point p4 = new ConsoleApp1.Point(1, -3);
            ConsoleApp1.Point p5 = new ConsoleApp1.Point(1, -1);
            List<ConsoleApp1.Point> points = new List<ConsoleApp1.Point>();
            points.Add(p1);
            points.Add(p2);
            points.Add(p3);
            points.Add(p4);
            points.Add(p5);
            ConsoleApp1.Direction direction = new ConsoleApp1.Direction(points);


            Assert.AreEqual(ans, direction.direction());
        }
        [TestMethod]
        public void All_Point_On_Line()
        {
            string ans = "невозможно определить направление";

            ConsoleApp1.Point p1 = new ConsoleApp1.Point(1, 2);
            ConsoleApp1.Point p2 = new ConsoleApp1.Point(1, -2);
            ConsoleApp1.Point p3 = new ConsoleApp1.Point(1, 0);
            ConsoleApp1.Point p4 = new ConsoleApp1.Point(1, 1);
            ConsoleApp1.Point p5 = new ConsoleApp1.Point(1, -2);
            List<ConsoleApp1.Point> points = new List<ConsoleApp1.Point>();
            points.Add(p1);
            points.Add(p2);
            points.Add(p3);
            points.Add(p4);
            points.Add(p5);
            ConsoleApp1.Direction direction = new ConsoleApp1.Direction(points);


            Assert.AreEqual(ans, direction.direction());
        }
    }
}
