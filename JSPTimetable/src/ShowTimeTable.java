import utils.DBUtil;
import utils.TimeTableRow;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.List;

@WebServlet("/ShowTimeTable")
public class ShowTimeTable extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        DBUtil dbUtil = new DBUtil();
        List<TimeTableRow> rows = dbUtil.selectRows();
        if (rows.size() > 0) {
            String html = "<tr><th>Day</th><th>Course</th><th>Room</th><th>StartHour</th><th>EndHour</th></tr>";
            html += rows.stream().map(tr -> "<tr><td>" + tr.getDay() + "</td><td>" +
                    dbUtil.getNameOfCourse(tr.getCourseId()) + "</td><td>" +
                    dbUtil.getNameOfRoom(tr.getRoomId()) + "</td><td>" +
                    tr.getStartHour() + "</td><td>" +
                    tr.getEndHour() + "</td></tr>")
                    .reduce("", (acc, elem) -> acc + elem);
            PrintWriter out = response.getWriter();
            out.println(html);
            out.close();
        }

    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }
}
