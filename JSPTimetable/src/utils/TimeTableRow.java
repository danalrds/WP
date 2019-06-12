package utils;

public class TimeTableRow {
    private Integer id;
    private Integer courseId;
    private Integer roomId;
    private String day;
    private Integer startHour;
    private Integer endHour;

    public TimeTableRow(Integer id, Integer courseId, Integer roomId, String day, Integer startHour, Integer endHour) {
        this.id = id;
        this.courseId = courseId;
        this.roomId = roomId;
        this.day = day;
        this.startHour = startHour;
        this.endHour = endHour;
    }

    public Integer getId() {
        return id;
    }

    public Integer getCourseId() {
        return courseId;
    }

    public Integer getRoomId() {
        return roomId;
    }

    public String getDay() {
        return day;
    }

    public Integer getStartHour() {
        return startHour;
    }

    public Integer getEndHour() {
        return endHour;
    }
}
