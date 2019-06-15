import utils.DBUtil;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.List;

@WebServlet("/ShowGames")
public class ShowGames extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        DBUtil dbUtil = new DBUtil();
        System.out.println("ENTERRRED");
        Integer level = (Integer)(request.getSession().getAttribute("level"));
        System.out.println(level);
        List<String> rows = dbUtil.selectGames(level);
        if (rows.size() > 0) {
            String html = "<tr><th>Game</th><th>Play</th></tr>";
            html += rows.stream().map(tr -> "<tr><td>" + tr + "</td>"+
                    "<td onclick=play('" + tr + "')>Play</td>"
                    +"</tr>")
                    .reduce("", (acc, elem) -> acc + elem);
            PrintWriter out = response.getWriter();
            out.println(html);
            out.close();
            request.getSession().setAttribute("points", 0);

        }

    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }
}
