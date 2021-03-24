package firstLaba;

import java.util.ArrayList;

public class Polynomial {
    private final ArrayList<RationalFraction> coefficients;

    public Polynomial(ArrayList<RationalFraction> coefficients){
        this.coefficients = coefficients;
    }

    public RationalFraction getSum(){
        var sum = new RationalFraction(0, 0);
        for(RationalFraction fraction : coefficients){
            RationalFraction tempSum = RationalFractionHandler.sumFractions(sum, fraction);
            sum.setNumerator(tempSum.getNumerator());
            sum.setDenominator(tempSum.getDenominator());
        }
        return sum;
    }
}
