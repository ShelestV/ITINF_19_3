import org.junit.Assert;
import org.junit.Test;

public class StringWorkTest {

    @Test
    public void stringWorkWrongTest() {
        StringWork sw = new StringWork();

        String actual = sw.stringWork("0101", 1);
        String expected = "-1";

        Assert.assertEquals(expected, actual);
    }

    @Test
    public void stringWorkAll9Test() {
        StringWork sw = new StringWork();

        String actual = sw.stringWork("4721342", 7);
        String expected = "9999999";

        Assert.assertEquals(expected, actual);
    }

    @Test
    public void stringWorkRightTest() {
        StringWork sw = new StringWork();

        String actual = sw.stringWork("2101", 2);
        String expected = "2112";

        Assert.assertEquals(expected, actual);
    }
}
