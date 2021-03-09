package nure.itinf_19_3.shelest;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

import java.util.ArrayList;
import java.util.List;

public class LineServerTest {
    @Test
    public void parallelsLinesTest() {
        List<Line> lines = new ArrayList<>();

        lines.add(new Line(
                new Point(new RationalFraction(1, 1), new RationalFraction(4, 1)),
                new Point(new RationalFraction(0, 1), new RationalFraction(1, 1))));
        lines.add(new Line(
                new Point(new RationalFraction(2, 1), new RationalFraction(0, 1)),
                new Point(new RationalFraction(8, 1), new RationalFraction(4, 1))));
        lines.add(new Line(
                new Point(new RationalFraction(5, 1), new RationalFraction(9, 1)),
                new Point(new RationalFraction(-1, 1), new RationalFraction(5, 1))));
        lines.add(new Line(
                new Point(new RationalFraction(-4, 1), new RationalFraction(5, 1)),
                new Point(new RationalFraction(-1, 1), new RationalFraction(0, 1))));
        lines.add(new Line(
                new Point(new RationalFraction(2, 1), new RationalFraction(7, 1)),
                new Point(new RationalFraction(5, 1), new RationalFraction(2, 1))));

        List<List<Line>> parallelLines = LineServer.parallelsLines(lines);
        String actual = "";
        for (int i = 0; i < parallelLines.size(); ++i) {
            for (int j = 0; j < parallelLines.get(i).size(); ++j) {
                actual += parallelLines.get(i).get(j).toString();
            }
                actual += "\n";
        }

        String expected = "A(1/1; 4/1) - B(0/1; 1/1);\n\n" +
                "A(2/1; 0/1) - B(8/1; 4/1);\nA(5/1; 9/1) - B(-1/1; 5/1);\n\n" +
                "A(-4/1; 5/1) - B(-1/1; 0/1);\nA(2/1; 7/1) - B(5/1; 2/1);\n\n";

        Assertions.assertEquals(expected, actual);
    }
}
