using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q6ClosestPoints : Processor
    {
        public Q6ClosestPoints(string testDataName) : base(testDataName)
        { }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], double>)Solve);

        public virtual double Solve(long n, long[] xPoints, long[] yPoints)
        {
            List<Tuple<long, long>> points = new List<Tuple<long, long>>();
            for (int i = 0; i < n; i++)
            {
                points.Add(Tuple.Create(xPoints[i], yPoints[i]));
            }
            points = points.OrderBy(t => t.Item1).ToList();
            return Math.Round(ClosestPoint(points.ToArray(), 0, points.Count - 1), 4);

        }
        public double Distance(Tuple<long, long> a, Tuple<long, long> b)
        {

            return Math.Sqrt((a.Item1 - b.Item1) * (a.Item1 - b.Item1)
                + (a.Item2 - b.Item2) * (a.Item2 - b.Item2));

        }
        public double ClosestPoint(Tuple<long, long>[] points, long low, long high)
        {
            if (high - low == 1)
                return Distance(points[high], points[low]);
            if (high - low == 2)
            {
                return Math.Min(Distance(points[low], points[high]),
                    Math.Min(Distance(points[high], points[high - 1])
                    , Distance(points[low], points[high - 1])));
            }
            long mid = low + (high - low) / 2;
            double dl = ClosestPoint(points, low, mid);
            double dr = ClosestPoint(points, mid + 1, high);
            double mind = Math.Min(dl, dr);
            double xavg = (points[low].Item1 + points[high].Item1) / 2;
            Tuple<long, long> middlepoint = points[mid];
            List<Tuple<long, long>> middlepoints = new List<Tuple<long, long>>();
            for (long i = low; i < high; i++)
            {
                if (Math.Abs(points[i].Item1 - xavg) <= mind)
                    middlepoints.Add(points[i]);
            }
            Tuple<long, long>[] midPoints = middlepoints.ToArray();

            for (long i = 0; i < midPoints.Length; i++)
            {
                for (long j = i + 1; j < midPoints.Length; j++)
                {
                    double temp = Distance(midPoints[i], midPoints[j]);
                    if (mind > temp)
                        mind = temp;

                }
            }
            return mind;

        }


    }
}