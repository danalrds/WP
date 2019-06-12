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
            conn = DriverManager.getConnection("jdbc:mysql://localhost/documents", "root", "");
            stmt = conn.createStatement();
        } catch (Exception ex) {
            System.out.println("eroare la connect:" + ex.getMessage());
            ex.printStackTrace();
        }
    }

    public String getValueFromKey(String key) {
        ResultSet rs;
        try {
            rs = stmt.executeQuery("select * from keywords WHERE kei='" + key + "'");
            while (rs.next()) {
                return rs.getString("value");

            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;

    }

    public String getTextFromName(String name) {
        ResultSet rs;
        try {

            rs = stmt.executeQuery("select * from templates WHERE name='" + name + "'");
            while (rs.next()) {
                if (rs.getInt("private") == 1)
                    return "Template is private";
                String text = rs.getString("text");
                return text;
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;

    }

    public Document getDocumentById(Integer idd) {
        ResultSet rs;
        try {

            rs = stmt.executeQuery("select * from documents WHERE id=" + idd + "");
            while (rs.next()) {
                Integer id = rs.getInt("id");
                String name = rs.getString("title");
                String templates = rs.getString("listOfTemplates");
                return new Document(id, name, templates);
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;

    }

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

    public void addDocument(String title, String templates) throws Exception {
        String sql = "INSERT INTO documents(title,listOfTemplates) VALUES (?,?)";
        PreparedStatement ps = conn.prepareStatement(sql);
        ps.setString(1, title);
        ps.setString(2, templates);
        ps.executeUpdate();
    }

    public void addTemplate(String name, String text, Integer priv) throws Exception {
        String sql = "INSERT INTO templates(name,text,private) VALUES (?,?,?)";
        PreparedStatement ps = conn.prepareStatement(sql);
        ps.setString(1, name);
        ps.setString(2, text);
        ps.setInt(3, priv);
        ps.executeUpdate();
    }

    public void addKey(String key, String value) throws Exception {
        String sql = "INSERT INTO keywords(kei,value) VALUES (?,?)";
        PreparedStatement ps = conn.prepareStatement(sql);
        ps.setString(1, key);
        ps.setString(2, value);
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