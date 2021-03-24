package firstLaba;

import java.util.ArrayList;

public class RationalFractionHandler {
    public static RationalFraction sumFractions(RationalFraction firstFraction, RationalFraction secondFraction){
        if(firstFraction.getDenominator() == 0 || firstFraction.getNumerator() == 0){
            return secondFraction;
        }
        else if(secondFraction.getNumerator() == 0 || secondFraction.getDenominator() == 0){
            return  firstFraction;
        }
        int firstAddendum = firstFraction.getNumerator() * secondFraction.getDenominator();
        int secondAddendum = secondFraction.getNumerator() * firstFraction.getDenominator();
        int newNumerator = firstAddendum + secondAddendum;
        int newDenominator = firstFraction.getDenominator() * secondFraction.getDenominator();
        return new RationalFraction(newNumerator, newDenominator);
    }

    public static void increaseEvenItemsWithOddOnes(ArrayList<RationalFraction> fractions){
        for(var i = 0; i + 1 < fractions.size(); i += 2){
            fractions.set(i, sumFractions(fractions.get(i), fractions.get(i + 1)));
        }
    }
}
