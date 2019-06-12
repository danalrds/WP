import utils.DBUtil;
import utils.Document;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.Arrays;
import java.util.List;

@WebServlet("/GenerateDocument")
public class GenerateDocument extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        DBUtil dbUtil = new DBUtil();
        Integer id = Integer.parseInt(request.getParameter("id"));
        Document doc = dbUtil.getDocumentById(id);
        String templates = doc.getTemplates();
        List<String> temps = Arrays.asList(templates.split(", "));
        String html = temps.stream()
                .map(dbUtil::getTextFromName)
                .map(content -> {
                    List<String> words = Arrays.asList(content.split(" "));
                    return words.stream()
                            .map(word -> {
                                if (word.startsWith("{{")) {
                                    return dbUtil.getValueFromKey(word.substring(2, word.length() - 2));

                                } else {
                                    return word;
                                }
                            })
                            .reduce("", (acc, elem) -> acc += " " + elem);
                })
                .reduce("", (acc, elem) -> {
                    if (elem.equals(" Template is private")) {

                        return acc + "<p style='background:red'>" + elem + "</p>";
                    }
                    return acc + "<p>" + elem + "</p>";
                });
        PrintWriter pw = response.getWriter();
        System.out.println(html);
        pw.write(html);
        pw.close();

    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }
}
