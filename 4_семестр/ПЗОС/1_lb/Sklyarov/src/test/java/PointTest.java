import org.junit.Assert;
import org.junit.Test;
import java.util.ArrayList;

public class PointTest {

    @Test
    public void getDistanceBetweenPoints() {

        Point first = new Point(new ComplexNumber(2,3),new ComplexNumber(1,6), new ComplexNumber(4,4));
        Point second = new Point(new ComplexNumber(1,2), new ComplexNumber(2,2), new ComplexNumber(7,1));

        String actual = ComplexNumber.getAnswerOutput(Point.distanceBetweenPoints(first, second));
        String expected = "2,58 - i4,65";

        Assert.assertEquals(expected, actual);
    }

    @Test
    public void getDistanceBetweenPointAndStartCoords() {

        Point first = new Point(new ComplexNumber(2,3),new ComplexNumber(1,6), new ComplexNumber(4,4));
        Point second = new Point(new ComplexNumber(0,0), new ComplexNumber(0,0), new ComplexNumber(0,0));

        String actual = ComplexNumber.getAnswerOutput(Point.distanceBetweenPoints(first, second));
        String expected = "3,80 + i7,38";

        Assert.assertEquals(expected, actual);
    }

    @Test
    public void getSumOfArrayOfComplexNums() {

        ComplexNumber[] mas = new ComplexNumber[5];
        mas[0] = new ComplexNumber(1,2);
        mas[1] = new ComplexNumber(-5,4);
        mas[2] = new ComplexNumber(2,1);
        mas[3] = new ComplexNumber(7,3);
        mas[4] = new ComplexNumber(6,-2);


        String actual = ComplexNumber.getAnswerOutput(ComplexNumber.getSumOfArrayOfComplexNumbers(mas));
        String expected = "11,00 + i8,00";

        Assert.assertEquals(expected, actual);
    }

    @Test
    public void getNegativeSumOfArrayOfComplexNums() {

        ComplexNumber[] mas = new ComplexNumber[5];
        mas[0] = new ComplexNumber(-1,-2);
        mas[1] = new ComplexNumber(-5,-4);
        mas[2] = new ComplexNumber(-2,1);
        mas[3] = new ComplexNumber(-7,-3);
        mas[4] = new ComplexNumber(-6,-2);


        String actual = ComplexNumber.getAnswerOutput(ComplexNumber.getSumOfArrayOfComplexNumbers(mas));
        String expected = "-21,00 - i10,00";

        Assert.assertEquals(expected, actual);
    }

    @Test
    public void getMultiplyOfArrayOfComplexNums() {

        ComplexNumber[] mas = new ComplexNumber[5];
        mas[0] = new ComplexNumber(1,2);
        mas[1] = new ComplexNumber(5,4);
        mas[2] = new ComplexNumber(2,1);
        mas[3] = new ComplexNumber(7,3);
        mas[4] = new ComplexNumber(6,2);


        String actual = ComplexNumber.getAnswerOutput(ComplexNumber.getMultiplyOfArrayOfComplexNumbers(mas));
        String expected = "-1520,00 + i260,00";

        Assert.assertEquals(expected, actual);
    }
}
