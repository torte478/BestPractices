private IEnumerable<Segment> EnumerateSegmentsToDraw()
        {
            var current = new Segment();
            var currentIsVertical = false;
            foreach (var next in OldEnumerateSegmentsToDraw(0))
            {
                var nextIsVertical = next.FirstPoint.X == next.SecondPoint.X;
                if (nextIsVertical)
                {
                    var anotherVertical = next.FirstPoint.X != current.FirstPoint.X;
                    if (anotherVertical)
                        yield return current;
                    if (anotherVertical || !currentIsVertical)
                        current = next;

                    currentIsVertical = true;
                    var max = Math.Max(current.SecondPoint.Y, Math.Max(next.FirstPoint.Y, next.SecondPoint.Y));
                    var min = Math.Min(current.FirstPoint.Y, Math.Min(next.FirstPoint.Y, next.SecondPoint.Y));
                    current.FirstPoint = new Point(current.FirstPoint.X, min);
                    current.SecondPoint = new Point(current.FirstPoint.X, max);
                }
                else
                {
                    if (currentIsVertical)
                    {
                        yield return current;
                        currentIsVertical = false;
                    }
                    yield return next;
                }









                //if (currentIsVertical)
                //{
                //    if (nextIsVertical)
                //    {
                //        var anotherVertical = next.FirstPoint.X != current.FirstPoint.X;
                //        if (anotherVertical)
                //        {
                //            yield return current;
                //            current = next;
                //        }
                //        var max = Math.Max(current.SecondPoint.Y, Math.Max(next.FirstPoint.Y, next.SecondPoint.Y));
                //        var min = Math.Min(current.FirstPoint.Y, Math.Min(next.FirstPoint.Y, next.SecondPoint.Y));
                //        current.FirstPoint = new Point(current.FirstPoint.X, min);
                //        current.SecondPoint = new Point(current.FirstPoint.X, max);
                //    }
                //    else
                //    {
                //        yield return current;
                //        current = next;
                //        currentIsVertical = false;

                //        yield return next;
                //    }
                //}
                //else
                //{
                //    if (nextIsVertical)
                //    {
                //        currentIsVertical = true;
                //        current = next;
                //        var max = Math.Max(current.SecondPoint.Y, Math.Max(next.FirstPoint.Y, next.SecondPoint.Y));
                //        var min = Math.Min(current.FirstPoint.Y, Math.Min(next.FirstPoint.Y, next.SecondPoint.Y));
                //        current.FirstPoint = new Point(current.FirstPoint.X, min);
                //        current.SecondPoint = new Point(current.FirstPoint.X, max);
                //    }
                //    else
                //    {
                //        yield return next;
                //    }
                //}
            }