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

        // il - index of lines
        for (int il = 1; il < lines.size(); ++il) {
            boolean isPar = false;
            for (List<Line> lineList : result) {
                // irl - index of result lines
                for (int irl = 0; irl < lineList.size(); ++irl) {
                    if (lineList.get(irl).isParallel(lines.get(il))) {
                        lineList.add(lines.get(il));
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
                inter.add(lines.get(il));
                result.add(inter);
            }
        }

        return result;
    }
}
