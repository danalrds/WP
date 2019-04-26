package utils;

public class Photo {
    private Integer id;
    private String path;
    private String user;
    private Integer votes;


    public Photo(Integer id, String path, String user, Integer votes) {
        this.id = id;
        this.path = path;
        this.user = user;
        this.votes = votes;
    }

    public Integer getId() {
        return id;
    }

    public String getPath() {
        return path;
    }

    public String getUser() {
        return user;
    }

    public Integer getVotes() {
        return votes;
    }
}
