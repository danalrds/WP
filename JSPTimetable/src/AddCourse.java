import utils.DBUtil;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

@WebServlet("/AddCourse")
public class AddCourse extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String name = request.getParameter("name");
        String teacher = request.getParameter("teacher");
        Integer duration = Integer.parseInt(request.getParameter("duration"));
        System.out.println(name);
        System.out.println(duration);

        DBUtil dbUtil = new DBUtil();
        try {
            dbUtil.addCourse(name, teacher, duration);
        } catch (Exception e) {
            e.printStackTrace();
        }
        response.sendRedirect("/index.jsp");
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }
}
