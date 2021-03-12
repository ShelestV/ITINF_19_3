public class ComplexNumber {
    private double real, imagine;

    public ComplexNumber(double real, double imagine){
        this.real = real;
        this.imagine = imagine;
    }
    public double getReal(){
        return real;
    }
    public double getImagine(){
        return imagine;
    }


    public static ComplexNumber getSumOfArrayOfComplexNumbers(ComplexNumber[] numMas){
        int n = numMas.length;
        ComplexNumber result = new ComplexNumber(numMas[0].getReal(), numMas[0].getImagine());
        for(int i = 1;i<n;i++){
            double realTmp = result.getReal()+numMas[i].getReal();
            double imagineTmp = result.getImagine()+numMas[i].getImagine();
            result = new ComplexNumber(realTmp, imagineTmp);
        }
        return result;
    }

    public static ComplexNumber getMultiplyOfArrayOfComplexNumbers(ComplexNumber[] numMas){
        int n = numMas.length;
        ComplexNumber result = new ComplexNumber(numMas[0].getReal(), numMas[0].getImagine());
        for(int i = 1;i<n;i++){
            double realTmp = result.getReal()*numMas[i].getReal()-result.getImagine()*numMas[i].getImagine();
            double imagineTmp = result.getReal()*numMas[i].getImagine()+result.getImagine()*numMas[i].getReal();
            result = new ComplexNumber(realTmp, imagineTmp);
        }
        return result;
    }

    public static ComplexNumber getSumOfComplexNumbers(ComplexNumber num1, ComplexNumber num2){
        return new ComplexNumber(num1.getReal()+num2.getReal(), num1.getImagine()+num2.getImagine());
    }

    public static ComplexNumber getSubOfComplexNumbers(ComplexNumber num1, ComplexNumber num2){
        return new ComplexNumber(num1.getReal()-num2.getReal(), num1.getImagine()-num2.getImagine());
    }

    public static ComplexNumber getSqrOfComplexNumber(ComplexNumber num){
        return new ComplexNumber(num.getReal()*num.getReal()-num.getImagine()*num.getImagine(), num.getReal()*num.getImagine()+num.getImagine()*num.getReal());
    }

    public static ComplexNumber getSqrtOfComplexNumber(ComplexNumber num){
        double a = Math.sqrt(num.getReal() * num.getReal() + num.getImagine() * num.getImagine()) / 2;
        return new ComplexNumber(Math.sqrt(a+num.getReal()/2), Math.signum(num.getImagine())*Math.sqrt(a-num.getReal()/2));
    }

    public static String getAnswerOutput(ComplexNumber num){
        StringBuilder str = new StringBuilder();
        String tmp = String.format("%.2f", num.getReal());
        str.append(tmp);
        if(num.getImagine()<0){
            str.append(" - i");
        } else{
            str.append(" + i");
        }
        double tmp1 = num.getImagine()*num.getImagine()/2;
        tmp = String.format("%.2f", tmp1);
        str.append(tmp);

        return str.toString();
    }
}
