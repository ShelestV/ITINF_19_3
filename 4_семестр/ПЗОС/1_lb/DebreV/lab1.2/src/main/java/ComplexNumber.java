/*
а) Определить класс Комплексное Число. Создать массив/список/множество
размерности n из комплексных координат. Передать его в метод, который выполнит сложение/умножение его элементов.
б) Определить класс Полином с коэффициентами типа Комплексное число.
Объявить массив/список/множество из m полиномов и определить сумму полиномов массива.
 */

public class ComplexNumber {
    float complexPart;
    float realPart;
    ComplexNumber(){
        this.complexPart = 0.f;
        this.realPart = 0.f;
    }
    ComplexNumber(float complex, float real){
        this.complexPart = complex;
        this.realPart = real;
    }
    public void AddNumber(ComplexNumber number){
        this.complexPart += number.complexPart;
        this.realPart += number.realPart;
    }
    public void AddArrayNumbers(ComplexNumber[] complexArray){
        this.complexPart = complexArray[0].complexPart;
        this.realPart = complexArray[0].realPart;
        for (int i = 1; i < complexArray.length; i++) {
            this.complexPart += complexArray[i].complexPart;
            this.realPart += complexArray[i].realPart;
        }
    }
    public void MultiplyArrayNumbers(ComplexNumber[] complexArray){
        this.complexPart = complexArray[0].complexPart;
        this.realPart = complexArray[0].realPart;
        for (int i = 1; i < complexArray.length; i++) {
            this.complexPart = this.realPart * complexArray[i].complexPart + this.complexPart * complexArray[i].realPart;
            this.realPart =this.realPart * complexArray[i].realPart - this.complexPart * complexArray[i].complexPart;
        }
        System.out.println("complexPart = " + complexPart);
        System.out.println("realPart = " + realPart);
    }
}