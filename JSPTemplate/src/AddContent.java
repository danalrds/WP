import utils.DBUtil;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.time.LocalDate;

@WebServlet("/AddContent")
public class AddContent extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        DBUtil dbUtil=new DBUtil();
        LocalDate date=LocalDate.now();
        String dateF=date.toString();
        String username=(String)request.getSession().getAttribute("username");
        Integer userId=dbUtil.getIdOfUser(username);
        String data=request.getParameter("data");
        String[] vals=data.split(";");
        for (int i=0;i<vals.length;i++){
            String[] arr=vals[i].split(",");
            dbUtil.addContent(dateF,arr[0], arr[1],arr[2], userId);
        }
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }
}
