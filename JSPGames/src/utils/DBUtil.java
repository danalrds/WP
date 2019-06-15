package utils;

import java.sql.*;
import java.util.ArrayList;
import java.util.Arrays;
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
            conn = DriverManager.getConnection("jdbc:mysql://localhost/games", "root", "");
            stmt = conn.createStatement();
        } catch (Exception ex) {
            System.out.println("eroare la connect:" + ex.getMessage());
            ex.printStackTrace();
        }
    }


    public List<String> selectGames(Integer level) {
        List<String> slist = new ArrayList<>();
        try {

            String sql = ("select * from tests where level<=?");
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setInt(1, level);
            ResultSet rs = ps.executeQuery();
            while (rs.next()) {

                String name = rs.getString("name");
                slist.add(name);
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return slist;
    }

    public Integer getIdOfGame(String name) {
        String sql = "SELECT id FROM tests WHERE name=?";
        PreparedStatement ps = null;
        try {
            ps = conn.prepareStatement(sql);
            ps.setString(1, name);
            ResultSet rs = ps.executeQuery();
            if (rs.next()) {
                Integer id = rs.getInt("id");
                return id;
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }

        throw new RuntimeException("game not found! " + name);
    }

    public Integer getLevelOfGame(String name) {
        String sql = "SELECT level FROM tests WHERE name=?";
        PreparedStatement ps = null;
        try {
            ps = conn.prepareStatement(sql);
            ps.setString(1, name);
            ResultSet rs = ps.executeQuery();
            if (rs.next()) {
                Integer level = rs.getInt("level");
                return level;
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }

        throw new RuntimeException("game not found! " + name);
    }

    public Integer getPoints(String username) {
        String sql = "SELECT tests FROM users WHERE username=?";
        PreparedStatement ps = null;
        try {
            ps = conn.prepareStatement(sql);
            ps.setString(1, username);
            ResultSet rs = ps.executeQuery();
            if (rs.next()) {
                String tests = rs.getString("tests");
                String[] vals = tests.split(",");
                Integer points = 0;
                for (int i = 0; i < vals.length ; i++) {
                    sql = "SELECT * FROM tests WHERE name=?";
                    ps = conn.prepareStatement(sql);
                    ps.setString(1, vals[i]);
                    rs = ps.executeQuery();
                    if (rs.next()) {
                        Integer p = rs.getInt("level");
                        points += p;
                    }
                }
                return points;
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }

        throw new RuntimeException("user not found! " + username);
    }


    public List<String> selectCompleted(String username) {
        String sql = "SELECT tests FROM users WHERE username=?";
        PreparedStatement ps = null;
        try {
            ps = conn.prepareStatement(sql);
            ps.setString(1, username);
            ResultSet rs = ps.executeQuery();
            if (rs.next()) {
                String tests = rs.getString("tests");
                String[] vals = tests.split(",");
                return Arrays.asList(vals);
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }

        throw new RuntimeException("user not found! " + username);
    }


    public List<Question> selectQuestions(Integer testId) {
        List<Question> slist = new ArrayList<>();
        try {

            String sql = ("select * from questions where testid=?");
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setInt(1, testId);
            ResultSet rs = ps.executeQuery();
            while (rs.next()) {
                Integer id = rs.getInt("id");
                String question = rs.getString("question");
                String correct = rs.getString("correct");
                String wrong = rs.getString("wrong");
                slist.add(new Question(id, testId, question, correct, wrong));
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return slist;
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
                String role=rs.getString("role");
                System.out.println(role);
                rs.close();
                return role;
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return "";
    }

    public void addCompleted(String username, String game) {
        System.out.println(" game"+game);
        String sql = "update users set tests=concat(tests,'" + game + ",') where username=?";
        PreparedStatement ps = null;
        try {
            ps = conn.prepareStatement(sql);
            ps.setString(1, username);
            ps.executeUpdate();
        } catch (SQLException e) {
            e.printStackTrace();
        }

    }

/*

    public List<Document> findDocuments(String word) {
        List<Document> docs = new ArrayList<Document>();
        ResultSet rs;
        try {

            rs = stmt.executeQuery("select * from documents WHERE title LIKE '%" + word + "%'");
            while (rs.next()) {
                Integer id = rs.getInt("id");
                String name = rs.getString("title");
                String templates = rs.getString("listOfTemplates");
                Document doc = new Document(id, name, templates);
                docs.add(doc);
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return docs;
    }
*/


}