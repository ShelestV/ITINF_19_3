import org.junit.Assert;
import org.junit.Test;
import java.util.ArrayList;

public class PointTest {

    @Test
    public void getDistanceBetweenPoints() {

        Point first = new Point(new ComplexNumber(2,3),new ComplexNumber(1,6), new ComplexNumber(4,4));
        Point second = new Point(new ComplexNumber(1,2), new ComplexNumber(2,2), new ComplexNumber(7,1));

        String actual = ComplexNumber.getAnswerOutput(Point.distanceBetweenPoints(first, second));
        String expected = "2,58 - i10,83";

        Assert.assertEquals(expected, actual);
    }

    @Test
    public void getDistanceBetweenPointAndStartCoords() {

        Point first = new Point(new ComplexNumber(2,3),new ComplexNumber(1,6), new ComplexNumber(4,4));
        Point second = new Point(new ComplexNumber(0,0), new ComplexNumber(0,0), new ComplexNumber(0,0));

        String actual = ComplexNumber.getAnswerOutput(Point.distanceBetweenPoints(first, second));
        String expected = "2,58 - i10,83";

        Assert.assertEquals(expected, actual);
    }

    @Test
    public void getSumOfArrayOfComplexNums() {

        ComplexNumber[] mas = new ComplexNumber[5];
        mas[0] = new ComplexNumber(1,2);
        mas[1] = new ComplexNumber(5,4);
        mas[2] = new ComplexNumber(2,1);
        mas[3] = new ComplexNumber(7,3);
        mas[4] = new ComplexNumber(6,2);


        String actual = ComplexNumber.getAnswerOutput(ComplexNumber.getSumOfArrayOfComplexNumbers(mas));
        String expected = "";

        Assert.assertEquals(expected, actual);
    }

    @Test
    public void getDistanceBetweenPoints1() {

        Point first = new Point(new ComplexNumber(2,3),new ComplexNumber(1,6), new ComplexNumber(4,4));
        Point second = new Point(new ComplexNumber(1,2), new ComplexNumber(2,2), new ComplexNumber(7,1));

        String actual = ComplexNumber.getAnswerOutput(Point.distanceBetweenPoints(first, second));
        String expected = "2,58 - i10,83";

        Assert.assertEquals(expected, actual);
    }

    @Test
    public void getDistanceBetweenPoints2() {

        Point first = new Point(new ComplexNumber(2,3),new ComplexNumber(1,6), new ComplexNumber(4,4));
        Point second = new Point(new ComplexNumber(1,2), new ComplexNumber(2,2), new ComplexNumber(7,1));

        String actual = ComplexNumber.getAnswerOutput(Point.distanceBetweenPoints(first, second));
        String expected = "2,58 - i10,83";

        Assert.assertEquals(expected, actual);
    }
}
