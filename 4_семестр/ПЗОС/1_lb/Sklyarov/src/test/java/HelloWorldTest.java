import org.junit.Assert;
import org.junit.Test;

public class HelloWorldTest {

    @Test
    public void getHelloWorldTest(){
        HelloWorld hw=new HelloWorld();
        String actual = hw.getHelloWorld();
        String expected = "Hello World!";

        Assert.assertEquals(expected, actual);
    }

}
