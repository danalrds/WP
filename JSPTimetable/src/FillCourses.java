import utils.Course;
import utils.DBUtil;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.List;

@WebServlet("/FillCourses")
public class FillCourses extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        DBUtil dbUtil = new DBUtil();
        List<Course> courses = dbUtil.selectCourses();
        String html = courses.stream()
                .map(c -> "<option id=number" + c.getId() + ">" + c.getName() + "</option>")
                .reduce("", (acc, elem) -> acc + elem);
        System.out.println(html);
        PrintWriter out = response.getWriter();
        out.println(html);
        out.close();
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }
}
