public class MasWork {
    String mode = "up";
    String orStr;
    public String masWork(String mode_) {

        StringBuilder result = new StringBuilder();
        if(orStr.equalsIgnoreCase("")) { return result.toString();}
        String[] wordMas = orStr.split("\\s");
        if(mode_.equalsIgnoreCase("down") || mode_.equalsIgnoreCase("up")){
            mode = mode_;
        }
        else { return "ERROR! wrong mode of work entered!"; }
        int len = wordMas.length;
        int[] orMas = new int[len];
        int[] lenMas = new int[len];

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
            result.append(orMas[i]);
            if(i!=len-1){
                result.append(" ");
            }
        }
        return result.toString();
    }
}