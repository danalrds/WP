import utils.DBUtil;
import utils.Room;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.List;

@WebServlet("/SelectPossibilities")
public class SelectPossibilities extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        DBUtil dbUtil = new DBUtil();
        List<Room> rooms = dbUtil.selectRooms();
        String courseName = request.getParameter("course");
        String day = request.getParameter("day");
        Integer startHour = Integer.parseInt(request.getParameter("startHour"));
        try {
            Integer courseId = dbUtil.getIdOfCourse(courseName);

            String html = rooms.stream().map(r -> {
                if (dbUtil.isRestricted(courseId, r.getName()))
                    return "<tr style=\"background-color:red\"><td>" + r.getName() + "</td></tr>";
                else if (dbUtil.isReserved(day, r.getId(), startHour))
                    return "<tr style=\"background-color:orange\"><td>" + r.getName() + "</td></tr>";
                else
                    return "<tr style=\"background-color:green\" onclick=addInTimetable("+courseId+","+r.getId()+")><td>" + r.getName() + "</td></tr>";
            })
                    .reduce("", (acc, elem) -> acc + elem);
            PrintWriter out = response.getWriter();
            out.println(html);
            out.close();
        } catch (Exception e) {
            e.printStackTrace();
        }

    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }
}
