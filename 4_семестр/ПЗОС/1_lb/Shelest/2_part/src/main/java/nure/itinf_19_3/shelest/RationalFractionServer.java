package nure.itinf_19_3.shelest;

import java.util.ArrayList;
import java.util.List;

public class RationalFractionServer {
    public static List<RationalFraction> modifyArray(List<RationalFraction> array) {
        if (array == null)
            return new ArrayList<>();

        List<RationalFraction> result = new ArrayList<>();
        for (int i = 0; i < array.size(); i += 2) {
            if (i + 1 != array.size()) {
                result.add(RationalFraction.addition(array.get(i), array.get(i + 1)));
                result.add(array.get(i + 1));
            }
            else {
                result.add(array.get(i));
            }
        }
        return result;
    }
}
