package nure.itinf_19_3.shelest;

import java.util.ArrayList;
import java.util.List;

public class LineServer {
    public static List<List<Line>> parallelsLines(List<Line> lines) {
        if (lines == null) {
            return null;
        }
        List<List<Line>> result = new ArrayList<>();
        List<Line> list = new ArrayList<>();
        list.add(lines.get(0));
        result.add(list);
        for (int indexLines = 1; indexLines < lines.size(); ++indexLines) {
            boolean isPar = false;
            for (int indexResultLines = 0; indexResultLines < result.size(); ++indexResultLines) {
                for (int indexResultLine = 0; indexResultLine < result.get(indexResultLines).size(); ++indexResultLine) {
                    if (result.get(indexResultLines).get(indexResultLine).isParallel(lines.get(indexLines))) {
                        result.get(indexResultLines).add(lines.get(indexLines));
                        isPar = true;
                        break;
                    }
                }
                if (isPar) {
                    break;
                }
            }
            if (!isPar) {
                List<Line> inter = new ArrayList<>();
                inter.add(lines.get(indexLines));
                result.add(inter);
            }
        }

        return result;
    }
}
