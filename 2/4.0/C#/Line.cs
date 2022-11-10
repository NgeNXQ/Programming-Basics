using System;

internal class Line
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }

    private double angleCoefficient;
    public double AngleCoefficient 
    { 
        get => -A / B; 
        private set
        {
            angleCoefficient = value;
        } 
    }
    public Line()
    {
        A = -1;
        B = 1;
        C = 0;
    }
    public Line(double C)
    {
        A = -1;
        B = 1;
        this.C = C;
    }
    public Line(double A, double B, double C)
    {
        this.A = A;
        this.B = B;
        this.C = C;
    }

    public double IntersectionY { get => -1 * Math.Round(-((-A * 0 - C) / B), 3); }
    public double IntersectionX { get => -1 * Math.Round(-((-B * 0 - C) / A), 3); }

    public static bool operator | (Line l1, Line l2)
    {
        if (Math.Round(l1.A / l2.A, 2) == Math.Round(l1.B / l2.B, 2))
            return true;
        else
            return false;
    }

    public static Line operator ++ (Line l)
    {
        double newK = Math.Round(Math.Tan(((Math.Atan(l.AngleCoefficient) * 180 / Math.PI) + 1) * Math.PI / 180), 3) % 1;

        return l.A > 0 ? new Line(l.A - newK, l.B, l.C) : new Line(l.A + newK, l.B, l.C);
    }
    public override string ToString() => $"{A}x + {B}y + {C} = 0";
}
