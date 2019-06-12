package utils;

public class Course {
    private Integer id;
    private String name;
    private String teacher;
    private Integer duration;

    public Course(Integer id, String name, String teacher, Integer duration) {
        this.id = id;
        this.name = name;
        this.teacher = teacher;
        this.duration = duration;
    }

    public Integer getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public String getTeacher() {
        return teacher;
    }

    public Integer getDuration() {
        return duration;
    }
}
