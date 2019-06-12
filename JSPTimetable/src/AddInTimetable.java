import utils.DBUtil;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

@WebServlet("/AddInTimetable")
public class AddInTimetable extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        DBUtil dbUtil = new DBUtil();
        Integer courseId = Integer.parseInt(request.getParameter("courseId"));
        Integer roomId = Integer.parseInt(request.getParameter("roomId"));
        Integer startHour = Integer.parseInt(request.getParameter("startHour"));
        String day = request.getParameter("day");
        try {
            dbUtil.addInTimetable(courseId, roomId, day, startHour);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }
}
