package utils;

public class Document {
    private Integer id;
    private String name;
    private String templates;

    public Document(Integer id, String name, String templates) {
        this.id = id;
        this.name = name;
        this.templates = templates;
    }


    public Integer getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public String getTemplates() {
        return templates;
    }
}
