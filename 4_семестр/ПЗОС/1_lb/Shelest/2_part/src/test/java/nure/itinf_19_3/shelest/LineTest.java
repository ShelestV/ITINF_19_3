package nure.itinf_19_3.shelest;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

public class LineTest {
    @Test
    public void isParallelTest() {
        Line first = new Line(
                new Point(
                        new RationalFraction(1, 1),
                        new RationalFraction(2, 1)),
                new Point(
                        new RationalFraction(4, 1),
                        new RationalFraction(4, 1)));

        Line second = new Line(
                new Point(
                        new RationalFraction(2, 1),
                        new RationalFraction(-1, 1)),
                new Point(
                        new RationalFraction(-1, 1),
                        new RationalFraction(-3, 1)));

        boolean actual = first.isParallel(second);
        boolean expected = true;

        Assertions.assertEquals(expected, actual);
    }

    @Test
    public void crosspointTest() {
        Line first = new Line(
                new Point(
                        new RationalFraction(9, 1),
                        new RationalFraction(1, 1)),
                new Point(
                        new RationalFraction(5, 1),
                        new RationalFraction(-1, 1)));

        Line second = new Line(
                new Point(
                        new RationalFraction(2, 1),
                        new RationalFraction(1, 1)),
                new Point(
                        new RationalFraction(1, 1),
                        new RationalFraction(4, 1)));

       String actual = Line.crosspoint(first, second).toString();
       String expected = "x = 3/1\ny = -2/1";

        Assertions.assertEquals(expected, actual);
    }

    @Test
    public void crossOXTest() {
        Line line = new Line(
                new Point(new RationalFraction(2, 1), new RationalFraction(0, 1)),
                new Point(new RationalFraction(8, 1), new RationalFraction(4, 1)));

        String actual = Line.crossOX(line).toString();
        String expected = "x = 2/1\ny = 0/6";

        Assertions.assertEquals(expected, actual);
    }

    @Test
    public void crossOYTest() {
        Line line = new Line(
                new Point(new RationalFraction(1, 1), new RationalFraction(4, 1)),
                new Point(new RationalFraction(0, 1), new RationalFraction(1, 1)));

        String actual = Line.crossOY(line).toString();
        String expected = "x = 0/1\ny = 1/1";

        Assertions.assertEquals(expected, actual);
    }
}
