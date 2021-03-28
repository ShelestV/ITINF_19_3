package firstLaba.Tests;

import firstLaba.Permutator;
import org.junit.jupiter.api.Test;

import java.util.ArrayList;

import static org.junit.jupiter.api.Assertions.*;

class PermutatorTest {

    @Test
    void permutate() {
        var words = new ArrayList<String>();
        words.add("lisbon");
        words.add("bad");
        words.add("amsterdam");
        words.add("barcelona");
        words.add("novokuznetsk");
        words.add("montreal");
        

        var expected = new ArrayList<String>();
        expected.add("barcelona");
        expected.add("amsterdam");
        expected.add("montreal");
        expected.add("lisbon");
        expected.add("novokuznetsk");
        expected.add("bad");

        ArrayList<String> actual = Permutator.permutate((words));

        var isCorrect = true;

        for(int i = 0; i < words.size(); ++i){
            if(!actual.get(i).equals(expected.get(i))){
                isCorrect = false;
                break;
            }
        }
        assertTrue(isCorrect);
    }
}