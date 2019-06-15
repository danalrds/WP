import utils.DBUtil;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;

@WebServlet("/CompleteGame")
public class CompleteGame extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        DBUtil dbUtil=new DBUtil();
        Integer points=(Integer)request.getSession().getAttribute("points");
        Integer nrQuestions=(Integer)request.getSession().getAttribute("nrQuestions");
        String username=(String)request.getSession().getAttribute("username");
        String game=(String)request.getSession().getAttribute("game");
        request.getSession().setAttribute("crtLevel", dbUtil.getLevelOfGame(game));
        Integer level=(Integer)request.getSession().getAttribute("crtLevel");
        if(points==nrQuestions){
            dbUtil.addCompleted(username,game);

            level++;
            request.getSession().setAttribute("level",level);
            request.getSession().setAttribute("points",0);
            System.out.println(request.getSession().getAttribute("level"));
        }
        PrintWriter out=response.getWriter();
        out.println(level);
        out.close();

    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }
}
