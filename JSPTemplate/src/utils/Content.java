package utils;

public class Content {
    private String title;
    private String description;
    private String url;
    private Integer id;

    public Content(Integer id,String title, String description, String url) {
        this.title = title;
        this.description = description;
        this.url = url;
        this.id=id;
    }

    public Integer getId() {
        return id;
    }

    public String getTitle() {
        return title;
    }

    public String getDescription() {
        return description;
    }

    public String getUrl() {
        return url;
    }
}
