package firstLaba;

public class RationalFraction {
    private int numerator;
    private int denominator;

    private void checkDenominator(int denominator)
    {
        if(denominator < 0) {
            numerator = -numerator;
            this.denominator = -denominator;
        }
    }

    public RationalFraction(int numerator, int denominator){
        this.numerator = numerator;
        checkDenominator(denominator);
        this.denominator = denominator;
    }
    public void setNumerator(int numerator){
        this.numerator = numerator;
    }
    public int getNumerator(){
        return numerator;
    }
    public void setDenominator(int denominator){
        checkDenominator(denominator);
        this.denominator = denominator;
    }
    public int getDenominator(){
        return denominator;
    }
}
