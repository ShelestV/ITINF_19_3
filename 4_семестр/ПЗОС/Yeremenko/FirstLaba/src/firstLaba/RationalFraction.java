package firstLaba;

public class RationalFraction {
    private int numerator;
    private int denominator;

    private void takeCareOfNegativeDenominator(int denominator)
    {
        if(denominator < 0) {
            numerator = -numerator;
            this.denominator = -denominator;
        }
        else{
            this.denominator = denominator;
        }
    }

    public RationalFraction(int numerator, int denominator){
        this.numerator = numerator;
        takeCareOfNegativeDenominator(denominator);
    }
    public void setNumerator(int numerator){
        this.numerator = numerator;
    }
    public int getNumerator(){
        return numerator;
    }
    public void setDenominator(int denominator){
        takeCareOfNegativeDenominator(denominator);
    }
    public int getDenominator(){
        return denominator;
    }
}
