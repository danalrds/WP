package utils;

public class Room {
    private Integer id;
    private String name;
    private Integer capacity;

    public Room(Integer id, String name, Integer capacity) {
        this.id = id;
        this.name = name;
        this.capacity = capacity;
    }

    public Integer getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public Integer getCapacity() {
        return capacity;
    }
}
