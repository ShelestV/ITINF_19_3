public class ComplexPolynom {
    int degree;
    ComplexNumber[] coefficients;
    ComplexPolynom(){
        this.degree = 1;
        this.coefficients = new ComplexNumber[] { new ComplexNumber(0.f, 0.f)};
    }
    ComplexPolynom(int degreeNum, ComplexNumber[] coefArray){
        this.degree = degreeNum;
        this.coefficients = coefArray;
    }
    public void AddPolynoms(ComplexPolynom[] arrayPolynoms){
        int maxValue = arrayPolynoms[0].degree;
        for(int i=1;i < arrayPolynoms.length;i++){
            if(arrayPolynoms[i].degree > maxValue) {
                maxValue = arrayPolynoms[i].degree;
            }
        }
        this.degree = maxValue;
        for (int j = 0; j < this.degree; j++) {
            for (int i = 1; i < arrayPolynoms.length; i++) {
                if(arrayPolynoms[i].degree >= j + 1) {
                    this.coefficients[j].AddNumber(arrayPolynoms[i].coefficients[j]);
                }
            }
        }
    }

}

