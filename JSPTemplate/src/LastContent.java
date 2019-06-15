import utils.Content;
import utils.DBUtil;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.List;

@WebServlet("/LastContent")
public class LastContent extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        DBUtil dbUtil = new DBUtil();
        List<Content> contents = dbUtil.getLastContent();
        PrintWriter out = response.getWriter();
        String s = "";
        for (int i = 0; i < contents.size(); i++) {
            Content c = contents.get(i);
            s += c.getId()+","+c.getTitle() + "," + c.getDescription() + "," + c.getUrl() + ";";
        }
        out.println(s);
        System.out.println("yaassssss");
        System.out.println(s);
        out.close();
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }
}
