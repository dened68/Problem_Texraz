using System;
using System.Numerics;

using System.Collections.Generic;

namespace ConsoleApp1
{
    static class Program
    {

        static void Main(string[] args)
        {
            List<Point> points = new List<Point>();

            points = getpoints();

            Direction direction = new Direction(points);

            Console.WriteLine(direction.direction());

        }

        static List<Point> getpoints()
        {
            int n = Int32.Parse(Console.ReadLine());
            Random rnd = new Random();

            List<double> xPool = new List<double>(n);
            List<double> yPool = new List<double>(n);

            for (int i = 0; i < n; i++)
            {
                xPool.Add(rnd.NextDouble());
                yPool.Add(rnd.NextDouble());

            }

            xPool.Sort();
            yPool.Sort();

            Double minX = xPool[0];
            Double maxX = xPool[n - 1];
            Double minY = yPool[0];
            Double maxY = yPool[n - 1];

            List<double> xVec = new List<double>(n);
            List<double> yVec = new List<double>(n);

            double lastTop = minX, lastBot = minX;

            for (int i = 1; i < n - 1; i++)
            {
                double x1 = xPool[i];

                if (rnd.Next(2) == 0)
                {
                    xVec.Add(x1 - lastTop);
                    lastTop = x1;
                }
                else
                {
                    xVec.Add(lastBot - x1);
                    lastBot = x1;
                }
            }
            xVec.Add(maxX - lastTop);
            xVec.Add(lastBot - maxX);

            double lastLeft = minY, lastRight = minY;

            for (int i = 1; i < n - 1; i++)
            {
                double y1 = yPool[i];

                if (rnd.Next(2) == 0)
                {
                    yVec.Add(y1 - lastLeft);
                    lastLeft = y1;
                }
                else
                {
                    yVec.Add(lastRight - y1);
                    lastRight = y1;
                }
            }

            yVec.Add(maxY - lastLeft);
            yVec.Add(lastRight - maxY);

            xVec.Shuffle();



            List<Point> vec = new List<Point>();

            for (int i = 0; i < n; i++)
            {
                vec.Add(new Point(xVec[i], yVec[i]));
            }

            vec.Sort();



            double x = 0, y = 0;
            double minPolygonX = 0;
            double minPolygonY = 0;
            List<Point> points = new List<Point>();

            for (int i = 0; i < n; i++)
            {
                points.Add(new Point(x, y));

                x += vec[i].x;
                y += vec[i].y;

                minPolygonX = Math.Min(minPolygonX, x);
                minPolygonY = Math.Min(minPolygonY, y);
            }

            double xShift = minX - minPolygonX;
            double yShift = minY - minPolygonY;

            for (int i = 0; i < n; i++)
            {
                Point p = points[i];
                points[i] = new Point(p.x + xShift, p.y + yShift);
            }


            for (int i = 0; i < points.Count; i++)
            {
                Console.WriteLine(points[i].x + " " + points[i].y);
            }

            return points;
        }

        //static List<double> Shuffle(List<double> list)
        //{
        //    Random rng = new Random();
        //    int n = list.Count;
        //    while (n > 1)
        //    {
        //        n--;
        //        int k = rng.Next(n + 1);
        //        double value = list[k];
        //        list[k] = list[n];
        //        list[n] = value;
        //    }
        //    return list;
        //}


        public static void Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

    }

    public class Point : IComparable<Point>
    {
        public double x;
        public double y;
        
        public Point(double xp, double yp)
        {
            x = xp;
            y = yp;
        }

        public double tan()
        {
            return System.Math.Atan2( y,  x);
        }

        public int CompareTo(Point obj)
        {
            if (System.Math.Atan2(this.y, this.x) > System.Math.Atan2(obj.y, obj.x))
                return 1;
            if (System.Math.Atan2(this.y, this.x) < System.Math.Atan2(obj.y, obj.x))
                return -1;
            else
                return 0;

        }


    }

    public class Direction
    {
        List<Point> points = new List<Point>();

        public Direction(List<Point> points)
        {
            this.points = points;
        }

        public string direction()
        {
            
            for(int i = 0; i <points.Count -2; i++)
            {
                if (getvec3(points[i], points[i+1], points[i+2]).Z !=0)
                {
                    
                    if (getvec3(points[i], points[i + 1], points[i + 2]).Z < 0)
                        return "по часовой";
                    else
                        return "против часовой";                        
                }
            }


            if (getvec3(points[points.Count - 2], points[points.Count - 1], points[0]).Z != 0)
            {

                if (getvec3(points[points.Count - 2], points[points.Count - 1], points[0]).Z < 0)
                    return "по часовой";
                else
                    return "против часовой";
            }

            if (getvec3(points[points.Count - 1], points[0], points[1]).Z != 0)
            {

                if (getvec3(points[points.Count - 1], points[0], points[1]).Z < 0)
                    return "по часовой";
                else
                    return "против часовой";
            }

            return "невозможно определить направление";

        }


        private Vector3 getvec3(Point point1, Point point2, Point point3)
        {
            Vector2 firstvector2 = new Vector2(Convert.ToSingle(point3.x - point2.x), Convert.ToSingle(point3.y - point2.y));
            Vector2 secvector2 = new Vector2(Convert.ToSingle(point1.x - point2.x), Convert.ToSingle(point1.y - point2.y));

            Vector3 firstvec3 = new Vector3(firstvector2, 0);
            Vector3 sectvec3 = new Vector3(secvector2, 0);

            Vector3 ansvec = Vector3.Cross(firstvec3, sectvec3);

            return ansvec;
        }
    }
}



