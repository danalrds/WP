import utils.DBUtil;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.List;

@WebServlet("/Completed")
public class Completed extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        DBUtil dbUtil = new DBUtil();
        String username=(String)request.getSession().getAttribute("username");
        List<String> rows = dbUtil.selectCompleted(username);
        if (rows.size() > 0) {
            String html = "<tr><th>Game</th><th>Points</th></tr>";
            html += rows.stream().map(tr -> "<tr><td>" + tr + "</td><td>" +dbUtil.getLevelOfGame(tr)+ "</td></tr>")
                    .reduce("", (acc, elem) -> acc + elem);
            PrintWriter out = response.getWriter();
            out.println(html);
            out.close();
        }
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }
}
