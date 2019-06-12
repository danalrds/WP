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
            conn = DriverManager.getConnection("jdbc:mysql://localhost/lab7", "root", "");
            stmt = conn.createStatement();
        } catch (Exception ex) {
            System.out.println("eroare la connect:" + ex.getMessage());
            ex.printStackTrace();
        }
    }


    public void addUser(String username, String password) throws Exception {
        String sql = "INSERT INTO users(username,password) VALUES (?,?)";
        PreparedStatement ps = conn.prepareStatement(sql);
        ps.setString(1, username);
        ps.setString(2, password);
        ps.executeUpdate();
    }

    public Integer getIdOfUser(String username) throws Exception {
        String sql = "SELECT id FROM users WHERE username=?";
        PreparedStatement ps = conn.prepareStatement(sql);
        ps.setString(1, username);
        ResultSet rs = ps.executeQuery();
        if (rs.next()) {
            Integer id = rs.getInt("id");
            return id;
        }
        throw new RuntimeException("User not found! " + username);
    }

    public Integer getUserIdOfPhoto(String path) throws Exception {
        String sql = "SELECT userid FROM photos WHERE path=?";
        PreparedStatement ps = conn.prepareStatement(sql);
        ps.setString(1, path);
        ResultSet rs = ps.executeQuery();
        if (rs.next()) {
            Integer userId = rs.getInt("userid");
            return userId;
        }
        throw new RuntimeException("Photo not found!");
    }

    public boolean findUser(String username, String password) {
        ResultSet rs;
        System.out.println(username + " " + password);
        try {
            String sql = "select * from users where username=? and password=?";
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setString(1, username);
            ps.setString(2, password);
            rs = ps.executeQuery();
            if (rs.next()) {
                rs.close();
                return true;
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return false;
    }


}