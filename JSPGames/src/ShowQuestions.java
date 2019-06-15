import utils.DBUtil;
import utils.Question;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.List;

@WebServlet("/ShowQuestions")
public class ShowQuestions extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

        DBUtil dbUtil = new DBUtil();
        String name = request.getParameter("game");
        Integer gameId = dbUtil.getIdOfGame(name);
        System.out.println(gameId);
        List<Question> questions = dbUtil.selectQuestions(gameId);
        System.out.println("nr questions"+questions.size());
        if (questions.size() > 0) {
            String html = "<tr><th>Question</th><th>Answer1</th><th>Answer2</th></tr>";
            html += questions.stream().map(tr -> "<tr><td>" + tr.getQuestion() + "</td><td>" +
                    tr.getCorrect() + " <input type=\"checkbox\" onclick=addAnswer()></td><td>" +
                    tr.getWrong() + " <input type=\"checkbox\" onclick=addWrong()></td></tr>")
                    .reduce("", (acc, elem) -> acc + elem);
            PrintWriter out = response.getWriter();
            out.println(html);
            out.close();
            request.getSession().setAttribute("game", name);
            request.getSession().setAttribute("crtLevel", dbUtil.getLevelOfGame(name));
            System.out.println(request.getSession().getAttribute("game"));
            request.getSession().setAttribute("nrQuestions", questions.size());
        }
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }
}
