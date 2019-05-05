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

    public Integer getNumberOfPhotos() throws SQLException {
        String sql = "SELECT COUNT(*) as counter FROM photos";
        PreparedStatement ps = conn.prepareStatement(sql);
        ResultSet rs = ps.executeQuery();
        if (rs.next()) {
            return rs.getInt("counter");
        }
        throw new RuntimeException("Error at select count(*)");
    }

    public void addPhoto(String path, String username) throws Exception {
        Integer userId = getIdOfUser(username);
        String sql = "INSERT INTO photos(path,userid,votes) VALUES (?,?,0)";
        PreparedStatement ps = conn.prepareStatement(sql);
        ps.setString(1, path);
        ps.setInt(2, userId);
        ps.executeUpdate();
    }

    public boolean increaseVotes(String photoPath, String currentUser) throws Exception {
        Integer userId = getUserIdOfPhoto(photoPath);
        Integer id = getIdOfUser(currentUser);
        if (!userId.equals(id)) {
            String sql = "UPDATE photos SET votes=votes+1 WHERE path=?";
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setString(1, photoPath);
            ps.executeUpdate();
            return true;
        } else {
            return false;
        }
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

    public List<Photo> findPhotos() {
        List<Photo> photos = new ArrayList<Photo>();
        ResultSet rs;
        try {
            rs = stmt.executeQuery("select p.id, p.path, u.username,p.votes from photos p inner join users u where u.id=p.userid");
            while (rs.next()) {
                Integer id = rs.getInt("id");
                String path = rs.getString("path");
                String username = rs.getString("username");
                Integer votes = rs.getInt("votes");
                Photo p = new Photo(id, path, username, votes);
                photos.add(p);
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return photos;
    }


    public List<Photo> findTop(Integer topNumber) {
        List<Photo> photos = new ArrayList<Photo>();
        ResultSet rs;
        try {
            rs = stmt.executeQuery("select p.id, p.path, u.username,p.votes from photos p inner join users u where u.id=p.userid ORDER BY votes DESC");
            Integer counter = 0;
            while (rs.next()) {
                Integer id = rs.getInt("id");
                String path = rs.getString("path");
                String username = rs.getString("username");
                Integer votes = rs.getInt("votes");
                Photo p = new Photo(id, path, username, votes);
                photos.add(p);
                counter++;
                if (counter == topNumber) {
                    break;
                }
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return photos;
    }
}