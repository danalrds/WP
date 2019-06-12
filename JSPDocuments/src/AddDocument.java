import utils.DBUtil;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

@WebServlet("/AddDocument")
public class AddDocument extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String title = request.getParameter("title");
        String templates = request.getParameter("templates");
        System.out.println(title);
        System.out.println(templates);
        DBUtil dbUtil = new DBUtil();
        try {
            dbUtil.addDocument(title, templates);
        } catch (Exception e) {
            e.printStackTrace();
        }
        response.sendRedirect("/index.jsp");
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }
}
