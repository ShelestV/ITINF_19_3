package firstLaba;

public class StringHandler {
    public static int countVowelNumber(String word){
        var counter = 0;
        var vowels = "AEIOUY";
        for(int i = 0; i < word.length(); ++i){
            for(int j = 0; j < vowels.length(); ++j){
                if(word.toUpperCase().charAt(i) == vowels.charAt(j)) ++counter;
            }
        }
        return counter;
    }
    public static String getTheWordWithTheFewestVowels(String text){
        String[] words = text.split(" ");
        int indexOfWordWithTheFewestVowels = 0;
        int minVowels = Integer.MAX_VALUE;
        for(int i = 0; i < words.length; ++i){
            if(minVowels >  countVowelNumber(words[i])){
                indexOfWordWithTheFewestVowels = i;
                minVowels = countVowelNumber(words[i]);
            }
        }
        return words[indexOfWordWithTheFewestVowels];
    }
    /*
    public static void PermutateWords(String text){
        String[] words = text.split(" ");
        for(int i = 0; i < words.length; ++i){
            for(int j = i; j < words.length; ++j){
                if(words[i].charAt(0) == )
            }
        }
    }*/
}
