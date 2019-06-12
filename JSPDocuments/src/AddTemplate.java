import utils.DBUtil;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

@WebServlet("/AddTemplate")
public class AddTemplate extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String name = request.getParameter("name");
        String text = request.getParameter("text");
        Integer priv = Integer.parseInt(request.getParameter("priv"));
        System.out.println(name);
        System.out.println(text);
        System.out.println(priv);
        DBUtil dbUtil = new DBUtil();
        try {
            dbUtil.addTemplate(name,text,priv);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }
}
