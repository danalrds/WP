import utils.DBUtil;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

@WebServlet(name = "/Vote")
public class Vote extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException{
        String photoPath=request.getParameter("photoPath");
        String currentUser=request.getParameter("currentUser");
        DBUtil dbUtil=new DBUtil();

        try {
            dbUtil.increaseVotes(photoPath,currentUser);
            response.sendRedirect("indexLogged.jsp");

        } catch (Exception e) {
            e.printStackTrace();
        }

    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }
}
