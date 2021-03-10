public class MasWork {

    int len;
    int[] orMas;
    int[] lenMas;
    String mode = "up";
    String orStr;
    String result = "";
    public String masWork(String mode_) {

        if(orStr.equalsIgnoreCase("")) { return result;}
        String[] wordMas = orStr.split("\\s");
        if(mode_.equalsIgnoreCase("down") || mode_.equalsIgnoreCase("up")){
            mode = mode_;
        }
        else { return "ERROR! wrong mode of work entered!"; }
        len = wordMas.length;
        orMas = new int[len];
        lenMas = new int[len];

        for(int i=0;i<len;++i) {
            try {
                Integer.parseInt(wordMas[i].trim());
            } catch (Exception e) {
                return "ERROR! Not numeric literal was found!";
            }
            int curNum = orMas[i] = Integer.parseInt(wordMas[i].trim());
            int lenOfNum = 0;
            while (curNum / 10 != 0) {
                lenOfNum++;
                curNum /= 10;
            }
            lenMas[i] = lenOfNum;
        }

        if(mode.equalsIgnoreCase("down")) {
            for (int i = 0; i < len; ++i) {
                for (int j = 0; j < len - i - 1; ++j) {
                    if (lenMas[j] < lenMas[j + 1]) {
                        int tmp = lenMas[j];
                        lenMas[j] = lenMas[j + 1];
                        lenMas[j + 1] = tmp;

                        tmp = orMas[j];
                        orMas[j] = orMas[j + 1];
                        orMas[j + 1] = tmp;
                    }
                }
            }
        }
        else {
            for (int i = 0; i < len; ++i) {
                for (int j = 0; j < len - i - 1; ++j) {
                    if (lenMas[j] > lenMas[j + 1]) {
                        int tmp = lenMas[j];
                        lenMas[j] = lenMas[j + 1];
                        lenMas[j + 1] = tmp;

                        tmp = orMas[j];
                        orMas[j] = orMas[j + 1];
                        orMas[j + 1] = tmp;
                    }
                }
            }
        }

        for(int i=0;i<len;++i) {
            result += orMas[i];
            if(i!=len-1){
                result += " ";
            }
        }
        return result;
    }
}