package utils;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;

public class DBUtil {
    private Statement stmt;
    private Connection conn;

    public DBUtil() {
        connect();
    }

    public void connect() {
        try {
            Class.forName("org.gjt.mm.mysql.Driver");
            conn = DriverManager.getConnection("jdbc:mysql://localhost/prac", "root", "");
            stmt = conn.createStatement();
        } catch (Exception ex) {
            System.out.println("eroare la connect:" + ex.getMessage());
            ex.printStackTrace();
        }
    }


    public List<String> selectContents(Integer userId) {
        List<String> slist = new ArrayList<>();
        try {

            String sql = ("select * from content where userid=?");
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setInt(1, userId);
            ResultSet rs = ps.executeQuery();
            while (rs.next()) {

                String name = rs.getString("title");
                slist.add(name);
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return slist;
    }


    public List<Content> getLastContent() {
        List<Content> slist = new ArrayList<>();
        try {

            String sql = ("SELECT * FROM content ORDER BY id DESC LIMIT 4");
            PreparedStatement ps = conn.prepareStatement(sql);
            ResultSet rs = ps.executeQuery();
            while (rs.next()) {
                Integer id=rs.getInt("id");
                String title = rs.getString("title");
                String description = rs.getString("description");
                String url = rs.getString("url");
                slist.add(new Content(id, title, description, url));
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return slist;
    }

    public void addContent(String date, String title, String description, String url, Integer userId) {
        String sql = "INSERT INTO content(date, title,description,url,userid) VALUES (?,?,?,?,?)";
        PreparedStatement ps = null;
        try {
            ps = conn.prepareStatement(sql);
            ps.setString(1, date);
            ps.setString(2, title);
            ps.setString(3, description);
            ps.setString(4, url);
            ps.setInt(5, userId);
            ps.executeUpdate();
        } catch (SQLException e) {
            e.printStackTrace();
        }

    }

    public void deleteContent(String title) {
        String sql = "delete from content where title=?";
        PreparedStatement ps = null;
        try {
            ps = conn.prepareStatement(sql);
            ps.setString(1, title);
            ps.executeUpdate();
        } catch (SQLException e) {
            e.printStackTrace();
        }

    }


    public Integer getIdOfUser(String username) {
        String sql = "SELECT * FROM users WHERE username=?";
        PreparedStatement ps = null;
        try {
            ps = conn.prepareStatement(sql);
            ps.setString(1, username);
            ResultSet rs = ps.executeQuery();
            if (rs.next()) {
                Integer userId = rs.getInt("id");
                return userId;
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }

        throw new RuntimeException("User not found!");
    }

    public String findUser(String username, String password) {
        ResultSet rs;
        System.out.println(username + " " + password);
        try {
            String sql = "select * from users where username=? and password=?";
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setString(1, username);
            ps.setString(2, password);
            rs = ps.executeQuery();
            if (rs.next()) {
                if (username.equals("user1"))
                    return "creator";
                else {
                    return "reader";
                }
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return "";
    }


}