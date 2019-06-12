import utils.DBUtil;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

@WebServlet("/AddRestriction")
public class AddRestriction extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String name = request.getParameter("name");
        String restrictions = request.getParameter("restrictions");
        System.out.println(name);
        System.out.println(restrictions);

        DBUtil dbUtil = new DBUtil();
        try {
            Integer id=dbUtil.getIdOfCourse(name);
            dbUtil.addRestriction(id, restrictions);
        } catch (Exception e) {
            e.printStackTrace();
        }
        response.sendRedirect("/index.jsp");
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }
}
