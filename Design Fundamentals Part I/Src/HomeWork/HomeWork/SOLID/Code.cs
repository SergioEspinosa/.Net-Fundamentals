using System;

namespace HomeWork.SOLID
{
    //Que principio SOLID incumple este codigo?
    //Que pasa si quiero saber el area de un Rectangulo?

    public class Square
    {
        public double Height { get; set; }
    }
    public class Circle
    {
        public double Radius { get; set; }
    }
    public class Triangle
    {
        public double FirstSide { get; set; }
        public double SecondSide { get; set; }
        public double ThirdSide { get; set; }
    }
    public class AreaCalculator
    {

        public double Area(object[] shapes)
        {
            double area = 0;

            foreach (var shape in shapes)
            {

                if (shape is Square)
                {
                    Square square = (Square)shape;
                    area += Math.Sqrt(square.Height);
                }

                if (shape is Triangle)
                {
                    Triangle triangle = (Triangle)shape;
                    double TotalHalf = (triangle.FirstSide + triangle.SecondSide + triangle.ThirdSide) / 2;
                    area += Math.Sqrt(TotalHalf * (TotalHalf - triangle.FirstSide) *
                    (TotalHalf - triangle.SecondSide) * (TotalHalf - triangle.ThirdSide));
                }

                if (shape is Circle)
                {
                    Circle circle = (Circle)shape;
                    area += circle.Radius * circle.Radius * Math.PI;
                }

            }
            return area;
        }
    }
}