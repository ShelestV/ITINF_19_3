public class StringWork {
    static String stringWork(String str, int numOfSteps) {
        int n = str.length();
        int startInd = 0;
        int endInd = n-1;
        char[] string = str.toCharArray();
        int neededChanges = 0;

        for(int i=0, j=n-1; i<n/2; i++, j--){
            if (string[i] != string[j]){
                neededChanges++;
            }
        }

        if (neededChanges > numOfSteps){
            return "-1";
        }

        while(endInd >= startInd){
            if (numOfSteps <= 0){
                break;
            }

            if (string[startInd] == string[endInd]){
                if (numOfSteps > 1 && (numOfSteps-2) >= neededChanges && string[startInd] != '9'){
                    string[startInd] = '9';
                    string[endInd] = '9';
                    numOfSteps-=2;
                }
            }
            else {
                if (numOfSteps > 1 && (numOfSteps-2) >= neededChanges-1){
                    if (string[startInd] != '9'){
                        string[startInd] = '9';
                        numOfSteps--;
                    }
                    if (string[endInd] != '9'){
                        string[endInd] = '9';
                        numOfSteps--;
                    }
                } else {
                    if (string[startInd] > string[endInd]){
                        string[endInd] = string[startInd];
                    } else {
                        string[startInd] = string[endInd];
                    }
                    numOfSteps--;
                }
                neededChanges--;
            }
            if (startInd == endInd && numOfSteps > 0){
                string[startInd] = '9';
                numOfSteps--;
            }
            startInd++;
            endInd--;
        }

        str = String.valueOf(string);
        return isPalindrome (str) ? str : "-1";
    }

    static boolean isPalindrome(String number){
        int start = 0;
        int end = number.length()-1;

        while(end > start){
            if (number.charAt(start) == number.charAt(end)){
                start++; end--;
            } else {
                return false;
            }
        }
        return true;
    }
}
