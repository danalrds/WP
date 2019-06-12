package utils;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;
import java.util.TimerTask;

public class DBUtil {
    private Statement stmt;
    private Connection conn;

    public DBUtil() {
        connect();
    }

    public void connect() {
        try {
            Class.forName("org.gjt.mm.mysql.Driver");
            conn = DriverManager.getConnection("jdbc:mysql://localhost/timetable", "root", "");
            stmt = conn.createStatement();
        } catch (Exception ex) {
            System.out.println("eroare la connect:" + ex.getMessage());
            ex.printStackTrace();
        }
    }


    public Boolean isReserved(String day, Integer roomId, Integer startHour) {
        String sql = "SELECT * FROM timetable WHERE day=? AND roomid=" + roomId + " AND  startHour=" + startHour;
        try {
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setString(1, day);
            ResultSet rs = ps.executeQuery();
            if (rs.next()) {
                return true;
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }

        return false;
    }

    public Boolean isRestricted(Integer courseId, String roomName) {
        String sql = "SELECT * FROM restrictions WHERE id=" + courseId + " AND restrictions LIKE '%" + roomName + "%'";
        PreparedStatement ps = null;
        try {
            ps = conn.prepareStatement(sql);
            ResultSet rs = ps.executeQuery();
            if (rs.next()) {
                return true;
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }

        return false;
    }


    public List<TimeTableRow> selectRows() {
        List<TimeTableRow> rows = new ArrayList<>();
        ResultSet rs;
        try {

            rs = stmt.executeQuery("select * from timetable");
            while (rs.next()) {
                Integer id = rs.getInt("id");
                Integer courseId = rs.getInt("courseid");
                Integer roomId = rs.getInt("roomid");
                String day = rs.getString("day");
                Integer startHour = rs.getInt("starthour");
                Integer endHour = rs.getInt("endhour");
                TimeTableRow tr = new TimeTableRow(id, courseId, roomId, day, startHour, endHour);
                rows.add(tr);
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return rows;
    }


    public List<Room> selectRooms() {
        List<Room> rooms = new ArrayList<>();
        ResultSet rs;
        try {

            rs = stmt.executeQuery("select * from rooms");
            while (rs.next()) {
                Integer id = rs.getInt("id");
                String name = rs.getString("name");
                Integer capacity = rs.getInt("capacity");
                Room c = new Room(id, name, capacity);
                rooms.add(c);
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return rooms;
    }


    public List<Course> selectCourses() {
        List<Course> courses = new ArrayList<>();
        ResultSet rs;
        try {

            rs = stmt.executeQuery("select * from courses");
            while (rs.next()) {
                Integer id = rs.getInt("id");
                String name = rs.getString("name");
                String teacher = rs.getString("teacher");
                Integer duration = rs.getInt("duration");
                Course c = new Course(id, name, teacher, duration);
                courses.add(c);
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return courses;
    }

    public void addInTimetable(Integer courseId, Integer roomId, String day, Integer startHour) throws Exception {
        String sql = "INSERT INTO timetable(courseid,roomid, day, starthour, endhour) VALUES (?,?,?,?,?)";
        PreparedStatement ps = conn.prepareStatement(sql);
        ps.setInt(1, courseId);
        ps.setInt(2, roomId);
        ps.setString(3, day);
        ps.setInt(4, startHour);
        ps.setInt(5, startHour + 1);
        ps.executeUpdate();
    }

    public void addCourse(String name, String teacher, Integer duration) throws Exception {
        String sql = "INSERT INTO courses(name,teacher, duration) VALUES (?,?,?)";
        PreparedStatement ps = conn.prepareStatement(sql);
        ps.setString(1, name);
        ps.setString(2, teacher);
        ps.setInt(3, duration);
        ps.executeUpdate();
    }


    public void addRestriction(Integer id, String restrictions) throws Exception {
        String sql = "INSERT INTO restrictions(id, restrictions) VALUES (?,?)";
        PreparedStatement ps = conn.prepareStatement(sql);
        ps.setInt(1, id);
        ps.setString(2, restrictions);
        ps.executeUpdate();
    }

    public String getNameOfCourse(Integer id) {
        String sql = "SELECT * FROM courses WHERE id=?";
        PreparedStatement ps = null;
        try {
            ps = conn.prepareStatement(sql);
            ps.setInt(1, id);
            ResultSet rs = ps.executeQuery();
            if (rs.next()) {
                return rs.getString("name");
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }

        throw new RuntimeException("User not found! " + id);
    }

    public String getNameOfRoom(Integer id) {
        String sql = "SELECT * FROM rooms WHERE id=?";
        PreparedStatement ps = null;
        try {
            System.out.println("in room");
            ps = conn.prepareStatement(sql);
            ps.setInt(1, id);
            ResultSet rs = ps.executeQuery();
            if (rs.next()) {
                return rs.getString("name");
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }

        throw new RuntimeException("User not found! " + id);
    }

    public Integer getIdOfCourse(String name) throws Exception {
        String sql = "SELECT * FROM courses WHERE name=?";
        PreparedStatement ps = conn.prepareStatement(sql);
        ps.setString(1, name);
        ResultSet rs = ps.executeQuery();
        if (rs.next()) {
            Integer id = rs.getInt("id");
            return id;
        }
        throw new RuntimeException("User not found! " + name);
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