import org.junit.Assert;
import org.junit.Test;

public class MasWorkTest {

    @Test
    public void MasWorkUpTest() {
        MasWork mw = new MasWork();
        mw.orStr = "1 100 101 10 20 1 3 234 21";
        String actual = mw.masWork("up");
        String expected = "1 1 3 10 20 21 100 101 234";

        Assert.assertEquals(expected,actual);
    }

    @Test
    public void MasWorkDownTest() {
        MasWork mw = new MasWork();
        mw.orStr = "1 100 101 10 20 1 3 234 21";
        String actual = mw.masWork("down");
        String expected = "100 101 234 10 20 21 1 1 3";

        Assert.assertEquals(expected,actual);
    }

    @Test
    public void MasWorkWrongModeTest() {
        MasWork mw = new MasWork();
        mw.orStr = "100 101 1 10";
        String actual = mw.masWork("$$$");
        String expected = "ERROR! wrong mode of work entered!";

        Assert.assertEquals(expected,actual);
    }

    @Test
    public void MasWorkNullStringTest() {
        MasWork mw = new MasWork();
        mw.orStr = "";
        String actual = mw.masWork("up");
        String expected = "";

        Assert.assertEquals(expected,actual);
    }

    @Test
    public void MasWorkWrongStringTest() {
        MasWork mw = new MasWork();
        mw.orStr = "1 10 100 10 1t1 30 2";
        String actual = mw.masWork("up");
        String expected = "ERROR! Not numeric literal was found!";

        Assert.assertEquals(expected,actual);
    }
}
