import utils.DBUtil;
import utils.Document;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.List;

@WebServlet("/SearchDocument")
public class SearchDocument extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        DBUtil dbUtil = new DBUtil();
        PrintWriter out = response.getWriter();
        response.setContentType("text/html");
        System.out.println(request.getParameter("word"));
        String word = request.getParameter("word");
        List<Document> docs = dbUtil.findDocuments(word);
        String html = "";
        int i = 0;
        html = docs.stream()
                .map(document -> "<tr id='row" + i + "' onclick=generate(" + document.getId() + ")><td>" + document.getName() + "</td><td>" + document.getTemplates() + "</td><tr>")
                .reduce("", (s, elem) -> s += elem);
        System.out.println(html);
        out.println(html);
        out.close();
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }
}
